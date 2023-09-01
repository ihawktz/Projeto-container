namespace TesteContainers.Models
{
    public class RelatorioViewModel
    {
        public List<GrupoPorClienteModel> GrupoPorCliente { get; set; } = new List<GrupoPorClienteModel>();
        public int TotalExportacao { get; set; }
        public int TotalImportacao { get; set; }
    }
}
