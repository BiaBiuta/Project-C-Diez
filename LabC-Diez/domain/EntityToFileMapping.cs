namespace LabC_Diez.domain;

public class EntityToFileMapping
{
    public static Achizitie CreateAchizitie(string line)
    {
        string[] fields = line.Split(',');//new char[]{','}
        Achizitie achizitie = new Achizitie()
        {
            Id = fields[0],
            produs = fields[1],
            cantitate = Int32.Parse(fields[2]),
            pretProdus = Double.Parse(fields[3]),
            id_factura = Int32.Parse(fields[4]),
            Factura= null
        };
        return achizitie;
    }

    public static Document CreateDocument(string line)
    {
        string[] fields = line.Split(',');
        Document document = new Document()
        {
            Id = fields[0],
            dataEmitere = DateTime.Parse(fields[2]),
            Nume = fields[1]
        };
        return document;
    }

    public static Factura CreateFactura(string line)
    {
        string[] fields=line.Split(',');
        Factura factura = new Factura()
        {
            Id = fields[0],
            Id_document = int.Parse(fields[1]),
            DataScadenta = DateTime.Parse(fields[2]),
            Categorie = (Categories)Enum.Parse(typeof(Categories), fields[3])
        };
        return factura;
    }
}