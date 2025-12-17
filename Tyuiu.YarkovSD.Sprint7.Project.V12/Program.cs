using System;
using System.Windows.Forms;

namespace Tyuiu.YarkovSD.Sprint7.Project.V12
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainYSD());
        }
    }
}