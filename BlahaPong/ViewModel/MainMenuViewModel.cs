using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BlahaPong.ViewModel
{
    class MainMenuViewModel
    {

        public void StartOnePlayerMode(Window menu)
        {

            MainWindow win = new MainWindow(true);
            menu.Close();
            win.Show();
        }
    }
}
