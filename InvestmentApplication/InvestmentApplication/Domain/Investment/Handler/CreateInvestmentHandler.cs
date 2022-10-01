using CSharpFunctionalExtensions;
using InvestmentApplication.Domain.Investment.Commands;
using InvestmentApplication.Domain.Investment.Infrastructure.Repository;
using InvestmentApplication.Domain.Investment.Model;
using InvestmentApplication.Domain.Investment.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentApplication.Domain.Investment.Handler
{
    public sealed class CreateInvestmentHandler : IRequestHandler<CreateInvestmentCommand, Result>
    {
        private readonly InvestmentService _investmentService;
        private readonly InvestmentRepository _investmentRepository;

        public CreateInvestmentHandler(InvestmentService investmentService, InvestmentRepository investmentRepository)
        {
            _investmentService = investmentService;
            _investmentRepository = investmentRepository;
        }

        public async Task<Result> Handle(CreateInvestmentCommand request, CancellationToken cancellationToken)
        {
            var investment = InvestmentEntity.Create(request);
            if (investment.IsFailure)
                return Result.Failure(investment.Error);

            // Método de validação
            var validation = await _investmentService.ValidationCreation(investment.Value, cancellationToken);
            if (validation.IsSuccess)
            {
                await _investmentRepository.AddAsync(investment.Value, cancellationToken);
                await _investmentRepository.CommitAsync(cancellationToken);
                return validation;
            }

            return Result.Failure(validation.Error);
        }
    }
}
