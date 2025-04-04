using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIWebApi.Migrations
{
    /// <inheritdoc />
    public partial class dept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Deptid",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departmments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Deptid",
                table: "Students",
                column: "Deptid");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departmments_Deptid",
                table: "Students",
                column: "Deptid",
                principalTable: "Departmments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departmments_Deptid",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Departmments");

            migrationBuilder.DropIndex(
                name: "IX_Students_Deptid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Deptid",
                table: "Students");
        }
    }
}
