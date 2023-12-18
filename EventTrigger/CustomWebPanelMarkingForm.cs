using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Spotfire.Dxp.Application;
using Spotfire.Dxp.Data;

using CustomWebPanelPlugin;
using Spotfire.Dxp.Framework.DocumentModel;

namespace CustomWebPanelFormsPlugin
{
    public partial class CustomWebPanelMarkingForm : Form
    {
        #region Private fields

        private readonly CustomWebPanelMarkingNode model;
        private bool isUpdating = false;

        #endregion

        #region Constructors

        public CustomWebPanelMarkingForm()
        {
            InitializeComponent();
        }

        public CustomWebPanelMarkingForm(CustomWebPanelMarkingNode model)
            : this()
        {
            this.model = model;
            var document = model.Context.GetAncestor<Document>();
            components = new Container();
            var em = new ExternalEventManager(components);

            em.AddEventHandler(UpdateMarkings, 
                Trigger.CreatePropertyTrigger(document.Data.Markings, DataMarkingSelectionCollection.PropertyNames.Items));
            em.AddEventHandler(UpdateTables, 
                Trigger.CreatePropertyTrigger(document.Data.Tables, DataTableCollection.PropertyNames.Items) );
            em.AddEventHandler(UpdateTemplate,
                Trigger.CreatePropertyTrigger(model, CustomWebPanelMarkingNode.PropertyNames.UrlTemplate));
            em.AddEventHandler(UpdateEnabled,
                Trigger.CreatePropertyTrigger(model, CustomWebPanelMarkingNode.PropertyNames.Enabled));
            em.AddEventHandler(UpdateColumns,
                Trigger.CreatePropertyTrigger(model, CustomWebPanelMarkingNode.PropertyNames.Table));

            UpdateMarkings();
            UpdateTables();
            UpdateColumns();
            UpdateTemplate();
            UpdateEnabled();

        }

        #endregion

        #region Event Handlers

        private void UpdateMarkings()
        {
            try
            {
                isUpdating = true;
                var document = model.Context.GetAncestor<Document>();


                comboBoxMarking.BeginUpdate();
                comboBoxMarking.Items.Clear();

                foreach (DataMarkingSelection marking in document.Data.Markings)
                {
                    comboBoxMarking.Items.Add(marking);
                }

                if (model.Marking != null &&
                    comboBoxMarking.Items.Contains(model.Marking))
                {
                    comboBoxMarking.SelectedItem = model.Marking;
                }


                comboBoxMarking.EndUpdate();
            }
            finally
            {
                isUpdating = false;
            }

        }

        private void UpdateTables()
        {
            try
            {
                isUpdating = true;
                var document = model.Context.GetAncestor<Document>();

                comboBoxTable.BeginUpdate();
                comboBoxTable.Items.Clear();

                foreach (DataTable table in document.Data.Tables)
                {
                    comboBoxTable.Items.Add(table);
                }

                if (model.Table != null &&
                    comboBoxTable.Items.Contains(model.Table))
                {
                    comboBoxTable.SelectedItem = model.Table;
                }

                comboBoxTable.EndUpdate();
            }
            finally
            {
                isUpdating = false;
            }


        }


        private void UpdateColumns()
        {
            try
            {
                isUpdating = true;
                comboBoxColumn.BeginUpdate();
                comboBoxColumn.Items.Clear();

                DataColumn selectedColumn = null;

                if (model.Table != null)
                {
                    foreach (var column in model.Table.Columns)
                    {
                        comboBoxColumn.Items.Add(column);

                    }
                }

                if (model.Table != null && model.Table.Columns.Contains(model.Column))
                {
                    comboBoxColumn.SelectedItem = model.Column;
                }
                comboBoxColumn.EndUpdate();

            }
            finally
            {
                isUpdating = false;
            }
        }


        public void UpdateTemplate()
        {
            try
            {
                isUpdating = true;
                textBoxUrlTemplate.Text = model.UrlTemplate;

            }
            finally
            {
                isUpdating = false;
            }
        
        }

        public void UpdateEnabled()
        {
            try
            {
                isUpdating = true;
                checkBoxEnabled.Checked = model.Enabled;
            
            }
            finally
            {
                isUpdating = false;
            }
        }

        #endregion

        #region winformEventHandlers
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SelectedTableChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            model.Table = comboBoxTable.SelectedItem as DataTable;
        }

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            model.Enabled = checkBoxEnabled.Checked;
        }

        private void comboBoxMarking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            model.Marking = comboBoxMarking.SelectedItem as DataMarkingSelection;
        }

        private void comboBoxColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            model.Column = comboBoxColumn.SelectedItem as DataColumn;
        }

        private void textBoxUrlTemplate_Validating(object sender, CancelEventArgs e)
        {
            if (! textBoxUrlTemplate.Text.Contains("%1"))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxUrlTemplate, "Template must contain the letters %1");
            }
            
        }

        private void textBoxUrlTemplate_Validated(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            model.UrlTemplate = textBoxUrlTemplate.Text;
        }
        #endregion winformEventHandlers
    }
}
