using System.ComponentModel.DataAnnotations;

namespace LabC_Diez.domain.validators;

public class FacturaValidator:IValidator<Factura>
{
    public void Validate(Factura e)
    {
        bool valid = true;
        if (valid == false)
        {
            throw new ValidationException("Obiectul nu e valid");
        }
    }
}