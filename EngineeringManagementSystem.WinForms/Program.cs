//using EngineeringManagementSystem.WinForms.Forms;
using System;
using System.Windows.Forms; // ← זה מאפשר להשתמש ב־Application
using EngineeringManagementSystem.WinForms.Forms;

namespace EngineeringManagementSystem.WinForms
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
            //Application.Run(new Questions()); // זה מפעיל את הטופס ומחזיק את הלולאה
        }

    }
}
