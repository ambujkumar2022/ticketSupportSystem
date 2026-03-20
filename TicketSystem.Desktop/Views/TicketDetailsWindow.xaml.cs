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
using TicketSystem.Desktop.Models;

namespace TicketSystem.Desktop.Views
{
    /// <summary>
    /// Interaction logic for TicketDetailsWindow.xaml
    /// </summary>
    public partial class TicketDetailsWindow : Window
    {
        private Ticket _ticket;
        private User _user;
        public TicketDetailsWindow(Ticket ticket, User user)
        {
            InitializeComponent();
            _ticket = ticket;
            _user = user;

            LoadData();

            if (_user.Role == "Admin")
                adminPanel.Visibility = Visibility.Visible;
        }
        private async void LoadData()
        {
            lblId.Text = _ticket.Id.ToString();
            lblSubject.Text = _ticket.Subject;
            txtDesc.Text = _ticket.Description;
            lblPriority.Text = _ticket.Priority;
            lblStatus.Text = _ticket.Status;
            lblAssigned.Text = _ticket.AssignedTo;

            dgHistory.ItemsSource = await ApiService.GetHistory(_ticket.Id);
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var update = new
            {
                TicketId = _ticket.Id,
                Status = (cmbStatus.SelectedItem as ComboBoxItem)?.Content.ToString(),
                AssignedTo = cmbAssign.Text,
                Comment = txtComment.Text
            };

            await ApiService.UpdateTicket(update);

            MessageBox.Show("Updated");
            LoadData();
        }
    }
}
