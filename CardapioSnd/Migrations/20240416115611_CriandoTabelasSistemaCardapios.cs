using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioSnd.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasSistemaCardapios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALIMENTO_SIS_CARDAPIO",
                columns: table => new
                {
                    ID_ALIMENTO = table.Column<int>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TP_ALIMENT0 = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DS_ALIMENTO = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALIMENTO_SIS_CARDAPIO", x => x.ID_ALIMENTO);
                });

            migrationBuilder.CreateTable(
                name: "CARDAPIO_SIS_CARDAPIO",
                columns: table => new
                {
                    ID_CARDAPIO = table.Column<int>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DATA_CARDAPIO = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    GUARNICAO = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    CARNE = table.Column<string>(type: "NVARCHAR2(150)", nullable: false),
                    SALADA_LEGUMES = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    EXTRAS = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARDAPIO_SIS_CARDAPIO", x => x.ID_CARDAPIO);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_SIS_CARDAPIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    LOGIN = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    SENHA = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "DATE", nullable: false),
                    DATA_ATUALIZACAO = table.Column<DateTime>(type: "DATE", nullable: true),
                    PERFIL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_SIS_CARDAPIO", x => x.ID_USUARIO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALIMENTO_SIS_CARDAPIO");

            migrationBuilder.DropTable(
                name: "CARDAPIO_SIS_CARDAPIO");

            migrationBuilder.DropTable(
                name: "USUARIO_SIS_CARDAPIO");
        }
    }
}
