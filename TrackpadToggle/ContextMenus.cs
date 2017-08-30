///Based on
///https://www.codeproject.com/Articles/290013/Formless-System-Tray-Application
using System;
using System.Diagnostics;
using System.Windows.Forms;
using TrackpadToggle.Properties;
using System.Drawing;
using System.Configuration;

namespace TrackpadToggle
{
	static class ContextMenus
    {
		public static ContextMenuStrip Create()
		{
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem item;

            item = new ToolStripMenuItem
            {
                Text = "Enable Trackpad"
            };
            item.Click += new EventHandler(EnableTrackpad_Click);
			menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "Disable Trackpad"
            };
            item.Click += new EventHandler(DisableTrackpad_Click);
			menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "Exit"
            };
            item.Click += new EventHandler(Exit_Click);
            menu.Items.Add(item);

            return menu;
		}

        private static void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static void EnableTrackpad_Click(object sender, EventArgs e)
		{
            var appsettings = ConfigurationManager.AppSettings;

            DisableHardware.DisableDevice(
                n => n.Contains(appsettings["HID"]), false);
		}

		static void DisableTrackpad_Click(object sender, EventArgs e)
		{
            var appsettings = ConfigurationManager.AppSettings;

            DisableHardware.DisableDevice(
                n => n.Contains(appsettings["HID"]), true);
        }


	}
}