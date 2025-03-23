using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class PaymentNotificationDataRequest
    {
        [JsonPropertyName("id")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Id { get; set; }
    }
}
