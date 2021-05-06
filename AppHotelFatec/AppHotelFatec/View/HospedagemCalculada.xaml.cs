using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotelFatec.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HospedagemCalculada : ContentPage
    {
        public HospedagemCalculada()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Oooops", ex.Message, "OK");
            }
        }
    }
}