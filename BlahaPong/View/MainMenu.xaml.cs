﻿using BlahaPong.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace BlahaPong.View
{
    public partial class MainMenu : Window
    {
        private MainMenuViewModel _mainMenuViewModel = new MainMenuViewModel();
        public MainMenu()
        {
            InitializeComponent();
        }

        private void OnePlayer(object sender, RoutedEventArgs e)
        {
            _mainMenuViewModel.StartOnePlayerMode(this);

        }
        
        private void TwoPlayer(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("2P");
        }
        
        private void Credits(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("BlahaEntertainment Production 2020\n - Bende\n - Dani\n - Tompi");
        }
        
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}