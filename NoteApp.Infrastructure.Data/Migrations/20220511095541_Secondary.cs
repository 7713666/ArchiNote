using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteApp.Infrastructure.Data.Migrations
{
    public partial class Secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "notes",
                newName: "datetime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "notes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Head",
                table: "notes",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "notes",
                newName: "essence");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datetime",
                table: "notes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "notes",
                keyColumn: "title",
                keyValue: null,
                column: "title",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "notes",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "notes",
                keyColumn: "essence",
                keyValue: null,
                column: "essence",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "essence",
                table: "notes",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notes",
                table: "notes",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_notes",
                table: "notes");

            migrationBuilder.RenameTable(
                name: "notes",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "datetime",
                table: "Notes",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Notes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Notes",
                newName: "Head");

            migrationBuilder.RenameColumn(
                name: "essence",
                table: "Notes",
                newName: "Body");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Notes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Head",
                table: "Notes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Notes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");
        }
    }
}
