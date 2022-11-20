using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var mainViewModel = new MainViewModel();
            BindingContext = mainViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            AddBtn.Background = clickedButton.Background;
        }
    }
}
