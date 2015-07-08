﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Win10Test
{
    public partial class MainWindow
    {
        private bool _maximized = false;
        private Size _size;
        private Point _location;
        private string _title = "Windows 10 Test Window";
        private string _header = "HEADER";
        private Path _headerIcon = new Path
        {
            Width = 20,
            Height = 20,
            Stretch = Stretch.Fill,
            Fill = Brushes.Black,
            Margin = new Thickness(7,9,0,0),
            Data = Geometry.Parse("F1 M 22.3908,33.9299L 34.0851,45.6243L 29.7767,49.9327L 18.0823,38.2384L 22.3908,33.9299 Z M 17.1591,37.3152L 14.6971,35.3402C 13.9076,34.5507 14.2153,32.873 15.0049,32.0835L 16.2359,30.8525C 17.0254,30.063 18.5238,29.7552 19.3133,30.5447L 21.4675,33.0067L 17.1591,37.3152 Z M 35.9418,52.3947L 30.6999,50.856L 35.0084,46.5475L 36.4473,51.8893L 35.9418,52.3947 Z M 39.9167,15.8333C 42.1028,15.8333 44.25,17.8139 44.25,20L 44,21L 56,21L 56,57L 24,57L 24,47.75L 27,50.75L 27,54L 53,54L 53,24L 47.5,24L 49.5,28L 30.5,28L 32.5,24L 27,24L 27,35.5L 24,32L 24,21L 36,21L 35.75,20C 35.75,17.8139 37.7305,15.8333 39.9167,15.8333 Z M 39.9166,18.2084C 39.0422,18.2084 38,18.8756 38,19.75C 38,20.0384 38.3653,20.7671 38.5,21L 41.5,21C 41.6347,20.7671 42,20.0384 42,19.75C 42,18.8756 40.7911,18.2084 39.9166,18.2084 Z")
        };

        public MainWindow()
        {
            InitializeComponent();
            WindowDropShadow.DropShadowToWindow(this);
            this.Title.Content = _title;
            this.Header.Text = _header;
            this.HeaderIcon.Children.Clear();
            this.HeaderIcon.Children.Add(_headerIcon);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize(object sender, RoutedEventArgs e)
        {
            Maximize();
        }

        private void Titlebar_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
            if (e.ClickCount == 2 && e.ChangedButton == MouseButton.Left)
                Maximize();
        }

        private void Maximize()
        {
            if (!_maximized)
            {
                _maximized = true;
                _size = RestoreBounds.Size;
                _location = RestoreBounds.Location;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                _maximized = false;
                this.WindowState = WindowState.Normal;
                this.Width = _size.Width;
                this.Height = _size.Height;
                this.Left = _location.X;
                this.Top = _location.Y;
            }
        }
        
    }
}
