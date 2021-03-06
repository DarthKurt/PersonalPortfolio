﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonalPortfolio.Shared.Storage.SqlServer.Configurations
{
    internal class CurrencyRateConfiguration : CurrencyLinkedEntityConfiguration<CurrencyRate>
    {
        public override void Configure(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.ToTable("CurrencyRates");

            builder.HasAlternateKey(u => new {u.DataSourceId, u.SourceCurrencyId, u.CurrencyId, u.RateTime });
            builder.Property(p => p.RateTime)
                .HasColumnType(Constants.Date)
                .IsRequired();

            builder.HasOne(rate => rate.SourceCurrency)
                .WithMany(symbol => symbol.Rates)
                .HasForeignKey(security => security.SourceCurrencyId)
                .OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}