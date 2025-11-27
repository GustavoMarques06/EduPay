using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPay.Migrations
{
    /// <inheritdoc />
    public partial class add_pagamento_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_transacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: true),
                    Data_pagamento = table.Column<DateOnly>(type: "date", nullable: false),
                    Id_aluno = table.Column<int>(type: "int", nullable: false),
                    Id_matricula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Alunos_Id_aluno",
                        column: x => x.Id_aluno,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Matriculas_Id_matricula",
                        column: x => x.Id_matricula,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_Id_aluno",
                table: "Pagamentos",
                column: "Id_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_Id_matricula",
                table: "Pagamentos",
                column: "Id_matricula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");
        }
    }
}
