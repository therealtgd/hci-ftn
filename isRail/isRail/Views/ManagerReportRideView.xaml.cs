using isRail.ViewModels;
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

namespace isRail.Views
{
    /// <summary>
    /// Interaction logic for ManagerReportRideView.xaml
    /// </summary>
    public partial class ManagerReportRideView : UserControl
    {
        public ManagerReportRideView()
        {
            InitializeComponent();
        }

        private void TextBoxNumOfSales_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsInt(e.Text);
        }

        private bool IsInt(string text)
        {
            return int.TryParse(text, out int value);  
        }

        private void TextBoxEarnings_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsDouble(e.Text);
        }

        private bool IsDouble(string text)
        {
            return double.TryParse(text, out double value);
        }

        private void TextBoxNumOfSales_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsInt(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void TextBoxEarnings_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsDouble(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private TicketDetailsView _ticketDetailsView { get; set; }

        private void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {

            if (_ticketDetailsView != null)
                _ticketDetailsView.Close();
            _ticketDetailsView = new TicketDetailsView();
            _ticketDetailsView.DataContext = ((Button)sender).DataContext;
            TicketViewModel dataContext = (TicketViewModel)_ticketDetailsView.DataContext;
            _ticketDetailsView.Title = "Detalji prodaja za vožnju " + dataContext.RideViewModel.From + " - " + dataContext.RideViewModel.To;
            _ticketDetailsView.Show();
        }

    }
}
