using Stone.Wpf.Client.Pages;
using System;
using System.Windows;
using Stone.Framework.Resources;
using Stone.Wpf.Client.Operations;
using Stone.Wpf.Client.Pages.Transacoes;

namespace Stone.Wpf.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnNovaTransacao_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            var menu = new NovaTransacao();
            menu.Show();
        }

        private void btnConsultaTransacoes_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            var menu = new ConsultaTransacoes();
            menu.Show();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
