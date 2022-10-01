using CSharpFunctionalExtensions;
using InvestmentApplication.Domain.Investment.Infrastructure.Repository;
using InvestmentApplication.Domain.Investment.Model;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentApplication.Domain.Investment.Service
{
    public class InvestmentService
    {
        private readonly InvestmentRepository _investmentRepository;

        public InvestmentService(InvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        public async Task<Result> ValidationCreation(InvestmentEntity investmentEntity, CancellationToken cancellationToken)
        {
            return Result.Success();
        }
    }
}
