using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240806 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 8, 6, 5, 43, 57, 356, DateTimeKind.Utc).AddTicks(1466), new DateTime(2024, 8, 6, 5, 43, 57, 356, DateTimeKind.Utc).AddTicks(1473) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 8, 6, 5, 43, 57, 356, DateTimeKind.Utc).AddTicks(1476), new DateTime(2024, 8, 6, 5, 43, 57, 356, DateTimeKind.Utc).AddTicks(1476) });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 8, 6, 5, 43, 57, 356, DateTimeKind.Utc).AddTicks(1478), new DateTime(2024, 8, 6, 5, 43, 57, 356, DateTimeKind.Utc).AddTicks(1478) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
