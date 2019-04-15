using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Stone.Domain.Model.Enumerables;
using Stone.Domain.Models;
using Stone.Domain.Models.Adapters;
using Stone.Framework.Extensao;
using Stone.Framework.Resources;
using Stone.Wpf.Client.Operations;

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

            Application.Current.MainWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Show();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarPreenchimentoDeCampos())
                return;

            if (!ValidarRegrasDePreenchimento())
                return;

            ProcessarNovaTransacao();
        }

        private void ProcessarNovaTransacao()
        {
            try
            {
                decimal valor;
                decimal.TryParse(txtValor.Text, out valor);

                int parcelas;
                int.TryParse(txtParcelas.Text, out parcelas);

                int mes;
                int.TryParse(txtMes.Text, out mes);

                int ano;
                int.TryParse(txtAno.Text, out ano);

                int tipo;
                int.TryParse(cmbTipoTransacao.SelectedValue.ToString(), out tipo);

                int bandeira;
                int.TryParse(cmbBandeira.SelectedValue.ToString(), out bandeira);

                var novaTransacao = new TransacaoCadastroModel
                {
                    Data = txtData.DisplayDate,
                    Valor = valor,
                    Tipo = tipo,
                    Parcelado = chkParcelado.IsChecked != null ? chkParcelado.IsChecked.Value : false,
                    NumeroParcelas = parcelas,
                    NomeTitular = txtPortador.Text,
                    NumeroCartao = txtCartao.Text,
                    Bandeira = bandeira,
                    Chip = chkChip.IsChecked != null ? chkChip.IsChecked.Value : false,
                    ValidadeMes = mes,
                    ValidadeAno = ano,
                    Password = txtSenha.Password
                };

                var retorno = ApiService.CadastrarNovaTRansacao(novaTransacao);

                if (MessageBox.Show(retorno, Textos.Aviso) == MessageBoxResult.OK)
                {
                    Close();

                    Application.Current.MainWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Textos.Aviso);
            }
        }

        public bool ValidarRegrasDePreenchimento()
        {
            if (!Validations.ValidarMesEAnoDeValidadeDoCartao(txtMes.Text, txtAno.Text))
            {
                MessageBox.Show(Mensagens.DataDeValidadeCartaoInvalido, Textos.Aviso);
                return false;
            }

            if (!Validations.ValidarNumeroDoCartao(txtCartao.Text))
            {
                MessageBox.Show(Mensagens.NumeroDeCartaoInvalido, Textos.Aviso);
                return false;
            }

            if (!Validations.ValidarSenhaDoCartao(txtSenha.Password))
            {
                MessageBox.Show(Mensagens.SenhaDeveTerEntre4a6digitos, Textos.Aviso);
                return false;
            }

            return true;
        }

        private bool ValidarPreenchimentoDeCampos()
        {
            if (string.IsNullOrEmpty(txtData.Text))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Data"), Textos.Aviso);
                return false;
            }

            if (string.IsNullOrEmpty(cmbTipoTransacao.Text))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Tipo da Transação"), Textos.Aviso);
                return false;
            }

            if (string.IsNullOrEmpty(txtValor.Text))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Valor"), Textos.Aviso);
                return false;
            }

            if (chkParcelado.IsChecked == true && string.IsNullOrEmpty(txtParcelas.Text))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Nº de Parcelas"), Textos.Aviso);
                return false;
            }

            if (string.IsNullOrEmpty(txtPortador.Text))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Nome do Portador"), Textos.Aviso);
                return false;
            }

            if (string.IsNullOrEmpty(txtCartao.Text))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Nº do Cartão"), Textos.Aviso);
                return false;
            }

            if (string.IsNullOrEmpty(cmbBandeira.Text))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Bandeira"), Textos.Aviso);
                return false;
            }

            if (string.IsNullOrEmpty(txtMes.Text))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Mês de Validade"), Textos.Aviso);
                return false;
            }

            if (string.IsNullOrEmpty(txtAno.Text))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Ano de Validade"), Textos.Aviso);
                return false;
            }

            if (string.IsNullOrEmpty(txtSenha.Password))
            {
                MessageBox.Show(string.Format(Mensagens.CampoXdeveSerPreenchido, "Senha"), Textos.Aviso);
                return false;
            }

            return true;
        }

        private void CarregarCombos()
        {
            cmbTipoTransacao.SelectedValuePath = "Key";
            cmbTipoTransacao.DisplayMemberPath = "Value";
            cmbTipoTransacao.ItemsSource =
                EnumerableHelper.EnumParaListaComDescription<TranscactionType>();

            var bandeiras = ApiService.ListarBandeiras();

            cmbBandeira.SelectedValuePath = "Key";
            cmbBandeira.DisplayMemberPath = "Value";
            cmbBandeira.ItemsSource =
                bandeiras.ToDictionary(x => x.Sequencial.ToString(), x => x.Nome);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtData.SelectedDate = DateTime.Today;

            CarregarCombos();
        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9],.+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
