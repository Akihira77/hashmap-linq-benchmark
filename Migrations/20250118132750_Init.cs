using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inventbackend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SegmentBusinessName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParameterDescName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsForContract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsForAccrue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_DistrictCode_CustomerCode_SegmentBusinessName_ParameterDescName",
                table: "Entities",
                columns: new[] { "DistrictCode", "CustomerCode", "SegmentBusinessName", "ParameterDescName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
