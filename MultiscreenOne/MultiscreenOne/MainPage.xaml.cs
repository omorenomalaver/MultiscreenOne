using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultiscreenOne
{
    public partial class MainPage : ContentPage
    {
        string translatedNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnCall(object sender, EventArgs e)
        {

            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    App.PhoneNumbers.Add(translatedNumber);
                    callHistoryButton.IsEnabled = true;
                    dialer.Dial(translatedNumber);
                }
            }

        }

        async void OnCallHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallHistoryPage());
        }

    }

}
