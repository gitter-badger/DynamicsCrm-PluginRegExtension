﻿using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmPluginRegExt.VSPackage.Helpers
{
    public static class Status
    {
	    private static bool isNewLine = true;
        public static void Update(string message, bool newLine = true)
        {
            //Configuration.Instance.DTE.ExecuteCommand("View.Output");
            var dte = Package.GetGlobalService(typeof(SDTE)) as EnvDTE.DTE;
            var win = dte.Windows.Item("{34E76E81-EE4A-11D0-AE2E-00A0C90FFFC3}");
            win.Visible = true;

            IVsOutputWindow outputWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            Guid guidGeneral = Microsoft.VisualStudio.VSConstants.OutputWindowPaneGuid.GeneralPane_guid;
            IVsOutputWindowPane pane;
            int hr = outputWindow.CreatePane(guidGeneral, "Plugin Registration Extension", 1, 0);
            hr = outputWindow.GetPane(guidGeneral, out pane);
            pane.Activate();

	        if (isNewLine)
	        {
		        message = string.Format("{0:yyyy/MMM/dd hh:mm:ss tt: }", DateTime.Now) + message;
	        }

			pane.OutputString(message);

			if (newLine)
			{
				pane.OutputString("\n");
			}

			pane.FlushToTaskList();
            System.Windows.Forms.Application.DoEvents();

	        isNewLine = newLine;
        }
        public static void Clear()
        {
            IVsOutputWindow outputWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            Guid guidGeneral = Microsoft.VisualStudio.VSConstants.OutputWindowPaneGuid.GeneralPane_guid;
            IVsOutputWindowPane pane;
            int hr = outputWindow.CreatePane(guidGeneral, "Crm Code Generator", 1, 0);
            hr = outputWindow.GetPane(guidGeneral, out pane);
            pane.Clear();
            pane.FlushToTaskList();
            System.Windows.Forms.Application.DoEvents();
        }
    }
}
