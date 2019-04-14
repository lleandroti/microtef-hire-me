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
using Stone.Wpf.Client.Operations;

namespace Stone.Wpf.Client.Pages.Transacoes
{
    /// <summary>
    /// Interaction logic for ConsultaTransacoes.xaml
    /// </summary>
    public partial class ConsultaTransacoes : Window
    {
        public ConsultaTransacoes()
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

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            CarregarTransacoes();
        }

        private void CarregarTransacoes()
        {
            var inicioPeriodo = DateTime.Now;
            var terminoPeriodo = DateTime.Now;

            lvTransacoes.ItemsSource = ApiService.ListarTransacoesPorPeriodo(inicioPeriodo, terminoPeriodo);
        }
    }
}
