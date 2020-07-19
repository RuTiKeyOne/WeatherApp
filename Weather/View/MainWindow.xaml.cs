using System;
using System.Windows;
using Weather.View.JsonApi;
using System.Windows.Threading;
using System.Collections.Generic;
using Weather.View;
using System.Windows.Documents;
using System.IO;
using System.Text;
using System.Linq;

namespace Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsConnected = false;
        public MainWindow()
        {
            InitializeComponent();
            if (InternetConnection.CheckInternetConnection())
            {
                IsConnected = true;
                LabelDirections.Content = "Choose your position";
            }
            else
            {
                IsConnected = false;
                TextBoxLocation.IsEnabled = false;
                ButtonClear.IsEnabled = false;
                ButtonSearch.IsEnabled = false;
                LabelDirections.Content = "Check internet connection and restart app";
            }
        }
        private void SearchDataWeatherCitys(object sender, RoutedEventArgs e)
        {
            if (IsConnected)
            {
                switch (TextBoxLocation.Text == "")
                {
                    case true:
                        MessageError MessageErrorObject = new MessageError("Fill in the field");
                        MessageErrorObject.Show();
                        //LabelDirections.Content = "Fill in the field";
                        break;
                    case false:
                        LabelDirections.Content = "Wait please";
                        JsonWeatherApi.CreateJsonRequest(TextBoxLocation.Text);
                        DispatcherTimer DispatherTimerObject = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(1000) };
                        DispatherTimerObject.Start();

                        DispatherTimerObject.Tick += new EventHandler((object e, EventArgs a) =>
                        {
                            LabelDirections.Content = "Choose your position";
                            DispatherTimerObject.Stop();
                        });
                            break;
                }
            }
        }
        private void LogOff(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void ClearTextBox(object sender, RoutedEventArgs e)
        {
            TextBoxLocation.Text = "";
        }
    }
}
