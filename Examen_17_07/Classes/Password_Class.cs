using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_17_07.Classes
{
    internal static class Password_Class
    {
        static string password = "1111";
        static public string Password { get { return password; } set { password = value; } }
        static public bool Varificaton(string str) { return Equals(str, Password); }
    }
}
