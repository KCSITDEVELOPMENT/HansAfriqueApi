using Microsoft.EntityFrameworkCore.Migrations;

namespace HansAfriqueApi.Migrations
{
    public partial class UpdatePartnumberTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartNumber_PartNumberid",
                table: "Parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartNumber",
                table: "PartNumber");

            migrationBuilder.RenameTable(
                name: "PartNumber",
                newName: "PartNumbers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartNumbers",
                table: "PartNumbers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartNumbers_PartNumberid",
                table: "Parts",
                column: "PartNumberid",
                principalTable: "PartNumbers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartNumbers_PartNumberid",
                table: "Parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartNumbers",
                table: "PartNumbers");

            migrationBuilder.RenameTable(
                name: "PartNumbers",
                newName: "PartNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartNumber",
                table: "PartNumber",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartNumber_PartNumberid",
                table: "Parts",
                column: "PartNumberid",
                principalTable: "PartNumber",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
