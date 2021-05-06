using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Globalization;
using System.Collections.Generic;

using AppHotelFatec.View;
using AppHotelFatec.Model;

namespace AppHotelFatec
{
    public partial class App : Application
    {
        /**
         * Listando todos os quartos disponíveis no hotel
         */
        public List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto()
            {
                Descricao = "Suíte Super Luxo",
                ValorDiariaAdulto = 110.0,
                ValorDiariaCrianca = 55.0
            },
            new Quarto()
            {
                Descricao = "Suíte Luxo",
                ValorDiariaAdulto = 80.0,
                ValorDiariaCrianca = 40.0
            },
            new Quarto()
            {
                Descricao = "Suíte Single",
                ValorDiariaAdulto = 50.0,
                ValorDiariaCrianca = 25.0
            },
            new Quarto()
            {
                Descricao = "Suíte Crise",
                ValorDiariaAdulto = 25.0,
                ValorDiariaCrianca = 12.5            
            }
        };



        public App()
        {
            InitializeComponent();

            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            MainPage = new NavigationPage(new ContratacaoHospedagem());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
