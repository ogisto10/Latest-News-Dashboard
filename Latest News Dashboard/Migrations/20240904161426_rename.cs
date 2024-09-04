using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Latest_News_Dashboard.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsArticles_Sources_SourceId",
                table: "NewsArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsArticles",
                table: "NewsArticles");

            migrationBuilder.RenameTable(
                name: "NewsArticles",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_NewsArticles_SourceId",
                table: "Articles",
                newName: "IX_Articles_SourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Sources_SourceId",
                table: "Articles",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sources_SourceId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "NewsArticles");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_SourceId",
                table: "NewsArticles",
                newName: "IX_NewsArticles_SourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsArticles",
                table: "NewsArticles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsArticles_Sources_SourceId",
                table: "NewsArticles",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id");
        }
    }
}
