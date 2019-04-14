using Stone.Wpf.Client.Pages.Transacoes;
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

namespace Stone.Wpf.Client.Pages
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();

            Application.Current.MainWindow.Show();
        }

        private void btnConsultaTransacoes_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            var menu = new ConsultaTransacoes();
            menu.Show();
        }

        private void btnNovaTransacao_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            var menu = new NovaTransacao();
            menu.Show();
        }
    }
}
