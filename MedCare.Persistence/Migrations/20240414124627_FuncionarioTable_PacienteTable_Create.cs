using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedCare.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioTable_PacienteTable_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cpf = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    sexo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    datanascimento = table.Column<DateTime>(type: "date", nullable: false),
                    cargo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    registr_profissional = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    especialidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    endereco = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    celular = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cpf = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    sexo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    datanascimento = table.Column<DateTime>(type: "date", nullable: false),
                    endereco = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    celular = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_cpf",
                table: "funcionario",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_paciente_cpf",
                table: "paciente",
                column: "cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "paciente");
        }
    }
}
