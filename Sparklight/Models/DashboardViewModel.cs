public class DashboardViewModel
{
    public decimal? ValorFatura { get; set; }
    public decimal Economia { get; set; }
    public DateTime? DataVencimento { get; set; } 
    public int TotalKwh { get; set; }
    public int DiferencaTotalKwh { get; set; }
    public double PercentualTotalKwh { get; set; }
    public int TotalAparelhos { get; set; }
    public int KwhHoje { get; set; }
    public int DiferencaKwhHoje { get; set; }
    public double PercentualKwhHoje { get; set; }
}
