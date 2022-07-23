
namespace Examen_17_07.Classes
{
    internal static class Password_Class
    {
        static string password = "1111";
        static string license_key = "i love c#";
        static public string License_key { get { return license_key; } }
        static public string Password { get { return password; } set { password = value; } }
        static public bool Varificaton(string str) { return Equals(str, Password); }
        static public bool Varif_Key(string str) { return Equals(str, License_key); }
    }
}
