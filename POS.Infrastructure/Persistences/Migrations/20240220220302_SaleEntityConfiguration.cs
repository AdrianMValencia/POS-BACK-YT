using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Infrastructure.Persistences.Migrations
{
    public partial class SaleEntityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__SaleDetai__SaleI__5812160E",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Products_ProductId",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__Sales__UserId__59FA5E80",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleDetails",
                table: "SaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetails_SaleId",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "SaleDate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SaleDetailId",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "AuditCreateDate",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "AuditCreateUser",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "AuditDeleteDate",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "AuditDeleteUser",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "AuditUpdateDate",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "AuditUpdateUser",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SaleDetails");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Igv",
                table: "Sales",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Sales",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Sales",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "VoucherDocumentTypeId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VoucherNumber",
                table: "Sales",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "SaleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "SaleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SaleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "SaleDetails",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitSalePrice",
                table: "SaleDetails",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleDetails",
                table: "SaleDetails",
                columns: new[] { "SaleId", "ProductId" });

            migrationBuilder.CreateTable(
                name: "VoucherDocumentTypes",
                columns: table => new
                {
                    VoucherDocumentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    AuditCreateUser = table.Column<int>(type: "int", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<int>(type: "int", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<int>(type: "int", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherDocumentTypes", x => x.VoucherDocumentTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_VoucherDocumentTypeId",
                table: "Sales",
                column: "VoucherDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_WarehouseId",
                table: "Sales",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Products_ProductId",
                table: "SaleDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_VoucherDocumentTypes_VoucherDocumentTypeId",
                table: "Sales",
                column: "VoucherDocumentTypeId",
                principalTable: "VoucherDocumentTypes",
                principalColumn: "VoucherDocumentTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Warehouses_WarehouseId",
                table: "Sales",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Products_ProductId",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_VoucherDocumentTypes_VoucherDocumentTypeId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Warehouses_WarehouseId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "VoucherDocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Sales_VoucherDocumentTypeId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_WarehouseId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleDetails",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "Igv",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "VoucherDocumentTypeId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "VoucherNumber",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "UnitSalePrice",
                table: "SaleDetails");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "SaleDate",
                table: "Sales",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "SaleDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SaleDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "SaleDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SaleDetailId",
                table: "SaleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditCreateDate",
                table: "SaleDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AuditCreateUser",
                table: "SaleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditDeleteDate",
                table: "SaleDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditDeleteUser",
                table: "SaleDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditUpdateDate",
                table: "SaleDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditUpdateUser",
                table: "SaleDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "SaleDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SaleDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleDetails",
                table: "SaleDetails",
                column: "SaleDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_SaleId",
                table: "SaleDetails",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK__SaleDetai__SaleI__5812160E",
                table: "SaleDetails",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Products_ProductId",
                table: "SaleDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK__Sales__UserId__59FA5E80",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId");
        }
    }
}
