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

namespace Stone.Wpf.Client.Pages.Acessos
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
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

                //var menu = new MenuPrincipal();
                //menu.Show();
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
