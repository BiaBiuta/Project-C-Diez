namespace LabC_Diez.domain;

public class Achizitie:Entity<string>
{
    public String produs { get; set; }
    public int cantitate { get; set; }
    public double pretProdus { get; set; }
    public int  id_factura { get; set; }
    public Factura Factura { get; set; }
}