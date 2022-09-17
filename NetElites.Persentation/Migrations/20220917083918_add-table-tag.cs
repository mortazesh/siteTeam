using Microsoft.EntityFrameworkCore.Migrations;

namespace NetElites.Persentation.Migrations
{
    public partial class addtabletag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tagid",
                table: "worksamples",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tagid",
                table: "members",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Tagid",
                table: "articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    TagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_worksamples_Tagid",
                table: "worksamples",
                column: "Tagid");

            migrationBuilder.CreateIndex(
                name: "IX_members_Tagid",
                table: "members",
                column: "Tagid");

            migrationBuilder.CreateIndex(
                name: "IX_articles_Tagid",
                table: "articles",
                column: "Tagid");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagId",
                table: "Tag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_articles_Tag_Tagid",
                table: "articles",
                column: "Tagid",
                principalTable: "Tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_members_Tag_Tagid",
                table: "members",
                column: "Tagid",
                principalTable: "Tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_worksamples_Tag_Tagid",
                table: "worksamples",
                column: "Tagid",
                principalTable: "Tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_Tag_Tagid",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "FK_members_Tag_Tagid",
                table: "members");

            migrationBuilder.DropForeignKey(
                name: "FK_worksamples_Tag_Tagid",
                table: "worksamples");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_worksamples_Tagid",
                table: "worksamples");

            migrationBuilder.DropIndex(
                name: "IX_members_Tagid",
                table: "members");

            migrationBuilder.DropIndex(
                name: "IX_articles_Tagid",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "Tagid",
                table: "worksamples");

            migrationBuilder.DropColumn(
                name: "Tagid",
                table: "members");

            migrationBuilder.DropColumn(
                name: "Tagid",
                table: "articles");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
