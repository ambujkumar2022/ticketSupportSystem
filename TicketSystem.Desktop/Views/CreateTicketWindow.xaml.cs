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
using TicketSystem.Desktop.Services;

namespace TicketSystem.Desktop.Views
{
    /// <summary>
    /// Interaction logic for CreateTicketWindow.xaml
    /// </summary>
    public partial class CreateTicketWindow : Window
    {
        public CreateTicketWindow()
        {
            InitializeComponent();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            var ticket = new
            {
                Subject = txtSubject.Text,
                Description = txtDescription.Text,
                Priority = (cmbPriority.SelectedItem as ComboBoxItem)?.Content.ToString()
            };

            await ApiService.CreateTicket(ticket);

            MessageBox.Show("Ticket Created");
            this.Close();
        }
    }
}
