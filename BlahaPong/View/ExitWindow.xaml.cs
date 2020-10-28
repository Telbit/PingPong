using BlahaPong.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlahaPong.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ExitWindow : Window
    {
        ExitWindowViewModel _exitWindowViewModel = new ExitWindowViewModel();
        public ExitWindow()
        {
            InitializeComponent();
            this.DataContext = _exitWindowViewModel;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            _exitWindowViewModel.YesButtonClick();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            _exitWindowViewModel.NoButtonClick();
        }
    }
}
