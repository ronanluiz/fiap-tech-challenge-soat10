namespace Soat10.TechChallenge.Application.UseCases.GetStatusOrders
{
    public class GetStatusOrdersResponse
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public GetStatusOrdersResponse(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
