using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMovelBD.Controller;//adicionei
using AppMovelBD.Models;//adicionei

namespace AppMovelBD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lstPessoas.ItemsSource = MySQLCon.ListarPessoas();
        }
        void NavegarPessoa(Pessoa pessoa)
        {
            PageUpDel upDel = new PageUpDel();
            upDel.pessoa = pessoa;
            Navigation.PushAsync(upDel);
        }

        private void lstPessoas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarPessoa(e.SelectedItem as Pessoa);
        }

        private void btnNovo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageCadastrar());
        }
    }
}