using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace LZSoft.EditPlusC
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidEditPlusCPkgString)]
    public sealed class EditPlusCPackage : Package
    {
        public EditPlusCPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", ToString()));
        }

        #region Package Members

        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", ToString()));
            base.Initialize();
            
            if ( GetService(typeof(IMenuCommandService)) is OleMenuCommandService mcs )
            {
                var menuCommandID = new CommandID(GuidList.guidEditPlusCCmdSet, (int)PkgCmdIDList.OpenPairFile);
                var menuItem = new MenuCommand(MenuItemCallback, menuCommandID );
                mcs.AddCommand( menuItem );
            }
        }

        #endregion

        private void MenuItemCallback(object sender, EventArgs e)
        {
            DTEClass c;
            var uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            var clsid = Guid.Empty;
            IEnumWindowFrames ppenum;
            var windows = uiShell.GetDocumentWindowEnum(out ppenum);

            for (int i = 0; i < windows; i++)
            {
            }
            ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(0,ref clsid,"EditPlusC",string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", ToString()),string.Empty,0,OLEMSGBUTTON.OLEMSGBUTTON_OK,OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,OLEMSGICON.OLEMSGICON_INFO,0,out var _));
        }

    }
}
