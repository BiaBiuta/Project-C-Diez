namespace LabC_Diez.domain;

public enum Categories 
{
    Utilities,Groceries,Fashion,Entertainment,Electronics
}
public class Factura:Document
{
    public int Id_document { get; set; }
    public Categories Categorie { get; set; }
    public DateTime DataScadenta { get; set; }
    public List<Achizitie> Achizitie { get; set; }

    public override string ToString()
    {
        return DataScadenta + " " + Achizitie;
    }
    
}