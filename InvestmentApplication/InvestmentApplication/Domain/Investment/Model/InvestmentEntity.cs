using CSharpFunctionalExtensions;
using InvestmentApplication.Domain.Investment.Commands;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentApplication.Domain.Investment.Model
{
    public class InvestmentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int InvestmentId { get; private set; }
        public string AssetName { get; private set; }
        public DateTime OperationDate { get; private set; }
        public char OperationType { get; private set; }
        public decimal OperationAmount { get; private set; }
        public decimal AssetUnitPrice { get; private set; }
        public decimal TransactionTaxes { get; private set; }

        public InvestmentEntity(int investmentId, string assetName, DateTime operationDate, char operationType, decimal operationAmount, decimal assetUnitPrice, decimal transactionTaxes)
        {
            InvestmentId = investmentId;
            AssetName = assetName;
            OperationDate = operationDate;
            OperationType = operationType;
            OperationAmount = operationAmount;
            AssetUnitPrice = assetUnitPrice;
            TransactionTaxes = transactionTaxes;
        }

        public static Result<InvestmentEntity> Create(CreateInvestmentCommand createInvestmentCommand)
        {
            return new InvestmentEntity(0,
                                        createInvestmentCommand.AssetName,
                                        createInvestmentCommand.OperationDate,
                                        createInvestmentCommand.OperationType,
                                        createInvestmentCommand.OperationAmount,
                                        createInvestmentCommand.AssetUnitPrice,
                                        createInvestmentCommand.TransactionTaxes);
        }
    }
}
