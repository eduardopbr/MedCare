using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedCare.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConsultaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consulta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pacienteid = table.Column<int>(type: "integer", nullable: false),
                    datanasc = table.Column<DateTime>(type: "date", nullable: false),
                    funcionarioid = table.Column<int>(type: "integer", nullable: false),
                    registro = table.Column<int>(type: "integer", nullable: false),
                    especialidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    diagnostico = table.Column<string>(type: "text", nullable: false),
                    examesrelacionados = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consulta", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consulta");
        }
    }
}
