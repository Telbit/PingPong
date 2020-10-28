using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlahaPong.Model;
using BlahaPong.ViewModel;


namespace BlahaPong
{
    /// <summMainWindow_OnKeyUpaction logic for MainWindow.xaml>
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            canv.Children.Add(vm.playerOne.Rectangle);
            canv.Children.Add(vm.playerTwo.Rectangle);
            canv.Children.Add(vm._ball.BallItem);
            canv.Children.Add(vm.PauseImage);
            vm.StartGameLoop();
            //rect.PreviewMouseLeftButtonDown += (sender, args) MessageBox.Show("Yo mamma");
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            vm.SetWindowHeight(this.Height);
            vm.KeydownEvent(e,0);
        }
        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            vm.KeyUpEvent(e);
        }

    }
}