using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORC.CenterPoint.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeDbo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Employee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "PositionId",
                table: "Employee",
                type: "smallint",
                nullable: false,
                defaultValue: (short)PositionsConstants.GeneralEmployeeId);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Employee",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                computedColumnSql: "[Name] + ' ' + [LastName] + ' ' + [MaternalSurname]");

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition_Id", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmployeePosition",
                columns: new[] { "Id", "Name", "RegistrationDate" },
                values: new object[] { (short)1, "Empleado general", new DateTime(2024, 10, 30, 22, 43, 52, 152, DateTimeKind.Local).AddTicks(7041) });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                table: "Employee",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_PositionId",
                table: "Employee",
                column: "PositionId",
                principalTable: "EmployeePosition",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_PositionId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeePosition");

            migrationBuilder.DropIndex(
                name: "IX_Employee_PositionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Employee");
        }
    }
}