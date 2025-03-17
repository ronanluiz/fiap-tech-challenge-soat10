using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class PaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context) => _context = context;

        public async Task<int> AddAsync(PaymentDao payment)
        {
            payment.Order = null;
            await _context.Payments.AddAsync(payment);
            return await _context.SaveChangesAsync();
        }
    }
}
