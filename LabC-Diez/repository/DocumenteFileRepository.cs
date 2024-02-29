using LabC_Diez.domain;
using LabC_Diez.domain.validators;

namespace sem11.repository;

public class DocumenteFileRepository:InFileRepository<string,Document>
{
    public DocumenteFileRepository(IValidator<Document> validator, string fileName) : base(validator, fileName,
        EntityToFileMapping.CreateDocument)
    {
        
    }
}