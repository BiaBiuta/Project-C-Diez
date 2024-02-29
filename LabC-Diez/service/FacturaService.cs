using LabC_Diez.domain;

namespace LabC_Diez.service;

public class FacturaService
{
    private IRepository<string, Factura> repo;

    public FacturaService(IRepository<string, Factura> repo)
    {
        this.repo = repo;
    }

    public List<Factura> FindAllFacturi()
    {
        return repo.FindAll().ToList();
    }
}