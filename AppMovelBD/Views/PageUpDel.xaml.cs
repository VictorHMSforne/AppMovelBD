using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMovelBD.Models;//adicionei
using AppMovelBD.Controller;//adicionei

namespace AppMovelBD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageUpDel : ContentPage
    {
        public Pessoa pessoa;
        public PageUpDel()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = this.pessoa;
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            MySQLCon.AtualizarPessoa(pessoa);
            DisplayAlert("Edição", "Pessoa Atualizada com Sucesso!", "Ok");
            Navigation.PopAsync();//Pesquisar o que significa PopAsync
        }

        private void btnExcluir_Clicked(object sender, EventArgs e)
        {
            if (pessoa.id != 0)
            {
                MySQLCon.ExcluirPessoa(pessoa);
                DisplayAlert("Exclusão", "Pessoa Excluída com Sucesso!", "OK");
                Navigation.PopAsync();
            }
        }
    }
}