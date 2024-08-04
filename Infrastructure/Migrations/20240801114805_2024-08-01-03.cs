using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _2024080103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Product",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 8, 1, 11, 48, 5, 398, DateTimeKind.Utc).AddTicks(4569), new DateTime(2024, 8, 1, 11, 48, 5, 398, DateTimeKind.Utc).AddTicks(4571) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 8, 1, 11, 48, 5, 398, DateTimeKind.Utc).AddTicks(4573), new DateTime(2024, 8, 1, 11, 48, 5, 398, DateTimeKind.Utc).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 8, 1, 11, 48, 5, 398, DateTimeKind.Utc).AddTicks(4575), new DateTime(2024, 8, 1, 11, 48, 5, 398, DateTimeKind.Utc).AddTicks(4576) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "ProductName");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 8, 1, 11, 32, 2, 603, DateTimeKind.Utc).AddTicks(6825), new DateTime(2024, 8, 1, 11, 32, 2, 603, DateTimeKind.Utc).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 8, 1, 11, 32, 2, 603, DateTimeKind.Utc).AddTicks(6831), new DateTime(2024, 8, 1, 11, 32, 2, 603, DateTimeKind.Utc).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 8, 1, 11, 32, 2, 603, DateTimeKind.Utc).AddTicks(6833), new DateTime(2024, 8, 1, 11, 32, 2, 603, DateTimeKind.Utc).AddTicks(6833) });
        }
    }
}
