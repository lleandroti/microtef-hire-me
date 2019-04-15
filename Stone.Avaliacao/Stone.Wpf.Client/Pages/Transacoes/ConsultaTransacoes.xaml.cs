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
using Stone.Framework.Resources;
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

            Application.Current.MainWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Show();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            CarregarTransacoes();
        }

        private void CarregarTransacoes()
        {
            var inicioPeriodo = DateTime.Now;
            var terminoPeriodo = DateTime.Now;

            try
            {
                lvTransacoes.ItemsSource = ApiService.ListarTransacoesPorPeriodo(inicioPeriodo, terminoPeriodo);
            }
            catch (Exception ex)
            {
                var mensagem = string.Format("{0}\n{1}", ex.Message,
                    ex.InnerException != null ? ex.InnerException.Message : string.Empty);

                MessageBox.Show(mensagem, Textos.Aviso);
            }
        }
    }
}
