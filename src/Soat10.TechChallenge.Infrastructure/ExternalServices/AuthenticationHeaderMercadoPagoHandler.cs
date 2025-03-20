using System.Net.Http.Headers;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public class AuthenticationHeaderMercadoPagoHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = "APP_USR-3827549426311414-031406-158f43d497651f357ee417d643de1caf-2309279098";

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
