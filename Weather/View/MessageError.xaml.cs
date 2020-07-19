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
using System.Windows.Threading;

namespace Weather.View
{
    /// <summary>
    /// Interaction logic for MessageError.xaml
    /// </summary>
    public partial class MessageError : Window
    {
        public MessageError()
        {
            InitializeComponent();
        }
        public MessageError(string error)
        {
            InitializeComponent();
            TextBlockError.Text = error;
        }
        private void LogOffErrorWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
