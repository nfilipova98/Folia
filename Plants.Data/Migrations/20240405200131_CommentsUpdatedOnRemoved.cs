using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plants.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommentsUpdatedOnRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);
        }
    }
}
