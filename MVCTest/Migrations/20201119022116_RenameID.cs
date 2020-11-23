using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCTest.Migrations
{
    public partial class RenameID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFounder_Founders_FoundersFounderKey",
                table: "CustomerFounder");

            migrationBuilder.RenameColumn(
                name: "FounderKey",
                table: "Founders",
                newName: "FounderID");

            migrationBuilder.RenameColumn(
                name: "FoundersFounderKey",
                table: "CustomerFounder",
                newName: "FoundersFounderID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerFounder_FoundersFounderKey",
                table: "CustomerFounder",
                newName: "IX_CustomerFounder_FoundersFounderID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFounder_Founders_FoundersFounderID",
                table: "CustomerFounder",
                column: "FoundersFounderID",
                principalTable: "Founders",
                principalColumn: "FounderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFounder_Founders_FoundersFounderID",
                table: "CustomerFounder");

            migrationBuilder.RenameColumn(
                name: "FounderID",
                table: "Founders",
                newName: "FounderKey");

            migrationBuilder.RenameColumn(
                name: "FoundersFounderID",
                table: "CustomerFounder",
                newName: "FoundersFounderKey");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerFounder_FoundersFounderID",
                table: "CustomerFounder",
                newName: "IX_CustomerFounder_FoundersFounderKey");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFounder_Founders_FoundersFounderKey",
                table: "CustomerFounder",
                column: "FoundersFounderKey",
                principalTable: "Founders",
                principalColumn: "FounderKey",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
