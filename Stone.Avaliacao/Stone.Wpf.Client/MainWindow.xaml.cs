using Stone.Wpf.Client.Pages;
using System;
using System.Windows;
using Stone.Framework.Resources;
using Stone.Wpf.Client.Operations;

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

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            bool resultado;

            try
            {
                resultado = ApiService.AutenticarCliente(txtCliente.Text, txtSenha.Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Textos.Aviso);
                return;
            }

            if (resultado)
            {
                Hide();

                var menu = new MenuPrincipal();
                menu.Show();
            }
            else
            {
                MessageBox.Show(Mensagens.ClienteNaoAutenticado, Textos.Aviso);
            }
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
