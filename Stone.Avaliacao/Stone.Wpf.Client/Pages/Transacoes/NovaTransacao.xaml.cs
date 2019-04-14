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

namespace Stone.Wpf.Client.Pages.Transacoes
{
    /// <summary>
    /// Interaction logic for NovaTransacao.xaml
    /// </summary>
    public partial class NovaTransacao : Window
    {
        public NovaTransacao()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();

            var menu = new MenuPrincipal();
            menu.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var menu = new MenuPrincipal();
            menu.Show();
        }
    }
}
