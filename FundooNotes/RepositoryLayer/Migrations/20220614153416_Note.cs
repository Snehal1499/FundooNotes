using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteID",
                table: "Note",
                newName: "NoteId");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Note",
                newName: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Note_UserId",
                table: "Note",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_User_UserId",
                table: "Note",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_User_UserId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_UserId",
                table: "Note");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Note",
                newName: "NoteID");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Note",
                newName: "CreateDate");
        }
    }
}
