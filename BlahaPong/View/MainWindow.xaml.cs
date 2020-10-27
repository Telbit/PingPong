using System;
using System.Collections.Generic;
using System.Linq;
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


namespace BlahaPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Paddle paddle;
        public MainWindow()
        {
            InitializeComponent();
            paddle = new Paddle(20, 115, 5, 200, 10, this.canv, Key.W, Key.S);
            //rect.PreviewMouseLeftButtonDown += (sender, args) MessageBox.Show("Yo mamma");
        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == paddle.KeyDown)
            {
                paddle.Move(1, 0);
            }
            
            if (e.Key == paddle.KeyUp)
            {
                paddle.Move(-1, 0);
            }
        }
    }
}