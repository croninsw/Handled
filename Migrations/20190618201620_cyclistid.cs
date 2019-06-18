using Microsoft.EntityFrameworkCore.Migrations;

namespace Handled.Migrations
{
    public partial class cyclistid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycle_AspNetUsers_CyclistId1",
                table: "Bicycle");

            migrationBuilder.DropForeignKey(
                name: "FK_BicycleRider_AspNetUsers_CyclistId1",
                table: "BicycleRider");

            migrationBuilder.DropForeignKey(
                name: "FK_CyclistEmergencyContact_AspNetUsers_CyclistId1",
                table: "CyclistEmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContact_AspNetUsers_CyclistId1",
                table: "EmergencyContact");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyContact_CyclistId1",
                table: "EmergencyContact");

            migrationBuilder.DropIndex(
                name: "IX_CyclistEmergencyContact_CyclistId1",
                table: "CyclistEmergencyContact");

            migrationBuilder.DropIndex(
                name: "IX_BicycleRider_CyclistId1",
                table: "BicycleRider");

            migrationBuilder.DropIndex(
                name: "IX_Bicycle_CyclistId1",
                table: "Bicycle");

            migrationBuilder.DropColumn(
                name: "CyclistId1",
                table: "EmergencyContact");

            migrationBuilder.DropColumn(
                name: "CyclistId1",
                table: "CyclistEmergencyContact");

            migrationBuilder.DropColumn(
                name: "CyclistId1",
                table: "BicycleRider");

            migrationBuilder.DropColumn(
                name: "CyclistId1",
                table: "Bicycle");

            migrationBuilder.AlterColumn<string>(
                name: "CyclistId",
                table: "EmergencyContact",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CyclistId",
                table: "CyclistEmergencyContact",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CyclistId",
                table: "BicycleRider",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CyclistId",
                table: "Bicycle",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_CyclistId",
                table: "EmergencyContact",
                column: "CyclistId");

            migrationBuilder.CreateIndex(
                name: "IX_CyclistEmergencyContact_CyclistId",
                table: "CyclistEmergencyContact",
                column: "CyclistId");

            migrationBuilder.CreateIndex(
                name: "IX_BicycleRider_CyclistId",
                table: "BicycleRider",
                column: "CyclistId");

            migrationBuilder.CreateIndex(
                name: "IX_Bicycle_CyclistId",
                table: "Bicycle",
                column: "CyclistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycle_AspNetUsers_CyclistId",
                table: "Bicycle",
                column: "CyclistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BicycleRider_AspNetUsers_CyclistId",
                table: "BicycleRider",
                column: "CyclistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CyclistEmergencyContact_AspNetUsers_CyclistId",
                table: "CyclistEmergencyContact",
                column: "CyclistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContact_AspNetUsers_CyclistId",
                table: "EmergencyContact",
                column: "CyclistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycle_AspNetUsers_CyclistId",
                table: "Bicycle");

            migrationBuilder.DropForeignKey(
                name: "FK_BicycleRider_AspNetUsers_CyclistId",
                table: "BicycleRider");

            migrationBuilder.DropForeignKey(
                name: "FK_CyclistEmergencyContact_AspNetUsers_CyclistId",
                table: "CyclistEmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContact_AspNetUsers_CyclistId",
                table: "EmergencyContact");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyContact_CyclistId",
                table: "EmergencyContact");

            migrationBuilder.DropIndex(
                name: "IX_CyclistEmergencyContact_CyclistId",
                table: "CyclistEmergencyContact");

            migrationBuilder.DropIndex(
                name: "IX_BicycleRider_CyclistId",
                table: "BicycleRider");

            migrationBuilder.DropIndex(
                name: "IX_Bicycle_CyclistId",
                table: "Bicycle");

            migrationBuilder.AlterColumn<int>(
                name: "CyclistId",
                table: "EmergencyContact",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyclistId1",
                table: "EmergencyContact",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CyclistId",
                table: "CyclistEmergencyContact",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyclistId1",
                table: "CyclistEmergencyContact",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CyclistId",
                table: "BicycleRider",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyclistId1",
                table: "BicycleRider",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CyclistId",
                table: "Bicycle",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyclistId1",
                table: "Bicycle",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_CyclistId1",
                table: "EmergencyContact",
                column: "CyclistId1");

            migrationBuilder.CreateIndex(
                name: "IX_CyclistEmergencyContact_CyclistId1",
                table: "CyclistEmergencyContact",
                column: "CyclistId1");

            migrationBuilder.CreateIndex(
                name: "IX_BicycleRider_CyclistId1",
                table: "BicycleRider",
                column: "CyclistId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bicycle_CyclistId1",
                table: "Bicycle",
                column: "CyclistId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycle_AspNetUsers_CyclistId1",
                table: "Bicycle",
                column: "CyclistId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BicycleRider_AspNetUsers_CyclistId1",
                table: "BicycleRider",
                column: "CyclistId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CyclistEmergencyContact_AspNetUsers_CyclistId1",
                table: "CyclistEmergencyContact",
                column: "CyclistId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContact_AspNetUsers_CyclistId1",
                table: "EmergencyContact",
                column: "CyclistId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
