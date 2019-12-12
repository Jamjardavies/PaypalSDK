using System;
using RestSharp.Authenticators;

namespace Paypal.Authentication
{
    public class BasicAuthentication : HttpBasicAuthenticator
    {
        public BasicAuthentication(string clientId, string clientSecret) : base(clientId, clientSecret) { }
    }
}
