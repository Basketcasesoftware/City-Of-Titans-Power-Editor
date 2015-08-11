using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace CityOfTitansPowerEditor
{
    public class PowerLevels
    {
        public string PowerLevel { get; set; }

        public Double Multiplier { get; set; }
    }

    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public List<PowerLevels> powerLevels = new List<PowerLevels>();

        public MainWindow()
        {
            InitializeComponent();

            titleBar.MouseLeftButtonDown += (o, e) => DragMove();

            txtVersion.Text = Version;

            powerLevels.Add(new PowerLevels() { PowerLevel = "Primary", Multiplier = 1.0 });
            powerLevels.Add(new PowerLevels() { PowerLevel = "Secondary", Multiplier = .8 });
            powerLevels.Add(new PowerLevels() { PowerLevel = "Tertiary", Multiplier = .5 });
            powerLevels.Add(new PowerLevels() { PowerLevel = "Starter", Multiplier = .3 });

            //lvAttackPowerLevel.ItemsSource = powerLevels;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            wndMain.WindowState = WindowState.Minimized;
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (wndMain.WindowState == WindowState.Maximized)
            {
                wndMain.WindowState = WindowState.Normal;

                pthRestore.Data = Geometry.Parse("F1 M 34,17L 43,17L 43,23L 34,23L 34,17 Z M 35,19L 35,22L 42,22L 42,19L 35,19 Z");
            }
            else
            {
                wndMain.WindowState = WindowState.Maximized;

                pthRestore.Data=Geometry.Parse("M1,4.9996096 L1,7.000219 7,6.999219 7,5.001 2,5.001 2,4.9996096 z M3,2.0014141 L3,3.0000001 8,3.0000001 8,4.0000001 8,4.0008045 9,4.0008045 9,2.0014141 z M2,0 L10,0 10,0.0010234118 10,1.0000001 10,5.001 8,5.001 8,7.9990235 0,8.0000239 0,4.0000001 0,3.0009998 0,3.0000001 2,3.0000001 2,1.0000001 2,0.0010234118 z");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mnuHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            popAbout.IsOpen = true;
        }
    }
}
