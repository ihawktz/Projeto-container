using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using TesteContainers.Data;
using TesteContainers.Models;

namespace TesteContainers.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public RelatorioController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult<RelatorioViewModel> Index()
        {
            var dados = BuscarDados();

           if(dados == null)
                return NotFound();

            return View(dados);
        }


        [HttpPost]
        public IActionResult GerarRelatorio()
        {

            var dados = BuscarDados();

            string html = @$"<html>
                                <head>
                                    <title>Relatorio</title>
                                </head>

                                <style>
                                      .container{{
                                          display: flex;
                                          justify-content: center;
                                          align-items: center;
                                          flex-direction: column;
                                       }}

                                       table {{
                                          padding: 30px;
                                       }}

                                       tr td,th{{
                                          padding: 10px;
                                          border-bottom: 1px solid #ddd;

                                       }}

                                       th{{
                                          text-align: left;
                                       }}

                                       .tdNum{{
                                          text-align: center;
                                        }}


                                       p{{
                                          margin: 2px;
                                          border-bottom: 1px solid #ddd;
                                       }}

                                </style>
                                <body>
                                    <div class=""container"">
                                        <h2>Relatório</h2>
                                        <table>
                                            <tr>
                                                <th>Cliente</th>
                                                <th>Quantidade Importação</th>
                                                <th>Quantidade Exportação</th>
                                            </tr>";
    
            foreach(var dado in dados.GrupoPorCliente) 
            {

                html += @$"<tr>
                                <td>{dado.NomeCliente}</td>
                                <td class=""tdNum"">{dado.QtdImportacao}</td>
                                <td class=""tdNum"">{dado.QtdExportacao}</td>
                        </tr>";
            }

            html += @$"   </table>
                        <p>Total importação: {dados.TotalImportacao}</p>
                        <p>Total exportação: {dados.TotalExportacao}</p>
                        </div>
                      </body>
                    </html>";


            ChromePdfRenderer renderer = new ChromePdfRenderer();
            PdfDocument pdfDocument = renderer.RenderHtmlAsPdf(html);
            pdfDocument.SaveAs("table_example.pdf");

            return File(pdfDocument.BinaryData, "application/pdf", "Relatório.Pdf");
        }


        private RelatorioViewModel BuscarDados()
        {
            var totalImportacao = 0;
            var totalExportacao = 0;

            var relatorio = new RelatorioViewModel();

            var nomeClientes = _dbContext.Containers.Select(x => x.Cliente).Distinct().ToList();

            if (nomeClientes.Any())
            {
                foreach (var nome in nomeClientes)
                {
                    var totalImportacaoCliente = _dbContext.Containers.Where(x => x.Categoria == "Importação" && x.Cliente == nome).Count();
                    var totalExportacaoCliente = _dbContext.Containers.Where(x => x.Categoria == "Exportação" && x.Cliente == nome).Count();

                    totalImportacao += totalImportacaoCliente;
                    totalExportacao += totalExportacaoCliente;

                    relatorio.GrupoPorCliente.Add(new GrupoPorClienteModel()
                    {
                        NomeCliente = nome,
                        QtdExportacao = totalExportacaoCliente,
                        QtdImportacao = totalImportacaoCliente
                    });
                }

                relatorio.TotalImportacao = totalImportacao;
                relatorio.TotalExportacao = totalExportacao;

                return relatorio;
            }
            else
            {
                return null;
            }

        }


    }
}
