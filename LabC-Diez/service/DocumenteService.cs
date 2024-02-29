using LabC_Diez.domain;

namespace LabC_Diez.service;

public class DocumenteService
{
    private IRepository<string, Document> repo;

    public DocumenteService(IRepository<string, Document> repo)
    {
        this.repo = repo;
    }

    public List<Document> FindAllDocuments()
    {
        return repo.FindAll().ToList();
    }
}