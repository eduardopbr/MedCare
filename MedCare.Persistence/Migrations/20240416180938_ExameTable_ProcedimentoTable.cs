using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedCare.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExameTable_ProcedimentoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exame",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    pacienteid = table.Column<int>(type: "integer", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    hora = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    resultado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exame", x => x.id);
                    table.ForeignKey(
                        name: "FK_exame_paciente_pacienteid",
                        column: x => x.pacienteid,
                        principalTable: "paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "procedimento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    funcionarioid = table.Column<int>(type: "integer", nullable: false),
                    pacienteid = table.Column<int>(type: "integer", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    hora = table.Column<TimeSpan>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedimento", x => x.id);
                    table.ForeignKey(
                        name: "FK_procedimento_funcionario_funcionarioid",
                        column: x => x.funcionarioid,
                        principalTable: "funcionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_procedimento_paciente_pacienteid",
                        column: x => x.pacienteid,
                        principalTable: "paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exame_pacienteid",
                table: "exame",
                column: "pacienteid");

            migrationBuilder.CreateIndex(
                name: "IX_procedimento_funcionarioid",
                table: "procedimento",
                column: "funcionarioid");

            migrationBuilder.CreateIndex(
                name: "IX_procedimento_pacienteid",
                table: "procedimento",
                column: "pacienteid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exame");

            migrationBuilder.DropTable(
                name: "procedimento");
        }
    }
}
