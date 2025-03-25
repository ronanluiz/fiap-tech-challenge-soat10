using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Controllers;

namespace Soat10.TechChallenge.API.Endpoints
{
    public static class IdentityEndpoints
    {
        public static void MapIdentityEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/identify/{cpf}", async (string cpf, IDataRepository dataRepository) =>
            {
                if (string.IsNullOrWhiteSpace(cpf))
                {
                    return Results.BadRequest("O CPF deve ser informado.");
                }

                IdentifyResponse identifyResponse = await IdentityController.Build(dataRepository)
                                                                             .GetIdentity(cpf);

                return Results.Ok(identifyResponse);
            })
                .WithName("Identity")
                .WithSummary("Realiza identificação de um cliente cadastrado.")
                .WithDescription("Este endpoint retorna dados do cliente identificado.");
        }
    }
}
