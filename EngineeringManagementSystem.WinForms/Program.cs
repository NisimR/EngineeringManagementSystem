using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineeringManagementSystem.WinForms.Forms;  // ✅ Required for WinForms

namespace EngineeringManagementSystem.WinForms
{

    internal class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen()); // Ensure you're running the correct form
        }
    }
}
