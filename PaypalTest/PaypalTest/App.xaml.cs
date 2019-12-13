using Xamarin.Forms;

namespace PaypalTest
{
    public partial class App : Application
    {
        protected override void OnStart()
        {
            base.OnStart();

            MainPage = new MainPage();
            InitializeComponent();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
