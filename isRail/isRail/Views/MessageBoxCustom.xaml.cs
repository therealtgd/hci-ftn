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
using System.Windows.Shapes;

namespace isRail.Views
{
    /// <summary>
    /// Interaction logic for MessageBoxCustom.xaml
    /// </summary>
    public partial class MessageBoxCustom : Window
    {
        public string InputValue { get; set; }

        public MessageBoxCustom(string Message, MessageType Type, MessageButtons Buttons)
        {
            DataContext = this;
            InitializeComponent();
            txtMessage.Text = Message;
            switch (Type)
            {
                case MessageType.Info:
                    txtTitle.Text = "Informacije";
                    break;
                case MessageType.Confirmation:
                    txtTitle.Text = "Potvrda";
                    break;
                case MessageType.Success:
                    {
                        txtTitle.Text = "Uspeh";
                    }
                    break;
                case MessageType.Warning:
                    txtTitle.Text = "Upozorenje";
                    break;
                case MessageType.Error:
                    {
                        txtTitle.Text = "Greška";
                    }
                    break;
            }
            switch (Buttons)
            {
                case MessageButtons.YesNo:
                    {
                        btnCancel.Visibility = Visibility.Collapsed;
                        btnYes.IsDefault = true;
                        btnNo.IsCancel = true;
                        break;
                    }
                case MessageButtons.OkCancel:
                    {
                        btnYes.Visibility = Visibility.Collapsed;
                        btnNo.Visibility = Visibility.Collapsed;
                        btnOk.IsDefault = true; btnCancel.IsCancel = true;
                        break;
                    }
                case MessageButtons.Ok:
                    {
                        btnYes.Visibility = Visibility.Collapsed;
                        btnNo.Visibility = Visibility.Collapsed;
                        btnCancel.Visibility= Visibility.Collapsed;
                        btnOk.IsDefault = true;
                        btnCancel.IsCancel = true;
                        break;
                    }
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
public enum MessageType
{
    Info,
    Confirmation,
    Success,
    Warning,
    Error,
}
public enum MessageButtons
{
    OkCancel,
    YesNo,
    Ok,
}
