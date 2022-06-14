using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace isRail.Views
{
    /// <summary>
    /// Interaction logic for MessageBoxInputCustom.xaml
    /// </summary>
    public partial class MessageBoxInputCustom : Window
    {

        private string _inputValue;
        public string InputValue {
            get 
            {
                return _inputValue;
            }
            set
            {
                _inputValue = value;
                InputValueChanged();
            }
        }

        private void InputValueChanged()
        {
            btn.Visibility = !string.IsNullOrEmpty(_inputValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public MessageBoxInputCustom(string title, string buttonTxt)
        {
            DataContext = this;
            InitializeComponent();
            txtTitle.Text = title;
            btn.Content = buttonTxt;
            btn.Visibility = Visibility.Collapsed;

        }

        public MessageBoxInputCustom(string title, ViewModelBase viewModel)
        {
            DataContext = this;
            InitializeComponent();
            txtTitle.Text = title;
            btn.Visibility = Visibility.Collapsed;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        public string GetInputValue()
        {
            return InputValue;
        }
    }
}
