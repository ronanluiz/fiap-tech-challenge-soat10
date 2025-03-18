using Microsoft.EntityFrameworkCore;
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

        public async Task<PaymentDao> GetByOrder(Guid orderId)
        {
            return await _context.Payments
                                .FirstOrDefaultAsync(p => p.Order.Id == orderId);
        }
        public async Task<int> UpdateAsync(PaymentDao paymentDao)
        {
            var current = _context.Payments.Local.FirstOrDefault(e => e.Id == paymentDao.Id);
            if (current != null)
            {
                _context.Entry(current).State = EntityState.Detached;
            }

            _context.Update(paymentDao);
            var saveChanges = await _context.SaveChangesAsync();

            return saveChanges;

        }
    }
}
