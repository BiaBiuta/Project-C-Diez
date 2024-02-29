namespace LabC_Diez.domain;


public class Document:Entity<string>
{
    
    public String Nume { get; set; }
    public DateTime dataEmitere { get; set; }
}