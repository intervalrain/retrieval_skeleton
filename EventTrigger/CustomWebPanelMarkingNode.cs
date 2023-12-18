using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Spotfire.Dxp.Framework.Persistence;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Application;
using Spotfire.Dxp.Application.Collaboration;
using Spotfire.Dxp.Framework.DocumentModel;
using Spotfire.Dxp.Data;


namespace CustomWebPanelPlugin
{
    [PersistenceVersion(1, 2)]
    [Serializable]
    public class CustomWebPanelMarkingNode : CustomNode
    {
        #region Private fields

        private readonly UndoableProperty<bool> enabled;
        private readonly UndoableProperty<string> urlTemplate;

        private readonly UndoableCrossReferenceProperty<DataMarkingSelection> marking;
        private readonly UndoableCrossReferenceProperty<DataTable> table;
        private readonly UndoableCrossReferenceProperty<DataColumn> column;

        #endregion

        #region Classes for property names

        /// <summary>
        /// Contains property name constants for the public properties of <see cref="ITunesMarkingNode"/>.
        /// </summary>
        public new abstract class PropertyNames : CustomNode.PropertyNames
        {
            /// <summary>
            /// The name of the property Marking.
            /// </summary>
            public static readonly PropertyName Marking = CreatePropertyName("Marking");

            /// <summary>
            /// The name of the property Table.
            /// </summary>
            public static readonly PropertyName Table = CreatePropertyName("Table");

            /// <summary>
            /// The name of the property Column.
            /// </summary>
            public static readonly PropertyName Column = CreatePropertyName("Column");

            /// <summary>
            /// The name of the property Enabled.
            /// </summary>
            public static readonly PropertyName Enabled = CreatePropertyName("Enabled");

            /// <summary>
            /// The name of the property UrlTemplate.
            /// </summary>
            public static readonly PropertyName UrlTemplate = CreatePropertyName("UrlTemplate");

        }

        #endregion // Classes for property names

        #region Public properties

        /// <summary>
        /// Gets or sets Marking.
        /// </summary>
        public DataMarkingSelection Marking
        {
            get { return marking.Value; }
            set { marking.Value = value; }
        }

        /// <summary>
        /// Gets or sets Table.
        /// </summary>
        public DataTable Table
        {
            get { return table.Value; }
            set { table.Value = value; }
        }

        /// <summary>
        /// Gets or sets Column
        /// </summary>
        public DataColumn Column
        {
            get { return column.Value; }
            set { column.Value = value; }
        }

        /// <summary>
        /// Gets or sets Enabled
        /// </summary>
        public bool Enabled
        {
            get { return enabled.Value; }
            set { enabled.Value = value; }
        }

        /// <summary>
        /// Gets or sets UrlTemplate
        /// </summary>
        public string UrlTemplate
        {
            get { return urlTemplate.Value; }
            set { urlTemplate.Value = value; }
        }    

        #endregion // Public properties

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomWebPanelMarkingNode"/> class./// </summary>
        public CustomWebPanelMarkingNode()
        {
            CreateProperty(PropertyNames.Enabled, out enabled, default(bool));
            CreateProperty(PropertyNames.UrlTemplate, out urlTemplate, "http://en.wikipedia.org/wiki/%1");
            CreateProperty(PropertyNames.Marking, out marking, default(DataMarkingSelection));
            CreateProperty(PropertyNames.Table, out table, default(DataTable));
            CreateProperty(PropertyNames.Column, out column, default(DataColumn));
        }

        #endregion // Construction

        #region ISerializable Members

        /// <summary>Implements ISerializable.</summary>
        protected CustomWebPanelMarkingNode(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            DeserializeProperty(info, context, PropertyNames.Marking, out marking);
            DeserializeProperty(info, context, PropertyNames.Table, out table);
            
            var version = GetPersistedVersion(info, context, typeof(CustomWebPanelMarkingNode));

            if (version.MajorVersion == 1 &&
                version.MinorVersion <= 1)
            {
                CreateProperty(PropertyNames.Enabled, out enabled, true);
                CreateProperty(PropertyNames.UrlTemplate, out urlTemplate, "http://en.wikipedia.org/wiki/%1");
                CreateProperty(PropertyNames.Column, out column, default(DataColumn));
            }
            else
            {
                DeserializeProperty(info, context, PropertyNames.Column, out column);
                DeserializeProperty(info, context, PropertyNames.Enabled, out enabled);
                DeserializeProperty(info, context, PropertyNames.UrlTemplate, out urlTemplate);
            }
        }

        /// <summary>Implements ISerializable.</summary>
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            SerializeProperty(info, context, marking);
            SerializeProperty(info, context, table);
            SerializeProperty(info, context, column);
            SerializeProperty(info, context, enabled);
            SerializeProperty(info, context, urlTemplate);
        }

        #endregion // ISerializable Members

        protected override void DeclareInternalEventHandlers(InternalEventManager eventManager)
        {
            base.DeclareInternalEventHandlers(eventManager);

            eventManager.AddEventHandler (MarkingChanged,                                           
                Trigger.CreateMutablePropertyTrigger<DataMarkingSelection> (
                    this,
                    PropertyNames.Marking,
                    DataMarkingSelection.PropertyNames.Selection ) );
        }

        private void MarkingChanged(DocumentNode node, PropertyName propertyName)
        {
            // Check whether Enabled is true, or whether any of the required parameters are invalid.
            if (!Enabled ||
                Marking == null || 
                Table == null ||
                Column == null ||
                string.IsNullOrEmpty(UrlTemplate) ||
                !UrlTemplate.Contains("%1")
                )
            {
                    return;
            }

            // Get the currently marked rows.
            var markedRows = Marking.GetSelection(Table).AsIndexSet();

            if (markedRows.Count == 0)
            {
                // No rows marked, return.
                return;
            }

            // Pick the first marked row.
            var markedRow = markedRows.First;

            // Retrieve all the columns that we need from the table.
            try
            {
                var rowValAsText = Column.RowValues.GetValue(markedRow).ValidValue.ToString();

                // Get the document that this node is part of.
                var document = Context.GetAncestor<Document>();

                CollaborationPanel panel = null;

                if (document.ActivePageReference.Panels.TryGetPanel(out panel))
                {
                    if (!panel.Visible)
                        panel.Visible = true;
                }
                else
                {
                    panel = document.ActivePageReference.Panels.AddNew<CollaborationPanel>();
                }
             
                var panelUri = new Uri(UrlTemplate.Replace("%1", rowValAsText));

                panel.Url = panelUri;

            }
            catch
            {
                Debug.WriteLine("General Error in MarkingChanged");
            }         
        }

    }
}
