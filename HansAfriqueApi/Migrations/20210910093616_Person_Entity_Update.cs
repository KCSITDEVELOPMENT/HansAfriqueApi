using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HansAfriqueApi.Migrations
{
    public partial class Person_Entity_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Part_Category",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "Part_Description",
                table: "Parts",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "CellNumber",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellNumber",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Parts",
                newName: "Part_Description");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Part_Category",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
