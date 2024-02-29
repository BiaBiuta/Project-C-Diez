using LabC_Diez.domain;

namespace LabC_Diez.service;

public class AchizitiiService
{
    private IRepository<string, Achizitie> repo;

    public AchizitiiService(IRepository<string, Achizitie> repo)
    {
        this.repo = repo;
    }

    public List<Achizitie> FindAllAchizitii()
    {
        return repo.FindAll().ToList();
    }
}