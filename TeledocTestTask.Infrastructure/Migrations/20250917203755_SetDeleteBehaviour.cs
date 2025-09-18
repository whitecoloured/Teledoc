using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeledocTestTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetDeleteBehaviour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Clients_ClientID",
                table: "Founders");

            migrationBuilder.AddForeignKey(
                name: "FK_Founders_Clients_ClientID",
                table: "Founders",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Clients_ClientID",
                table: "Founders");

            migrationBuilder.AddForeignKey(
                name: "FK_Founders_Clients_ClientID",
                table: "Founders",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
