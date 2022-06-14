using System;
using System.IO;
using System.Windows;

namespace isRail.Views
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        public HelpWindow(string type)
        {
            InitializeComponent();

            switch (type)
            {
                case "Manager":
                    browser.Navigate(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Static", "ManagerHelp.html"));
                    break;

                case "Client":
                    browser.Navigate(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Static", "ClientHelp.html"));
                    break;
            }
        }
    }
}
