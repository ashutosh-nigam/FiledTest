using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiledTest.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentsInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CardHolder = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentsStatuses_PaymentsInfo_PaymentInfoId",
                        column: x => x.PaymentInfoId,
                        principalTable: "PaymentsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsStatuses_PaymentInfoId",
                table: "PaymentsStatuses",
                column: "PaymentInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentsStatuses");

            migrationBuilder.DropTable(
                name: "PaymentsInfo");
        }
    }
}
