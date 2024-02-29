namespace LabC_Diez.domain.validators;

public interface IValidator<E>
{
    void Validate(E e);
}