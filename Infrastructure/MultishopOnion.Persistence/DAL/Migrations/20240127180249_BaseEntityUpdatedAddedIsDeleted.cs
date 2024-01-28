﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultishopOnion.Persistence.DAL.Migrations
{
    public partial class BaseEntityUpdatedAddedIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Slides",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Slides");
        }
    }
}
