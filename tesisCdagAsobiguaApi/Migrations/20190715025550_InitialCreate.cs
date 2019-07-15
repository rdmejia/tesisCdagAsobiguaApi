using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tesisCdagAsobiguaApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<byte[]>(type: "binary(64)", nullable: false),
                    UserType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    TrainerId = table.Column<long>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Users_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logins_Users_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shots",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BackstrokePause = table.Column<double>(nullable: false),
                    ShotInterval = table.Column<double>(nullable: false),
                    Jab = table.Column<double>(nullable: false),
                    FollowThrough = table.Column<double>(nullable: false),
                    TipSteer = table.Column<double>(nullable: false),
                    Straightness = table.Column<double>(nullable: false),
                    Finesse = table.Column<double>(nullable: false),
                    Finish = table.Column<double>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    TrainerId = table.Column<long>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shots_Users_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shots_Users_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XyzShots",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Z = table.Column<double>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    ShotId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XyzShots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XyzShots_Shots_ShotId",
                        column: x => x.ShotId,
                        principalTable: "Shots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserType", "Username" },
                values: new object[,]
                {
                    { -1001L, "trainer1@mail.com", "Trainer1Lastname", "Trainer1Name", new byte[] { 125, 241, 139, 69, 209, 209, 155, 97, 148, 174, 244, 131, 176, 198, 211, 118, 249, 163, 204, 146, 95, 42, 145, 154, 172, 20, 158, 50, 209, 26, 22, 101, 35, 62, 232, 53, 148, 47, 233, 160, 27, 59, 1, 47, 130, 217, 118, 13, 75, 225, 72, 227, 94, 161, 9, 8, 90, 63, 228, 154, 134, 225, 83, 162 }, (byte)0, "trainer1" },
                    { -2002L, "player1@mail.com", "Player1Lastname", "Player1Name", new byte[] { 125, 241, 139, 69, 209, 209, 155, 97, 148, 174, 244, 131, 176, 198, 211, 118, 249, 163, 204, 146, 95, 42, 145, 154, 172, 20, 158, 50, 209, 26, 22, 101, 35, 62, 232, 53, 148, 47, 233, 160, 27, 59, 1, 47, 130, 217, 118, 13, 75, 225, 72, 227, 94, 161, 9, 8, 90, 63, 228, 154, 134, 225, 83, 162 }, (byte)1, "player1" },
                    { -3003L, "player2@mail.com", "Player2Lastname", "Player2Name", new byte[] { 125, 241, 139, 69, 209, 209, 155, 97, 148, 174, 244, 131, 176, 198, 211, 118, 249, 163, 204, 146, 95, 42, 145, 154, 172, 20, 158, 50, 209, 26, 22, 101, 35, 62, 232, 53, 148, 47, 233, 160, 27, 59, 1, 47, 130, 217, 118, 13, 75, 225, 72, 227, 94, 161, 9, 8, 90, 63, 228, 154, 134, 225, 83, 162 }, (byte)1, "player2" },
                    { -4004L, "player3@mail.com", "Player3Lastname", "Player3Name", new byte[] { 125, 241, 139, 69, 209, 209, 155, 97, 148, 174, 244, 131, 176, 198, 211, 118, 249, 163, 204, 146, 95, 42, 145, 154, 172, 20, 158, 50, 209, 26, 22, 101, 35, 62, 232, 53, 148, 47, 233, 160, 27, 59, 1, 47, 130, 217, 118, 13, 75, 225, 72, 227, 94, 161, 9, 8, 90, 63, 228, 154, 134, 225, 83, 162 }, (byte)1, "player3" },
                    { -5005L, "trainer2@mail.com", "Trainer2Lastname", "Traine2rName", new byte[] { 125, 241, 139, 69, 209, 209, 155, 97, 148, 174, 244, 131, 176, 198, 211, 118, 249, 163, 204, 146, 95, 42, 145, 154, 172, 20, 158, 50, 209, 26, 22, 101, 35, 62, 232, 53, 148, 47, 233, 160, 27, 59, 1, 47, 130, 217, 118, 13, 75, 225, 72, 227, 94, 161, 9, 8, 90, 63, 228, 154, 134, 225, 83, 162 }, (byte)0, "trainer2" }
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "Id", "PlayerId", "TimeStamp", "TrainerId" },
                values: new object[,]
                {
                    { -1001L, -2002L, new DateTime(2019, 7, 14, 20, 50, 50, 636, DateTimeKind.Local).AddTicks(8600), -1001L },
                    { -3003L, -2002L, new DateTime(2019, 7, 14, 20, 52, 50, 636, DateTimeKind.Local).AddTicks(9170), -1001L },
                    { -5005L, -2002L, new DateTime(2019, 7, 14, 20, 54, 50, 636, DateTimeKind.Local).AddTicks(9180), -1001L },
                    { -2002L, -3003L, new DateTime(2019, 7, 14, 20, 51, 50, 636, DateTimeKind.Local).AddTicks(9160), -1001L },
                    { -4004L, -3003L, new DateTime(2019, 7, 14, 20, 53, 50, 636, DateTimeKind.Local).AddTicks(9170), -1001L },
                    { -6006L, -4004L, new DateTime(2019, 7, 14, 20, 55, 50, 636, DateTimeKind.Local).AddTicks(9180), -5005L }
                });

            migrationBuilder.InsertData(
                table: "Shots",
                columns: new[] { "Id", "BackstrokePause", "Finesse", "Finish", "FollowThrough", "Jab", "PlayerId", "ShotInterval", "Straightness", "TimeStamp", "TipSteer", "TrainerId" },
                values: new object[,]
                {
                    { -1001L, 4.0, 3.0, 0.40000000000000002, 1.0, 3.7000000000000002, -2002L, 5.5999999999999996, 9.1999999999999993, new DateTime(2019, 7, 14, 20, 50, 50, 617, DateTimeKind.Local).AddTicks(9490), 4.4000000000000004, -1001L },
                    { -2002L, 4.0, 3.0, 0.40000000000000002, 1.0, 3.7000000000000002, -3003L, 5.5999999999999996, 9.1999999999999993, new DateTime(2019, 7, 14, 20, 50, 50, 634, DateTimeKind.Local).AddTicks(5190), 4.4000000000000004, -1001L },
                    { -3003L, 4.0, 3.0, 0.40000000000000002, 1.0, 3.7000000000000002, -4004L, 5.5999999999999996, 9.1999999999999993, new DateTime(2019, 7, 14, 20, 50, 50, 634, DateTimeKind.Local).AddTicks(5210), 4.4000000000000004, -1001L },
                    { -4004L, 4.0, 3.0, 0.40000000000000002, 1.0, 3.7000000000000002, -4004L, 5.5999999999999996, 9.1999999999999993, new DateTime(2019, 7, 14, 20, 50, 50, 634, DateTimeKind.Local).AddTicks(5210), 4.4000000000000004, -5005L }
                });

            migrationBuilder.InsertData(
                table: "XyzShots",
                columns: new[] { "Id", "ShotId", "TimeStamp", "X", "Y", "Z" },
                values: new object[,]
                {
                    { -101L, -1001L, new DateTime(2019, 7, 14, 20, 55, 50, 630, DateTimeKind.Local).AddTicks(9460), 0.34000000000000002, -2.3500000000000001, 1.55 },
                    { -202L, -1001L, new DateTime(2019, 7, 14, 20, 55, 50, 632, DateTimeKind.Local).AddTicks(1380), 0.34000000000000002, -2.3500000000000001, 1.55 },
                    { -303L, -1001L, new DateTime(2019, 7, 14, 20, 55, 50, 633, DateTimeKind.Local).AddTicks(1400), 0.34000000000000002, -2.3500000000000001, 1.55 },
                    { -404L, -2002L, new DateTime(2019, 7, 14, 20, 55, 50, 631, DateTimeKind.Local).AddTicks(1410), 0.34000000000000002, -2.3500000000000001, 1.55 },
                    { -505L, -3003L, new DateTime(2019, 7, 14, 20, 55, 50, 631, DateTimeKind.Local).AddTicks(1410), 0.34000000000000002, -2.3500000000000001, 1.55 },
                    { -606L, -4004L, new DateTime(2019, 7, 14, 20, 55, 50, 631, DateTimeKind.Local).AddTicks(1410), 0.34000000000000002, -2.3500000000000001, 1.55 },
                    { -707L, -4004L, new DateTime(2019, 7, 14, 20, 55, 50, 632, DateTimeKind.Local).AddTicks(1410), 1.1200000000000001, 2.4199999999999999, -1.55 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logins_PlayerId",
                table: "Logins",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_TrainerId",
                table: "Logins",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shots_PlayerId",
                table: "Shots",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shots_TrainerId",
                table: "Shots",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_XyzShots_ShotId",
                table: "XyzShots",
                column: "ShotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "XyzShots");

            migrationBuilder.DropTable(
                name: "Shots");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
