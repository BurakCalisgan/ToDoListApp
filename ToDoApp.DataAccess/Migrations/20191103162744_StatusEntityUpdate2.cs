using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.DataAccess.Migrations
{
    public partial class StatusEntityUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItem_Statuses_StatusId",
                table: "ToDoListItem");

            migrationBuilder.DropColumn(
                name: "StatuId",
                table: "ToDoListItem");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ToDoListItem",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItem_Statuses_StatusId",
                table: "ToDoListItem",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItem_Statuses_StatusId",
                table: "ToDoListItem");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ToDoListItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatuId",
                table: "ToDoListItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItem_Statuses_StatusId",
                table: "ToDoListItem",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
