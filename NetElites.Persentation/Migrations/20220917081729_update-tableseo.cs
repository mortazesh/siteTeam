using Microsoft.EntityFrameworkCore.Migrations;

namespace NetElites.Persentation.Migrations
{
    public partial class updatetableseo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seos_articles_ArticleId",
                table: "seos");

            migrationBuilder.DropForeignKey(
                name: "FK_seos_members_MemberId",
                table: "seos");

            migrationBuilder.DropForeignKey(
                name: "FK_seos_worksamples_WorksampleId",
                table: "seos");

            migrationBuilder.DropIndex(
                name: "IX_seos_ArticleId",
                table: "seos");

            migrationBuilder.DropIndex(
                name: "IX_seos_MemberId",
                table: "seos");

            migrationBuilder.DropIndex(
                name: "IX_seos_WorksampleId",
                table: "seos");

            migrationBuilder.AlterColumn<int>(
                name: "WorksampleId",
                table: "seos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "seos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "seos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_seos_ArticleId",
                table: "seos",
                column: "ArticleId",
                unique: true,
                filter: "[ArticleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_seos_MemberId",
                table: "seos",
                column: "MemberId",
                unique: true,
                filter: "[MemberId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_seos_WorksampleId",
                table: "seos",
                column: "WorksampleId",
                unique: true,
                filter: "[WorksampleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_seos_articles_ArticleId",
                table: "seos",
                column: "ArticleId",
                principalTable: "articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_seos_members_MemberId",
                table: "seos",
                column: "MemberId",
                principalTable: "members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_seos_worksamples_WorksampleId",
                table: "seos",
                column: "WorksampleId",
                principalTable: "worksamples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seos_articles_ArticleId",
                table: "seos");

            migrationBuilder.DropForeignKey(
                name: "FK_seos_members_MemberId",
                table: "seos");

            migrationBuilder.DropForeignKey(
                name: "FK_seos_worksamples_WorksampleId",
                table: "seos");

            migrationBuilder.DropIndex(
                name: "IX_seos_ArticleId",
                table: "seos");

            migrationBuilder.DropIndex(
                name: "IX_seos_MemberId",
                table: "seos");

            migrationBuilder.DropIndex(
                name: "IX_seos_WorksampleId",
                table: "seos");

            migrationBuilder.AlterColumn<int>(
                name: "WorksampleId",
                table: "seos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "seos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "seos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_seos_ArticleId",
                table: "seos",
                column: "ArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_seos_MemberId",
                table: "seos",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_seos_WorksampleId",
                table: "seos",
                column: "WorksampleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_seos_articles_ArticleId",
                table: "seos",
                column: "ArticleId",
                principalTable: "articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_seos_members_MemberId",
                table: "seos",
                column: "MemberId",
                principalTable: "members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_seos_worksamples_WorksampleId",
                table: "seos",
                column: "WorksampleId",
                principalTable: "worksamples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
