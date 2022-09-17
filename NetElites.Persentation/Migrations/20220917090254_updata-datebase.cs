using Microsoft.EntityFrameworkCore.Migrations;

namespace NetElites.Persentation.Migrations
{
    public partial class updatadatebase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_Tag_Tagid",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "FK_members_Tag_Tagid",
                table: "members");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Tag_TagId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_worksamples_Tag_Tagid",
                table: "worksamples");

            migrationBuilder.DropForeignKey(
                name: "FK_worksamples_UsedWorksample_UsedWorksampleId",
                table: "worksamples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsedWorksample",
                table: "UsedWorksample");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "UsedWorksample",
                newName: "usedWorksamples");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "tags");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_TagId",
                table: "tags",
                newName: "IX_tags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usedWorksamples",
                table: "usedWorksamples",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tags",
                table: "tags",
                column: "id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_usedWorksamples",
                table: "usedWorksamples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tags",
                table: "tags");

            migrationBuilder.RenameTable(
                name: "usedWorksamples",
                newName: "UsedWorksample");

            migrationBuilder.RenameTable(
                name: "tags",
                newName: "Tag");

            migrationBuilder.RenameIndex(
                name: "IX_tags_TagId",
                table: "Tag",
                newName: "IX_Tag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsedWorksample",
                table: "UsedWorksample",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "id");

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
                name: "FK_Tag_Tag_TagId",
                table: "Tag",
                column: "TagId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_worksamples_UsedWorksample_UsedWorksampleId",
                table: "worksamples",
                column: "UsedWorksampleId",
                principalTable: "UsedWorksample",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
