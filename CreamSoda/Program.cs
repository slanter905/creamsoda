using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CreamSoda
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MyToolkit.args = args;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreamSoda());
        }
    }

    public static class Helpers
    {
        public static string GetValueOrDefault(this XAttribute attribute, string defaultValue = "")
        {
            if (attribute == null)
                return defaultValue;
            else
                return attribute.Value;
        }

        public static string GetAttributeValueOrDefault(this XElement element, string attributeName, string defaultValue = "")
        {
            if (element == null)
                return defaultValue;
            else
                return element.Attribute(attributeName).GetValueOrDefault(defaultValue);
        }
    }
}
