using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequisitionSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRequisitionIdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionItems_Requisitions_RequisitionId",
                table: "RequisitionItems");

            migrationBuilder.AlterColumn<long>(
                name: "RequisitionId",
                table: "RequisitionItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionItems_Requisitions_RequisitionId",
                table: "RequisitionItems",
                column: "RequisitionId",
                principalTable: "Requisitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionItems_Requisitions_RequisitionId",
                table: "RequisitionItems");

            migrationBuilder.AlterColumn<long>(
                name: "RequisitionId",
                table: "RequisitionItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionItems_Requisitions_RequisitionId",
                table: "RequisitionItems",
                column: "RequisitionId",
                principalTable: "Requisitions",
                principalColumn: "Id");
        }
    }
}
