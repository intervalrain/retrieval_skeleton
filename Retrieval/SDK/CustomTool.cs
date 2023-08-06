using System;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;

namespace Retrieval.SDK
{
    public abstract class CustomTool<TContext> where TContext : class
    {
	    private readonly string _menuText;
		private readonly Image _menuImage;
		private readonly LicensedFunction _licensedFunction;
		private readonly MenuCategory _menuCategory;
		private readonly ToolCategory _toolCategory;
		private readonly ExtensionIcon _extensionIcon;

		internal string MenuText => GetMenuTextCore();
		internal Image MenuImage => _menuImage;
		internal LicensedFunction LicensedFunction=> _licensedFunction;
		internal MenuCategory MenuCategory => _menuCategory;
		internal ToolCategory ToolCategory => _toolCategory;
		internal ExtensionIcon ExtensionIcon => _extensionIcon;

		private CustomTool(string menuText, Image menuImage, LicensedFunction licensedFunction, MenuCategory menuCategory, ToolCategory toolCategory, ExtensionIcon extensionIcon)
		{
			_menuText = menuText;
			_menuImage = menuImage;
			_licensedFunction = licensedFunction;
			_menuCategory = menuCategory;
			_toolCategory = toolCategory;
			_extensionIcon = extensionIcon;
		}

		protected CustomTool(string menuText)
			: this(menuText, null, null, null, null, null) { }

		protected CustomTool(string menuText, LicensedFunction licensedFunction)
			: this(menuText, null, licensedFunction, null, null, null) { }
		
		
		protected CustomTool(string menuText, LicensedFunction licensedFunction, ToolCategory toolCategory)
			: this(menuText, null, licensedFunction, null, toolCategory, null) { }

		protected CustomTool(string menuText, LicensedFunction licensedFunction, MenuCategory menuCategory,
			ExtensionIcon extensionIcon)
			: this(menuText, null, licensedFunction, menuCategory, null, extensionIcon) { }

		protected CustomTool(string menuText, LicensedFunction licensedFunction, MenuCategory menuCategory,
			Image menuImage)
			: this(menuText, menuImage, licensedFunction, menuCategory, null, null) { }

		protected virtual void Execute(TContext context)
		{
		}

		protected virtual void ExecuteAndPrompt(TContext context)
		{
		}

		protected virtual void ExecuteAndPromptCore(TContext context)
		{
		}

		protected virtual void ExecuteCore(TContext context)
		{
		}

		protected virtual string GetMenuTextCore()
		{
			return _menuText;
		}
		
		protected virtual bool GetSupportsPromptingCore()
		{
			return false;
		}

		protected virtual string GetToolBarIdCore()
		{
			return string.Empty;
		}

		protected virtual bool IsEnabled(TContext context)
		{
			return false;
		}
		
		protected virtual bool IsEnabledCore(TContext context)
		{
			return false;
		}
		
		protected virtual bool IsVisibleCore(TContext context)
		{
			return false;
		}
    }
}