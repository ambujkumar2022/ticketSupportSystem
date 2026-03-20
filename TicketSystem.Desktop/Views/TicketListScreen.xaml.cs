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
using TicketSystem.Desktop.Models;
using TicketSystem.Desktop.Services;

namespace TicketSystem.Desktop.Views
{
    /// <summary>
    /// Interaction logic for TicketListScreen.xaml
    /// </summary>
    public partial class TicketListScreen : Window
    {
        private User _user;
        public TicketListScreen(User user)
        {
            InitializeComponent();
            _user = user;
            LoadTickets();
        }
        private async void LoadTickets()
        {
            dgTickets.ItemsSource = await ApiService.GetTickets(_user);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadTickets();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            new CreateTicketWindow().ShowDialog();
            LoadTickets();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            var ticket = (sender as FrameworkElement).DataContext as Ticket;
            new TicketDetailsWindow(ticket, _user).ShowDialog();
        }
    }
}
