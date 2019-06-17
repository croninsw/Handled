using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Handled.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cyclist",
                columns: table => new
                {
                    CyclistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: true),
                    Height = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cyclist", x => x.CyclistId);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    EmergencyContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Relation = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CyclistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.EmergencyContactId);
                });

            migrationBuilder.CreateTable(
                name: "Bicycle",
                columns: table => new
                {
                    BicycleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VIN = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    ManufactureYear = table.Column<string>(nullable: true),
                    CyclistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycle", x => x.BicycleId);
                    table.ForeignKey(
                        name: "FK_Bicycle_Cyclist_CyclistId",
                        column: x => x.CyclistId,
                        principalTable: "Cyclist",
                        principalColumn: "CyclistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CyclistEmergencyContact",
                columns: table => new
                {
                    CyclistEmergencyContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CyclistId = table.Column<int>(nullable: false),
                    EmergencyContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyclistEmergencyContact", x => x.CyclistEmergencyContactId);
                    table.ForeignKey(
                        name: "FK_CyclistEmergencyContact_Cyclist_CyclistId",
                        column: x => x.CyclistId,
                        principalTable: "Cyclist",
                        principalColumn: "CyclistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyclistEmergencyContact_EmergencyContact_EmergencyContactId",
                        column: x => x.EmergencyContactId,
                        principalTable: "EmergencyContact",
                        principalColumn: "EmergencyContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BicycleRider",
                columns: table => new
                {
                    BicycleRiderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CyclistId = table.Column<int>(nullable: false),
                    BicycleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicycleRider", x => x.BicycleRiderId);
                    table.ForeignKey(
                        name: "FK_BicycleRider_Bicycle_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycle",
                        principalColumn: "BicycleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BicycleRider_Cyclist_CyclistId",
                        column: x => x.CyclistId,
                        principalTable: "Cyclist",
                        principalColumn: "CyclistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentCarBicycleViewModel",
                columns: table => new
                {
                    IncidentCarBicycleViewModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(nullable: true),
                    DriverId = table.Column<int>(nullable: true),
                    BicycleId = table.Column<int>(nullable: true),
                    CyclistId = table.Column<int>(nullable: true),
                    CarDriverId = table.Column<int>(nullable: false),
                    BicycleRiderId = table.Column<int>(nullable: false),
                    IncidentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentCarBicycleViewModel", x => x.IncidentCarBicycleViewModelId);
                    table.ForeignKey(
                        name: "FK_IncidentCarBicycleViewModel_Bicycle_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycle",
                        principalColumn: "BicycleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncidentCarBicycleViewModel_BicycleRider_BicycleRiderId",
                        column: x => x.BicycleRiderId,
                        principalTable: "BicycleRider",
                        principalColumn: "BicycleRiderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncidentCarBicycleViewModel_Cyclist_CyclistId",
                        column: x => x.CyclistId,
                        principalTable: "Cyclist",
                        principalColumn: "CyclistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    IncidentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BicycleRiderId = table.Column<int>(nullable: false),
                    CarDriverId = table.Column<int>(nullable: false),
                    IncidentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incident_BicycleRider_BicycleRiderId",
                        column: x => x.BicycleRiderId,
                        principalTable: "BicycleRider",
                        principalColumn: "BicycleRiderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarDriver",
                columns: table => new
                {
                    CarDriverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DriverId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDriver", x => x.CarDriverId);
                });

            migrationBuilder.CreateTable(
                name: "CarDriverViewModel",
                columns: table => new
                {
                    CarDriverViewModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(nullable: true),
                    DriverId = table.Column<int>(nullable: true),
                    CarDriverId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDriverViewModel", x => x.CarDriverViewModelId);
                    table.ForeignKey(
                        name: "FK_CarDriverViewModel_CarDriver_CarDriverId",
                        column: x => x.CarDriverId,
                        principalTable: "CarDriver",
                        principalColumn: "CarDriverId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    DriverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    LicenseNumber = table.Column<string>(nullable: false),
                    InsuranceCompany = table.Column<string>(nullable: true),
                    InsurancePolicyNumber = table.Column<string>(nullable: true),
                    CarDriverViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Driver_CarDriverViewModel_CarDriverViewModelId",
                        column: x => x.CarDriverViewModelId,
                        principalTable: "CarDriverViewModel",
                        principalColumn: "CarDriverViewModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VIN = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    ManufactureYear = table.Column<string>(nullable: true),
                    DriverId = table.Column<int>(nullable: true),
                    CarDriverViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_CarDriverViewModel_CarDriverViewModelId",
                        column: x => x.CarDriverViewModelId,
                        principalTable: "CarDriverViewModel",
                        principalColumn: "CarDriverViewModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bicycle_CyclistId",
                table: "Bicycle",
                column: "CyclistId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BicycleRider_BicycleId",
                table: "BicycleRider",
                column: "BicycleId");

            migrationBuilder.CreateIndex(
                name: "IX_BicycleRider_CyclistId",
                table: "BicycleRider",
                column: "CyclistId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarDriverViewModelId",
                table: "Car",
                column: "CarDriverViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_DriverId",
                table: "Car",
                column: "DriverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarDriver_CarId",
                table: "CarDriver",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDriver_DriverId",
                table: "CarDriver",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDriverViewModel_CarDriverId",
                table: "CarDriverViewModel",
                column: "CarDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDriverViewModel_CarId",
                table: "CarDriverViewModel",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDriverViewModel_DriverId",
                table: "CarDriverViewModel",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CyclistEmergencyContact_CyclistId",
                table: "CyclistEmergencyContact",
                column: "CyclistId");

            migrationBuilder.CreateIndex(
                name: "IX_CyclistEmergencyContact_EmergencyContactId",
                table: "CyclistEmergencyContact",
                column: "EmergencyContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_CarDriverViewModelId",
                table: "Driver",
                column: "CarDriverViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_BicycleRiderId",
                table: "Incident",
                column: "BicycleRiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_CarDriverId",
                table: "Incident",
                column: "CarDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentCarBicycleViewModel_BicycleId",
                table: "IncidentCarBicycleViewModel",
                column: "BicycleId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentCarBicycleViewModel_BicycleRiderId",
                table: "IncidentCarBicycleViewModel",
                column: "BicycleRiderId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentCarBicycleViewModel_CarDriverId",
                table: "IncidentCarBicycleViewModel",
                column: "CarDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentCarBicycleViewModel_CarId",
                table: "IncidentCarBicycleViewModel",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentCarBicycleViewModel_CyclistId",
                table: "IncidentCarBicycleViewModel",
                column: "CyclistId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentCarBicycleViewModel_DriverId",
                table: "IncidentCarBicycleViewModel",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentCarBicycleViewModel_IncidentId",
                table: "IncidentCarBicycleViewModel",
                column: "IncidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentCarBicycleViewModel_Driver_DriverId",
                table: "IncidentCarBicycleViewModel",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentCarBicycleViewModel_Car_CarId",
                table: "IncidentCarBicycleViewModel",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentCarBicycleViewModel_CarDriver_CarDriverId",
                table: "IncidentCarBicycleViewModel",
                column: "CarDriverId",
                principalTable: "CarDriver",
                principalColumn: "CarDriverId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentCarBicycleViewModel_Incident_IncidentId",
                table: "IncidentCarBicycleViewModel",
                column: "IncidentId",
                principalTable: "Incident",
                principalColumn: "IncidentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_CarDriver_CarDriverId",
                table: "Incident",
                column: "CarDriverId",
                principalTable: "CarDriver",
                principalColumn: "CarDriverId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriver_Driver_DriverId",
                table: "CarDriver",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriver_Car_CarId",
                table: "CarDriver",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriverViewModel_Driver_DriverId",
                table: "CarDriverViewModel",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriverViewModel_Car_CarId",
                table: "CarDriverViewModel",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CarDriverViewModel_CarDriverViewModelId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_CarDriverViewModel_CarDriverViewModelId",
                table: "Driver");

            migrationBuilder.DropTable(
                name: "CyclistEmergencyContact");

            migrationBuilder.DropTable(
                name: "IncidentCarBicycleViewModel");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "BicycleRider");

            migrationBuilder.DropTable(
                name: "Bicycle");

            migrationBuilder.DropTable(
                name: "Cyclist");

            migrationBuilder.DropTable(
                name: "CarDriverViewModel");

            migrationBuilder.DropTable(
                name: "CarDriver");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Driver");
        }
    }
}
