using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace InvestmentApplication.Domain.Investment.Commands
{
    public sealed class CreateInvestmentCommand : IRequest<Result>
    {
        public int InvestmentId { get; private set; }
        public string AssetName { get; private set; }
        public DateTime OperationDate { get; private set; }
        public char OperationType { get; private set; }
        public decimal OperationAmount { get; private set; }
        public decimal AssetUnitPrice { get; private set; }
        public decimal TransactionTaxes { get; private set; }

        public CreateInvestmentCommand(int investmentId, string assetName, DateTime operationDate, char operationType, decimal operationAmount, decimal assetUnitPrice, decimal transactionTaxes)
        {
            InvestmentId = investmentId;
            AssetName = assetName;
            OperationDate = operationDate;
            OperationType = operationType;
            OperationAmount = operationAmount;
            AssetUnitPrice = assetUnitPrice;
            TransactionTaxes = transactionTaxes;
        }
    }
}
