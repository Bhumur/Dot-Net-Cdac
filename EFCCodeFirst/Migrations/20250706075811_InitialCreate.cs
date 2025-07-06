using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptNo = table.Column<int>(type: "int", nullable: false),
                    DeptName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__0148CAAE034037D0", x => x.DeptNo);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeptNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__AF2D66D3470F9BFD", x => x.EmpNo);
                    table.ForeignKey(
                        name: "FK_Employees_Departments",
                        column: x => x.DeptNo,
                        principalTable: "Departments",
                        principalColumn: "DeptNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptNo",
                table: "Employees",
                column: "DeptNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
