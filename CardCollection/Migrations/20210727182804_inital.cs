using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardCollection.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rarity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberInSet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Illustrator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    supertype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hp = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvailableTrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableTrades_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardUser",
                columns: table => new
                {
                    OwnedCardsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardUser", x => new { x.OwnedCardsId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_CardUser_Cards_OwnedCardsId",
                        column: x => x.OwnedCardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardUser_Users_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardTrade",
                columns: table => new
                {
                    CardsOfferedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TradeOffersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTrade", x => new { x.CardsOfferedId, x.TradeOffersId });
                    table.ForeignKey(
                        name: "FK_CardTrade_AvailableTrades_TradeOffersId",
                        column: x => x.TradeOffersId,
                        principalTable: "AvailableTrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardTrade_Cards_CardsOfferedId",
                        column: x => x.CardsOfferedId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tradeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AvailableTrades_tradeId",
                        column: x => x.tradeId,
                        principalTable: "AvailableTrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardRequest",
                columns: table => new
                {
                    RequestedCardsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardRequest", x => new { x.RequestedCardsId, x.RequestsId });
                    table.ForeignKey(
                        name: "FK_CardRequest_Cards_RequestedCardsId",
                        column: x => x.RequestedCardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardRequest_Requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTrades_userId",
                table: "AvailableTrades",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_CardRequest_RequestsId",
                table: "CardRequest",
                column: "RequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTrade_TradeOffersId",
                table: "CardTrade",
                column: "TradeOffersId");

            migrationBuilder.CreateIndex(
                name: "IX_CardUser_OwnersId",
                table: "CardUser",
                column: "OwnersId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_tradeId",
                table: "Requests",
                column: "tradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardRequest");

            migrationBuilder.DropTable(
                name: "CardTrade");

            migrationBuilder.DropTable(
                name: "CardUser");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "AvailableTrades");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
