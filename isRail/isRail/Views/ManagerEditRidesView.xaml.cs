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
    /// Interaction logic for ManagerEditRidesView.xaml
    /// </summary>
    public partial class ManagerEditRidesView : UserControl
    {
        public ManagerEditRidesView()
        {
            InitializeComponent();
        }

        private void TextBoxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsInt(e.Text);
        }

        private bool IsInt(string text)
        {
            return int.TryParse(text, out int value);
        }
        private void TextBoxPrice_Pasting(object sender, DataObjectPastingEventArgs e)
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
    }
}
