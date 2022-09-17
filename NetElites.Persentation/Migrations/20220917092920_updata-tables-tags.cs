using Microsoft.EntityFrameworkCore.Migrations;

namespace NetElites.Persentation.Migrations
{
    public partial class updatatablestags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_tags_Tagid",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "FK_members_tags_Tagid",
                table: "members");

            migrationBuilder.DropForeignKey(
                name: "FK_tags_tags_TagId",
                table: "tags");

            migrationBuilder.DropForeignKey(
                name: "FK_worksamples_tags_Tagid",
                table: "worksamples");

            migrationBuilder.DropForeignKey(
                name: "FK_worksamples_usedWorksamples_UsedWorksampleId",
                table: "worksamples");

            migrationBuilder.DropIndex(
                name: "IX_worksamples_Tagid",
                table: "worksamples");

            migrationBuilder.DropIndex(
                name: "IX_worksamples_UsedWorksampleId",
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
                name: "UsedWorksampleId",
                table: "worksamples");

            migrationBuilder.DropColumn(
                name: "Tagid",
                table: "members");

            migrationBuilder.DropColumn(
                name: "Tagid",
                table: "articles");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "tags",
                newName: "WorksampleId");

            migrationBuilder.RenameIndex(
                name: "IX_tags_TagId",
                table: "tags",
                newName: "IX_tags_WorksampleId");

            migrationBuilder.CreateIndex(
                name: "IX_usedWorksamples_WorksampleId",
                table: "usedWorksamples",
                column: "WorksampleId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_ArticleId",
                table: "tags",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_MemberId",
                table: "tags",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_tags_articles_ArticleId",
                table: "tags",
                column: "ArticleId",
                principalTable: "articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tags_members_MemberId",
                table: "tags",
                column: "MemberId",
                principalTable: "members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tags_worksamples_WorksampleId",
                table: "tags",
                column: "WorksampleId",
                principalTable: "worksamples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usedWorksamples_worksamples_WorksampleId",
                table: "usedWorksamples",
                column: "WorksampleId",
                principalTable: "worksamples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tags_articles_ArticleId",
                table: "tags");

            migrationBuilder.DropForeignKey(
                name: "FK_tags_members_MemberId",
                table: "tags");

            migrationBuilder.DropForeignKey(
                name: "FK_tags_worksamples_WorksampleId",
                table: "tags");

            migrationBuilder.DropForeignKey(
                name: "FK_usedWorksamples_worksamples_WorksampleId",
                table: "usedWorksamples");

            migrationBuilder.DropIndex(
                name: "IX_usedWorksamples_WorksampleId",
                table: "usedWorksamples");

            migrationBuilder.DropIndex(
                name: "IX_tags_ArticleId",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "IX_tags_MemberId",
                table: "tags");

            migrationBuilder.RenameColumn(
                name: "WorksampleId",
                table: "tags",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_tags_WorksampleId",
                table: "tags",
                newName: "IX_tags_TagId");

            migrationBuilder.AddColumn<int>(
                name: "Tagid",
                table: "worksamples",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsedWorksampleId",
                table: "worksamples",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tagid",
                table: "members",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tagid",
                table: "articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_worksamples_Tagid",
                table: "worksamples",
                column: "Tagid");

            migrationBuilder.CreateIndex(
                name: "IX_worksamples_UsedWorksampleId",
                table: "worksamples",
                column: "UsedWorksampleId");

            migrationBuilder.CreateIndex(
                name: "IX_members_Tagid",
                table: "members",
                column: "Tagid");

            migrationBuilder.CreateIndex(
                name: "IX_articles_Tagid",
                table: "articles",
                column: "Tagid");

            migrationBuilder.AddForeignKey(
                name: "FK_articles_tags_Tagid",
                table: "articles",
                column: "Tagid",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_members_tags_Tagid",
                table: "members",
                column: "Tagid",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tags_tags_TagId",
                table: "tags",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_worksamples_tags_Tagid",
                table: "worksamples",
                column: "Tagid",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_worksamples_usedWorksamples_UsedWorksampleId",
                table: "worksamples",
                column: "UsedWorksampleId",
                principalTable: "usedWorksamples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
