using System;
using System.Windows.Forms;
using Final_Project;
using Final_Project.Presenters;
using Final_Project.Views;

namespace Final_Project
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 form = new Form2();
            MenuPresenter presenter = new MenuPresenter(form);
            Application.Run(form);
        }
    }
}
