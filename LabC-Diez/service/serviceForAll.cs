using System.Xml.Linq;
using LabC_Diez.domain;
using LabC_Diez.domain.validators;
using sem11.repository;

namespace LabC_Diez.service;

public class serviceForAll
{
    private AchizitiiService _achizitiiService;
    private DocumenteService _documenteService;
    private FacturaService _facturaService;

    public serviceForAll(AchizitiiService achizitiiService, DocumenteService documenteService,
        FacturaService facturaService)
    {
        _achizitiiService = achizitiiService;
        _documenteService = documenteService;
        _facturaService = facturaService;
    }

    public List<Achizitie> GetAchizitiWithLinkedFacturi()
    {
        List<Achizitie> achizitii = _achizitiiService.FindAllAchizitii();
        var facturas = _facturaService.FindAllFacturi();
        var result = from factura in facturas
            join achizitie in achizitii on int.Parse(factura.Id) equals achizitie.id_factura
            select new Achizitie()
            {
                Id = achizitie.Id,
                produs = achizitie.produs,
                cantitate = achizitie.cantitate,
                pretProdus = achizitie.pretProdus,
                id_factura = achizitie.id_factura,
                Factura = factura
            };
        return result.ToList();
    }

    public List<Factura> GetFacturiWithLinkedAchizitii()
    {
        List<Achizitie> achizitii = _achizitiiService.FindAllAchizitii();
        List<Factura> facturas = _facturaService.FindAllFacturi();

        var result = from factura in facturas
            join achizitie in achizitii on int.Parse(factura.Id) equals achizitie.id_factura into achizitiiFactura
            select new Factura
            {
                Id = factura.Id,
                DataScadenta = factura.DataScadenta,
                Categorie = factura.Categorie,
                Id_document = factura.Id_document,
                // Alte proprietăți specifice facturii
                Achizitie = achizitiiFactura.ToList() // Adaugăm lista de achiziții asociate facturii
            };
        ///asta nu merege asa cum trebuie ,ia doar cate o achizitie nu toate pe care le are cu id-ul ala
        return result.ToList();
    }
  

    public List<string> Task1()
    {
        List<Document> listDocumente = _documenteService.FindAllDocuments();

        return (from documente in _documenteService.FindAllDocuments()
            where documente.dataEmitere.Year == 2023
            select documente.Nume + " " + documente.dataEmitere).ToList();
        ;
    }

    public List<String> Task2()
    {
        List<Factura> listFactura = GetFacturiWithLinkedAchizitii();
        DateTime dataCurenta = DateTime.Now;
        List<Document> listaDocumente = _documenteService.FindAllDocuments();
        List<string> result = (from factura in listFactura join document in listaDocumente on factura.Id_document equals int.Parse(document.Id)
                where factura.DataScadenta.Month == dataCurenta.Month && factura.DataScadenta.Year == dataCurenta.Year
                select
                    $"{document.Nume} {factura.DataScadenta} Achizitii asociate: {string.Join(", ", factura.Achizitie.Select(achizitie => $"{achizitie.produs} x{achizitie.cantitate}"))}")
            .ToList();

        return result;

    }

    public List<String> Task3()
    {
        List<Factura> listFactura = GetFacturiWithLinkedAchizitii();
        List<Document> listaDocumente = _documenteService.FindAllDocuments();

        List<string> result = (from factura in listFactura join document in listaDocumente on factura.Id_document equals int.Parse(document.Id)
                where factura.Achizitie.Count >= 3
                select
                    $"{document.Nume} {factura.DataScadenta} Achizitii asociate: {string.Join(", ", factura.Achizitie.Select(achizitie => $"{achizitie.produs} x{achizitie.cantitate}"))} Cantitate totala: {factura.Achizitie.Sum(achizitie => achizitie.cantitate)}\")")
            .ToList();

        return result;

    }

   
    public List<string> Task4()
    {
        List<Factura> listaFacturi = facturi_din_categorie(Categories.Utilities);
        List<Document> listaDocumente = _documenteService.FindAllDocuments();
        List<string> achizitii = (from factura in listaFacturi
                join document in listaDocumente on factura.Id_document equals int.Parse(document.Id)
                select $"{document.Nume}: {string.Join(", ", factura.Achizitie.Select(achizitie => $"{achizitie.produs} x{achizitie.cantitate}"))}")
            .ToList();

        return achizitii;
    }

    public List<Factura >facturi_din_categorie(Categories categories)
    {
        List<Factura> listaFacturi = GetFacturiWithLinkedAchizitii();
        return (from factura in listaFacturi

                where factura.Categorie == categories
                select factura)
            .ToList();
    }

    public double x(List<Factura> facturi)
    {
        List<Achizitie> achizities = GetAchizitiWithLinkedFacturi();
        double suma_totala = 0;
        foreach (var factura in facturi)
        {
            double suma = (from achizitie in achizities
                where achizitie.id_factura == int.Parse(factura.Id)
                select achizitie.pretProdus).Sum();
            suma_totala = suma + suma_totala;
        }

        return suma_totala;
    }  

   public Categories Task5(){
       double maxim = 0;
       Categories? categoriesMax = null;
       foreach (Categories category in Enum.GetValues(typeof(Categories)))
       {
           double max = x(facturi_din_categorie(category));
           if (maxim <max )
           {
               maxim = max;
               categoriesMax = category;
           }
       }

       return (Categories)categoriesMax!;
   }
//
    //
    // }

}