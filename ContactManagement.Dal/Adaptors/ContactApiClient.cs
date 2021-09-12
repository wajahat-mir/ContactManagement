using ContactManagement.Dal.Interfaces;
using System.Net.Http;

namespace ContactManagement.Dal.Adaptors
{
    public class ContactApiClient : ApiClient, IContactApiClient
    {
        public ContactApiClient(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
