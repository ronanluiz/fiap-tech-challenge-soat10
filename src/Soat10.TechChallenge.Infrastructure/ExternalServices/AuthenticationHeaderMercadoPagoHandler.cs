using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public class AuthenticationHeaderMercadoPagoHandler : DelegatingHandler
    {
        private readonly IConfiguration _configuration;
        public AuthenticationHeaderMercadoPagoHandler(IConfiguration configuration) => _configuration = configuration;
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = _configuration["PaymentService:Token"];

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
