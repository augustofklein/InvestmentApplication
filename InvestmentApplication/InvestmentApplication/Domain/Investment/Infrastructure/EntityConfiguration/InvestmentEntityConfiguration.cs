using InvestmentApplication.Domain.Investment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentApplication.Domain.Investment.Infrastructure.EntityConfiguration
{
    public class InvestmentEntityConfiguration : IEntityTypeConfiguration<InvestmentEntity>
    {
        public void Configure(EntityTypeBuilder<InvestmentEntity> builder)
        {
            builder.ToTable("Investment").HasKey(investment => investment.InvestmentId);

            builder.Property(investment => investment.AssetName).HasColumnName("asset_name");
            builder.Property(investment => investment.OperationDate).HasColumnName("operation_date");
            builder.Property(investment => investment.OperationType).HasColumnName("operation_type");
            builder.Property(investment => investment.OperationAmount).HasColumnName("operation_amount");
            builder.Property(investment => investment.AssetUnitPrice).HasColumnName("asset_unit_price");
            builder.Property(investment => investment.TransactionTaxes).HasColumnName("transaction_taxes");
        }
    }
}
