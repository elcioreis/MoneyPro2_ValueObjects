using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyPro2.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(82)", maxLength: 82, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    PasswordHash = table.Column<string>(type: "CHAR(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true)
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
