using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioBooksApp.Migrations
{
    /// <inheritdoc />
    public partial class renameIdformodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReaderId",
                table: "Readers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Publishers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Authors",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Readers",
                newName: "ReaderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Publishers",
                newName: "PublisherId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "AuthorId");
        }
    }
}
