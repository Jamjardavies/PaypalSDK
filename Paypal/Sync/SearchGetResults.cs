using System;
using RestSharp;

namespace Paypal.Sync
{
    public class SearchGetResults : RestRequest
    {
        public SearchGetResults()
            : base("/v1/reporting/transactions", Method.GET)
        {
            AddQueryParameter("page_size", "500");
        }

        public SearchGetResults StartDate(DateTime date)
        {
            AddQueryParameter("start_date", $"{date:yyyy-MM-dd}T{date:HH:mm:ss}-0000");
            return this;
        }

        public SearchGetResults EndDate(DateTime date)
        {
            AddQueryParameter("end_date", $"{date:yyyy-MM-dd}T{date:HH:mm:ss}-0000");
            return this;
        }

        public SearchGetResults Fields(string fields)
        {
            AddQueryParameter("fields", fields);
            return this;
        }
    }
}
