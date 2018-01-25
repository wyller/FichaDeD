using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class mapeandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Player_PlayerId",
                table: "Skill");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Skill",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_PlayerId",
                table: "Skill",
                newName: "IX_Skill_SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Player_SkillId",
                table: "Skill",
                column: "SkillId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Player_SkillId",
                table: "Skill");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Skill",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_SkillId",
                table: "Skill",
                newName: "IX_Skill_PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Player_PlayerId",
                table: "Skill",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
