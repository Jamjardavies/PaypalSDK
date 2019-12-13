using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Paypal;
using Paypal.Sync;
using RestSharp;
using Xamarin.Forms;

namespace PaypalTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string ClientId = "AXB1-y7WRDgoqLlY55TX4SJXZe_H1E_eh9znHv6_JCeU3H92frkVqOoEjsSAi3bIJbh-Lm3mbKhAyzDN";
        private const string ClientSecret = "EOVJvijci_ZMPe47JtzLVb3dUeGGSLz4YJD3dn21rnfG1ta6UhZpEzWrZlbKdxEan0WOAwhlo8xys6Ra";

        private readonly MainPageViewModel m_vm;

        public MainPage()
        {
            m_vm = new MainPageViewModel(ClientId, ClientSecret);

            BindingContext = m_vm;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            m_vm.GetTransactions();
        }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private static readonly List<string> ValidCodes = new List<string> { "T0004", "T0007" };

        private readonly PaypalClient m_paypal = null;
        private Transactions m_details = null;

        public Transactions Details
        {
            get => m_details;
            set
            {
                if (Equals(value, m_details)) return;
                m_details = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel(string clientId, string clientSecret)
        {
            m_paypal = new PaypalClient(new LiveEnvironment(clientId, clientSecret));
        }

        public async void GetTransactions()
        {
            DateTime end = DateTime.Now;
            //DateTime end = new DateTime(2019, 9, 8);
            DateTime start = end - TimeSpan.FromDays(5);

            SearchGetResults search = new SearchGetResults()
                                      .StartDate(start)
                                      .EndDate(end)
                                      .Fields("all");

            IRestResponse<Transactions> data = await m_paypal.ExecuteTaskAsync<Transactions>(search);

            // Clear up data.
            List<TransactionDetails> itemsToRemove = new List<TransactionDetails>();

            foreach (TransactionDetails item in data.Data.TransactionDetails)
            {
                if (!ValidCodes.Contains(item.TransactionInfo.TransactionEventCode) ||
                    item.TransactionInfo.TransactionAmount.Value.Contains("-"))
                {
                    itemsToRemove.Add(item);
                }
            }

            foreach (TransactionDetails item in itemsToRemove)
            {
                data.Data.TransactionDetails.Remove(item);
            }

            Details = data.Data;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
