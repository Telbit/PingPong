using BlahaPong.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BlahaPong.ViewModel
{
    public class ExitWindowViewModel
    {
        private Window _exitWindow;

        private Window GetExitWindow()
        {
            return _exitWindow = new ExitWindow();
        }

        public void YesButtonClick()
        {
            Application.Current.Shutdown();
        }

        public void NoButtonClick()
        {
            _exitWindow.Close();
        }

        public void ShowExitWindow()
        {
            GetExitWindow().Show();
        }

    }
}
