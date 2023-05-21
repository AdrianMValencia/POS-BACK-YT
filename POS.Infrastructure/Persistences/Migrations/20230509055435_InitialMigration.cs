using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Infrastructure.Persistences.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Abbreviation = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    State = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Icon = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    URL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    FatherId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    AuthType = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK__Provinces__Depar__52593CB8",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    AuditCreateUser = table.Column<int>(type: "int", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<int>(type: "int", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<int>(type: "int", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK__Clients__Documen__4BAC3F29",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "DocumentTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                    table.ForeignKey(
                        name: "FK__Providers__Docum__5165187F",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "DocumentTypeId");
                });

            migrationBuilder.CreateTable(
                name: "MenuRoles",
                columns: table => new
                {
                    MenuRolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MenuRole__6640AD0CBAEE6AD9", x => x.MenuRolId);
                    table.ForeignKey(
                        name: "FK_MenuRoles_Menu",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                    table.ForeignKey(
                        name: "FK_MenuRoles_Roles",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    AuditCreateUser = table.Column<int>(type: "int", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<int>(type: "int", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<int>(type: "int", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK__Sales__ClientId__59063A47",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK__Sales__UserId__59FA5E80",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    AuditCreateUser = table.Column<int>(type: "int", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<int>(type: "int", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<int>(type: "int", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__Products__Catego__4F7CD00D",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK__Products__Provid__5070F446",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId");
                });

            migrationBuilder.CreateTable(
                name: "Purcharses",
                columns: table => new
                {
                    PurcharseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PurcharseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    AuditCreateUser = table.Column<int>(type: "int", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<int>(type: "int", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<int>(type: "int", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purcharses", x => x.PurcharseId);
                    table.ForeignKey(
                        name: "FK__Purcharse__Provi__5535A963",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId");
                    table.ForeignKey(
                        name: "FK__Purcharse__UserI__5629CD9C",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Ruc = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    BusinessName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Logo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Phone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Vision = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Mision = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK__Business__Distri__4AB81AF0",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId");
                });

            migrationBuilder.CreateTable(
                name: "SaleDetails",
                columns: table => new
                {
                    SaleDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AuditCreateUser = table.Column<int>(type: "int", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<int>(type: "int", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<int>(type: "int", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetails", x => x.SaleDetailId);
                    table.ForeignKey(
                        name: "FK__SaleDetai__Produ__571DF1D5",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK__SaleDetai__SaleI__5812160E",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId");
                });

            migrationBuilder.CreateTable(
                name: "PurcharseDetails",
                columns: table => new
                {
                    PurcharseDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurcharseId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AuditCreateUser = table.Column<int>(type: "int", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<int>(type: "int", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<int>(type: "int", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurcharseDetails", x => x.PurcharseDetailId);
                    table.ForeignKey(
                        name: "FK__Purcharse__Produ__534D60F1",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK__Purcharse__Purch__5441852A",
                        column: x => x.PurcharseId,
                        principalTable: "Purcharses",
                        principalColumn: "PurcharseId");
                });

            migrationBuilder.CreateTable(
                name: "BranchOffices",
                columns: table => new
                {
                    BranchOfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.BranchOfficeId);
                    table.ForeignKey(
                        name: "FK__BranchOff__Busin__48CFD27E",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId");
                    table.ForeignKey(
                        name: "FK__BranchOff__Distr__49C3F6B7",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    BranchOfficeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK__UserRoles__Branc__5AEE82B9",
                        column: x => x.BranchOfficeId,
                        principalTable: "BranchOffices",
                        principalColumn: "BranchOfficeId");
                    table.ForeignKey(
                        name: "FK__UserRoles__RoleI__5BE2A6F2",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK__UserRoles__UserI__5CD6CB2B",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UsersBranchOffices",
                columns: table => new
                {
                    UserBranchOfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchOfficeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsersBra__7D1E804AEC27F567", x => x.UserBranchOfficeId);
                    table.ForeignKey(
                        name: "FK__UsersBran__Branc__5DCAEF64",
                        column: x => x.BranchOfficeId,
                        principalTable: "BranchOffices",
                        principalColumn: "BranchOfficeId");
                    table.ForeignKey(
                        name: "FK__UsersBran__UserI__5EBF139D",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchOffices_BusinessId",
                table: "BranchOffices",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOffices_DistrictId",
                table: "BranchOffices",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_DistrictId",
                table: "Business",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DocumentTypeId",
                table: "Clients",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ProvinceId",
                table: "Districts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRoles_MenuId",
                table: "MenuRoles",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRoles_RoleId",
                table: "MenuRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderId",
                table: "Products",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_DocumentTypeId",
                table: "Providers",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_DepartmentId",
                table: "Provinces",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurcharseDetails_ProductId",
                table: "PurcharseDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurcharseDetails_PurcharseId",
                table: "PurcharseDetails",
                column: "PurcharseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purcharses_ProviderId",
                table: "Purcharses",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Purcharses_UserId",
                table: "Purcharses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_ProductId",
                table: "SaleDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_SaleId",
                table: "SaleDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientId",
                table: "Sales",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_BranchOfficeId",
                table: "UserRoles",
                column: "BranchOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBranchOffices_BranchOfficeId",
                table: "UsersBranchOffices",
                column: "BranchOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBranchOffices_UserId",
                table: "UsersBranchOffices",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuRoles");

            migrationBuilder.DropTable(
                name: "PurcharseDetails");

            migrationBuilder.DropTable(
                name: "SaleDetails");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UsersBranchOffices");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Purcharses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BranchOffices");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
