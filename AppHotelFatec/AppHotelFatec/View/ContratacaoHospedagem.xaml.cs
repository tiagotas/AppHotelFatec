using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppHotelFatec.Model;

namespace AppHotelFatec.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContratacaoHospedagem : ContentPage
    {

        App PropriedadesApp;

        public ContratacaoHospedagem()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;

            //NavigationPage.SetHasNavigationBar(this, false);

            // carregando os quartos do array de objetos no picker
            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

            // Definindo as datas máximas e minimas de check-in
            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 2, DateTime.Now.Day);

            // Definindo a data minima do check-out
            dtpck_checkout.MinimumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                int qnt_adultos = Convert.ToInt32(lbl_qnt_adultos.Text);
                int qnt_criancas = Convert.ToInt32(lbl_qnt_criancas.Text);

                if (qnt_adultos == 0 && qnt_criancas == 0)
                    throw new Exception("Informe ao menos um adulto ou uma criança.");

                // Definindo o quarto selecionado.
                Quarto acomodacao_selecionada = (Quarto)pck_quarto.SelectedItem;


                // Criando o objeto que contém a hospedagem
                Hospedagem dados_hospedagem = new Hospedagem()
                {
                    Acomodacao = acomodacao_selecionada,

                    QuantidadeAdultos = qnt_adultos,
                    QuantidadeCriancas = qnt_criancas,

                    DataCheckin = dtpck_checkin.Date,
                    DataCheckout = dtpck_checkout.Date                    
                };

                // "Anexando" o objeto hospedagem e enviando para a tela seguinte.
                HospedagemCalculada segundaTela = new HospedagemCalculada();
                segundaTela.BindingContext = dados_hospedagem;

                // Navegando de tela.
                Navigation.PushAsync(segundaTela);

            } catch(Exception ex)
            {
                DisplayAlert("Oooops", ex.Message, "OK");
            }
        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker elemento = (DatePicker)sender;

            DateTime data_checkin = elemento.Date;

            dtpck_checkout.MinimumDate = new DateTime(data_checkin.Year, data_checkin.Month, data_checkin.Day + 1);
        }
    }
}