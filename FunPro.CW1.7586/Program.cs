using System;
using System.Windows.Forms;


namespace FunPro.CW1._7586
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainParentForm());
        }
    }
    
     /////////????????? не уверен насчет ниржней строки
    

    internal class MainParentForm : Form
    {
    }
}
