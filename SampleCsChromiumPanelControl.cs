﻿using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Reflection;
using System.IO;
using CefSharp.DevTools.SystemInfo;

namespace SampleCsChromium
{
    [System.Runtime.InteropServices.Guid("A687BDD9-F74C-4BB2-88E0-E2AEC95A9FCE")]
    public partial class SampleCsChromiumPanelControl : UserControl
    {
        private ChromiumWebBrowser m_browser;      

        /// <summary>
        /// Returns the ID of this panel.
        /// </summary>
        public static Guid PanelId
        {
            get
            {
                return typeof(SampleCsChromiumPanelControl).GUID;
            }
        }

        public SampleCsChromiumPanelControl()
        {
            InitializeComponent();
            this.ShowBrowser();
            SampleCsChromiumPlugIn.Instance.UserControl = this;
            this.Disposed += new EventHandler(OnDisposed);
            Rhino.RhinoApp.Closing += RhinoApp_Closing;

        }

        private void ShowBrowser()
        {            



            m_browser = new ChromiumWebBrowser(@"C:\Users\krahimzadeh\OneDrive - Grimshaw Architects\Desktop\GrimshawDT-Rhino\00_publish\grimshaw-dt.html");

            var size = new System.Drawing.Size()
            {
                Width = 400,
                Height = 150
            };

            m_browser.Size = size;
            Controls.Add(m_browser);
            m_browser.Dock = DockStyle.Fill;
            
            m_browser.Enabled = true;
            m_browser.Show();            
        }

        /// <summary>
        /// Occurs when the component is disposed by a call to the
        /// System.ComponentModel.Component.Dispose() method.
        /// </summary>
        private void OnDisposed(object sender, EventArgs e)
        {
            //m_browser.Dispose();
            //Cef.Shutdown();
            //SampleCsChromiumPlugIn.Instance.UserControl = null;
        }

        /// <summary>
        /// Disposes of the browser when Rhino closes.
        /// </summary>
        private void RhinoApp_Closing(object sender, EventArgs e)
        {
            m_browser.Dispose();
            Cef.Shutdown();
            SampleCsChromiumPlugIn.Instance.UserControl = null;
        }
    }
}
