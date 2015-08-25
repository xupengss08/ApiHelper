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
using System.Collections.Specialized;

namespace ApiHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static char[] seprators = new char[] { ';' };

        private MainController controller = new MainController();

        public MainWindow(NameValueCollection appSettings)
        {
            InitializeComponent();
            this.AddHosts(appSettings["Host"]);
            this.AddPaths(appSettings["Path"]);
            this.AddFormats(appSettings["Format"]);
            this.controller.SetHost(this.hostComboBox.Text);
            this.controller.SetPath(this.pathComboBox.Text);
            this.controller.SetFormat(this.formatComboBox.Text);
            this.controller.SetParam(this.paramCheckBox.IsChecked.Value);
        }

        public void AddHosts(string hostConfig)
        {
            string[] hosts = hostConfig.Split(MainWindow.seprators);
            foreach (string host in hosts)
            {
                this.hostComboBox.Items.Add(host);
            }
            this.hostComboBox.SelectedIndex = 0;
        }

        public void AddPaths(string pathConfig)
        {
            string[] paths = pathConfig.Split(MainWindow.seprators);
            foreach (string path in paths)
            {
                this.pathComboBox.Items.Add(path);
            }
            this.pathComboBox.SelectedIndex = 0;
        }

        public void AddFormats(string formatConfig)
        {
            string[] formats = formatConfig.Split(MainWindow.seprators);
            foreach (string format in formats)
            {
                this.formatComboBox.Items.Add(format);
            }
            this.formatComboBox.SelectedIndex = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.displayTextBox.Text = this.controller.GenerateApiRequest();
        }

        private void hostComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.controller.SetHost(((ComboBox)sender).SelectedValue.ToString());
        }

        private void pathComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.controller.SetPath(((ComboBox)sender).SelectedValue.ToString());
        }

        private void formatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.controller.SetFormat(((ComboBox)sender).SelectedValue.ToString());
        }

        private void paramCheckBox_Click(object sender, RoutedEventArgs e)
        {   
            this.controller.SetParam((bool)((CheckBox)sender).IsChecked);
        }

        private void sendCheckBox_Click(object sender, RoutedEventArgs e)
        {
            this.controller.SetSendRequest((bool)((CheckBox)sender).IsChecked);
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            bool useFixedUrl = (bool)((CheckBox)sender).IsChecked;
            this.controller.UseFixedUrl = useFixedUrl;
            this.fixedUrlTextBox.IsEnabled = useFixedUrl;
        }

        private void fixedUrlTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.controller.FixedUrl = ((TextBox)sender).Text;
        }
    }
}
