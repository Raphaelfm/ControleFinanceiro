using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeFinancas.Migrations
{
    public partial class CriacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas_A_Pagar",
                columns: table => new
                {
                    ContaPagarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaPagarIdentificacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrevisaoPagamento = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas_A_Pagar", x => x.ContaPagarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas_A_Pagar");
        }
    }
}
