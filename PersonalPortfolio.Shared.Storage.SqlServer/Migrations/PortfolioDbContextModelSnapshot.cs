﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PersonalPortfolio.Shared.Storage.SqlServer.Migrations
{
    [DbContext(typeof(PortfolioDbContext))]
    public class PortfolioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalPortfolio.Shared.Storage.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("sysdatetime()");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2(2)");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300)
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("PersonalPortfolio.Shared.Storage.CurrencyRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("DataSourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("sysdatetime()");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2(2)");

                    b.Property<DateTime>("RateTime")
                        .HasColumnType("date");

                    b.Property<int>("SourceCurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasAlternateKey("DataSourceId", "SourceCurrencyId", "CurrencyId", "RateTime");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("SourceCurrencyId");

                    b.ToTable("CurrencyRates");
                });

            modelBuilder.Entity("PersonalPortfolio.Shared.Storage.Security", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseCurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("sysdatetime()");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2(2)");

                    b.Property<string>("Ticker")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300)
                        .HasDefaultValue("");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrencyId");

                    b.HasIndex("TypeId");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("PersonalPortfolio.Shared.Storage.SecurityPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Average")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Close")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("High")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Low")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Open")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SecurityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TradeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SecurityId");

                    b.ToTable("SecurityPrice");
                });

            modelBuilder.Entity("PersonalPortfolio.Shared.Storage.SecurityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(2)")
                        .HasDefaultValueSql("sysdatetime()");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2(2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecurityTypes");
                });

            modelBuilder.Entity("PersonalPortfolio.Shared.Storage.CurrencyRate", b =>
                {
                    b.HasOne("PersonalPortfolio.Shared.Storage.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PersonalPortfolio.Shared.Storage.Currency", "SourceCurrency")
                        .WithMany("Rates")
                        .HasForeignKey("SourceCurrencyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalPortfolio.Shared.Storage.Security", b =>
                {
                    b.HasOne("PersonalPortfolio.Shared.Storage.Currency", "BaseCurrency")
                        .WithMany()
                        .HasForeignKey("BaseCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalPortfolio.Shared.Storage.SecurityType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalPortfolio.Shared.Storage.SecurityPrice", b =>
                {
                    b.HasOne("PersonalPortfolio.Shared.Storage.Security", "Security")
                        .WithMany("Prices")
                        .HasForeignKey("SecurityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}