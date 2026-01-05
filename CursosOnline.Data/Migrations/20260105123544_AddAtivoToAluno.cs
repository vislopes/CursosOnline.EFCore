using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursosOnline.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAtivoToAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Matriculas");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cursos",
                newName: "Titulo");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMatricula",
                table: "Matriculas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CargaHoraria",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Alunos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_CursoId",
                table: "Matriculas",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Cursos_CursoId",
                table: "Matriculas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Cursos_CursoId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_CursoId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "DataMatricula",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "CargaHoraria",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Cursos",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Matriculas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Matriculas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
