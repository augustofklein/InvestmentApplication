using CSharpFunctionalExtensions;
using InvestmentApplication.Domain.Investment.Commands;
using System;

namespace InvestmentApplication.WebApi.Models.Investment
{
    public class CreateInvestmentInputModel
    {
        public int InvestmentId { get; private set; }
        public string AssetName { get; private set; }
        public DateTime OperationDate { get; private set; }
        public char OperationType { get; private set; }
        public decimal OperationAmount { get; private set; }
        public decimal AssetUnitPrice { get; private set; }
        public decimal TransactionTaxes { get; private set; }

        public CreateInvestmentInputModel(int investmentId, string assetName, DateTime operationDate, char operationType, decimal operationAmount, decimal assetUnitPrice, decimal transactionTaxes)
        {
            InvestmentId = investmentId;
            AssetName = assetName;
            OperationDate = operationDate;
            OperationType = operationType;
            OperationAmount = operationAmount;
            AssetUnitPrice = assetUnitPrice;
            TransactionTaxes = transactionTaxes;
        }

        public Result<CreateInvestmentCommand> CreateCommand()
        {
            var investmentApplicationCommand = new CreateInvestmentCommand(investmentId, AssetName, OperationDate, OperationType, OperationAmount, AssetUnitPrice, TransactionTaxes);
            return investmentApplicationCommand;
        }
    }
}
