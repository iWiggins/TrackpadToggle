///Based on
///https://www.codeproject.com/Articles/290013/Formless-System-Tray-Application
using System;
using System.Diagnostics;
using System.Windows.Forms;
using TrackpadToggle.Properties;
using System.Reflection;

namespace TrackpadToggle
{
	class ProcessIcon : IDisposable
	{
		NotifyIcon ni;

		public ProcessIcon()
		{
			ni = new NotifyIcon();
		}

		public void Display()
		{
			// Put the icon in the system tray and allow it react to mouse clicks.			
			ni.MouseClick += new MouseEventHandler(ni_MouseClick);
			ni.Icon = Resources.SystemTrayApp;
			ni.Text = "Trackpad Toggle";
			ni.Visible = true;

			ni.ContextMenuStrip = ContextMenus.Create();
		}

		public void Dispose()
		{
			// When the application closes, this will remove the icon from the system tray immediately.
			ni.Dispose();
		}

		void ni_MouseClick(object sender, MouseEventArgs e)
		{
			// Handle mouse button clicks.
			if (e.Button == MouseButtons.Left)
			{
                //Use the reflection system to call the private "ShowContextMenu" function.
                //This function is called when the icon is right clicked,
                //we want it to show up on left click too.
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(ni, null);
            }
		}
	}
}