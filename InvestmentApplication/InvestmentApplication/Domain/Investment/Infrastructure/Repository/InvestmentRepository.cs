using InvestmentApplication.Domain.Investment.Model;
using InvestmentApplication.Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentApplication.Domain.Investment.Infrastructure.Repository
{
    public class InvestmentRepository
    {
        private readonly InvestmentApplicationManagerDbContext _investmentApplicationManagerDbContext;

        public InvestmentRepository(InvestmentApplicationManagerDbContext investmentApplicationManagerDbContext)
        {
            _investmentApplicationManagerDbContext = investmentApplicationManagerDbContext;
        }

        public async Task AddAsync(InvestmentEntity investmentEntity, CancellationToken cancellationToken = default)
        {
            await _investmentApplicationManagerDbContext.AddAsync(investmentEntity, cancellationToken);
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            var response = await _investmentApplicationManagerDbContext.SaveChangesAsync(cancellationToken);
            return response > 0;
        }
    }
}
