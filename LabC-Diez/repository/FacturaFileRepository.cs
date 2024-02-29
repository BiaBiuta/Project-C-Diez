using LabC_Diez.domain;
using LabC_Diez.domain.validators;

namespace sem11.repository;

public class FacturaFileRepository:InFileRepository<string,Factura>
{
    public FacturaFileRepository(IValidator<Factura> vali, string fileName) : base(vali, fileName, EntityToFileMapping.CreateFactura)
    {
        
    }
}