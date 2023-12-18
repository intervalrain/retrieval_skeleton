using System;
using System.Windows.Forms;

using Spotfire.Dxp.Application;
using Spotfire.Dxp.Application.Extension;

using CustomWebPanelPlugin;

namespace CustomWebPanelFormsPlugin
{
    /// <summary>
    /// </summary>
    public sealed class CustomCollaborationFormsPluginAddIn : AddIn
    {
        // Override methods in this class to register your extensions.

        protected override void RegisterViews(ViewRegistrar registrar)
        {
            base.RegisterViews(registrar);

            registrar.Register(typeof(Form), typeof(CustomWebPanelMarkingNode), typeof(CustomWebPanelMarkingForm));
        }

        protected override void RegisterTools(ToolRegistrar registrar)
        {
            base.RegisterTools(registrar);

            registrar.Register(new CustomWebPanelTool());
        }
    }
}

