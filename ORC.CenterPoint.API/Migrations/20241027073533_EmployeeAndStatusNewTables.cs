using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ORC.CenterPoint.API.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeAndStatusNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaternalSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name", "RegistrationDate" },
                values: new object[,]
                {
                    { (short)1, "Activo", new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7041) },
                    { (short)2, "Deshabilitado", new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7053) },
                    { (short)3, "Baja", new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7055) },
                    { (short)4, "Reincorporado", new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7056) },
                    { (short)5, "De vacaciones", new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7057) },
                    { (short)9999, "Eliminado", new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7058) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_StatusId",
                table: "Employee",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}