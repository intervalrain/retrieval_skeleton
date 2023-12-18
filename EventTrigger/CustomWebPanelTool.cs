using System;
using CustomWebPanelPlugin.Properties;
using Spotfire.Dxp.Application.Extension;
using Spotfire.Dxp.Application;

using Spotfire.Dxp.Framework.ApplicationModel;

namespace CustomWebPanelPlugin
{
    // Override methods in this class to register your extensions.
    public sealed class CustomWebPanelTool : CustomTool<Document>
    {
        public CustomWebPanelTool()
            : base(Resources.CollaborationToolTitle)
        {
            // Empty
        }

        protected override void ExecuteCore(Document context)
        {
            CustomWebPanelMarkingNode collabNode = context.CustomNodes.AddNewIfNeeded<CustomWebPanelMarkingNode>();

            PromptService promptService = context.Context.GetService<PromptService>();

            if (promptService.IsPromptingAllowed)
            {
                promptService.Prompt(collabNode);
            }
        }
    }
}
