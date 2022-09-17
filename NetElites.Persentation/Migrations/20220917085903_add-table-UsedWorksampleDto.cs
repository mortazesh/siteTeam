using Microsoft.EntityFrameworkCore.Migrations;

namespace NetElites.Persentation.Migrations
{
    public partial class addtableUsedWorksampleDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "worksamples");

            migrationBuilder.AddColumn<int>(
                name: "UsedWorksampleId",
                table: "worksamples",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsedWorksample",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorksampleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedWorksample", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_worksamples_UsedWorksampleId",
                table: "worksamples",
                column: "UsedWorksampleId");

            migrationBuilder.AddForeignKey(
                name: "FK_worksamples_UsedWorksample_UsedWorksampleId",
                table: "worksamples",
                column: "UsedWorksampleId",
                principalTable: "UsedWorksample",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_worksamples_UsedWorksample_UsedWorksampleId",
                table: "worksamples");

            migrationBuilder.DropTable(
                name: "UsedWorksample");

            migrationBuilder.DropIndex(
                name: "IX_worksamples_UsedWorksampleId",
                table: "worksamples");

            migrationBuilder.DropColumn(
                name: "UsedWorksampleId",
                table: "worksamples");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "worksamples",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
