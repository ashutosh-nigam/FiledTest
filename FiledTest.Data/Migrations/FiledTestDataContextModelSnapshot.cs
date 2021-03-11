﻿// <auto-generated />
using System;
using FiledTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FiledTest.Data.Migrations
{
    [DbContext(typeof(FiledTestDataContext))]
    partial class FiledTestDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FiledTest.Data.DataModels.PaymentInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardHolder")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("CreditCardNumber")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PaymentsInfo");
                });

            modelBuilder.Entity("FiledTest.Data.DataModels.PaymentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PaymentInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentInfoId");

                    b.ToTable("PaymentsStatuses");
                });

            modelBuilder.Entity("FiledTest.Data.DataModels.PaymentStatus", b =>
                {
                    b.HasOne("FiledTest.Data.DataModels.PaymentInfo", "PaymentInfo")
                        .WithMany("PaymentStatuses")
                        .HasForeignKey("PaymentInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentInfo");
                });

            modelBuilder.Entity("FiledTest.Data.DataModels.PaymentInfo", b =>
                {
                    b.Navigation("PaymentStatuses");
                });
#pragma warning restore 612, 618
        }
    }
}
