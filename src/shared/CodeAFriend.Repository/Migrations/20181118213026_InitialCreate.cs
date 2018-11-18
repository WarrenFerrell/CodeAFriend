using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeAFriend.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Problems_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserScripts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScripts", x => x.Id);
                    table.UniqueConstraint("AK_UserScripts_UserName_Name", x => new { x.UserName, x.Name });
                    table.ForeignKey(
                        name: "FK_UserScripts_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemSolutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    ProblemName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemSolutions", x => x.Id);
                    table.UniqueConstraint("AK_ProblemSolutions_ProblemName_Id", x => new { x.ProblemName, x.Id });
                    table.ForeignKey(
                        name: "FK_ProblemSolutions_Users_Name",
                        column: x => x.Name,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProblemSolutions_Problems_ProblemName",
                        column: x => x.ProblemName,
                        principalTable: "Problems",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemTags",
                columns: table => new
                {
                    Text = table.Column<string>(nullable: false),
                    ProblemName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTags", x => new { x.ProblemName, x.Text });
                    table.ForeignKey(
                        name: "FK_ProblemTags_Problems_ProblemName",
                        column: x => x.ProblemName,
                        principalTable: "Problems",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemTestCases",
                columns: table => new
                {
                    Number = table.Column<uint>(nullable: false),
                    Input = table.Column<string>(nullable: true),
                    ExpectedOutput = table.Column<string>(nullable: true),
                    ProblemName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTestCases", x => new { x.ProblemName, x.Number });
                    table.ForeignKey(
                        name: "FK_ProblemTestCases_Problems_ProblemName",
                        column: x => x.ProblemName,
                        principalTable: "Problems",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemSolutionVotes",
                columns: table => new
                {
                    Value = table.Column<short>(nullable: false),
                    SubmitterName = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    ProblemSolutionId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemSolutionVotes", x => new { x.ProblemSolutionId, x.UserName });
                    table.ForeignKey(
                        name: "FK_ProblemSolutionVotes_Users_SubmitterName",
                        column: x => x.SubmitterName,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProblemSolutionVotes_ProblemSolutions_UserName",
                        column: x => x.UserName,
                        principalTable: "ProblemSolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_UserName",
                table: "Problems",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSolutions_Name",
                table: "ProblemSolutions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSolutionVotes_SubmitterName",
                table: "ProblemSolutionVotes",
                column: "SubmitterName");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSolutionVotes_UserName",
                table: "ProblemSolutionVotes",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemSolutionVotes");

            migrationBuilder.DropTable(
                name: "ProblemTags");

            migrationBuilder.DropTable(
                name: "ProblemTestCases");

            migrationBuilder.DropTable(
                name: "UserScripts");

            migrationBuilder.DropTable(
                name: "ProblemSolutions");

            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
