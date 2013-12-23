using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tequila
{
    class LaunchProfile
    {
        private string m_text = "";
        private string m_Exec = "";
        private string m_Params = "";

        public string Text { get { return m_text; } }
        public string Exec { get { return m_Exec; } }
        public string Params { get { return m_Params; } }

        public LaunchProfile(string Text, string Exec, string Params) {
            m_text = Text;
            m_Exec = Exec;
            m_Params = Params;
        }
    }
}
