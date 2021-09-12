using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace Sharp2048
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            this.Text = String.Format("About");
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version: {0}", AssemblyVersion);
            this.labelBuild.Text = String.Format("Build date: {0}", AssemblyBuildDate);
            this.labelCompanyName.Text = String.Format("Athor: {0}", AssemblyCompany);
            this.textBoxDescription.Text = String.Format("{0}\r\nContacts:\r\neMail - {1}\r\nTelegram - {2}", AssemblyDescription, "Limowski256@gmail.com", "@Limows");
            this.BackColor = Color.FromArgb(187, 173, 160);
        }

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().GetName().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyBuildDate
        {   
            get
            {
                return File.GetLastWriteTime(Assembly.GetExecutingAssembly().GetName().CodeBase.Substring(8)).ToString("dd.MM.yy");

                string filePath = Assembly.GetCallingAssembly().Location;
                const int peHeaderOffset = 60;
                const int linkerTimestampOffset = 8;
                byte[] b = new byte[2048];
                using (Stream s = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    s.Read(b, 0, 2048);
                }

                int secondsSince1970 = BitConverter.ToInt32(b, BitConverter.ToInt32(b, peHeaderOffset) + linkerTimestampOffset);
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
                dt = dt.AddSeconds(secondsSince1970);
                dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);

                return dt.ToString("dd.MM.yy");
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}