using LabC_Diez.domain;
using LabC_Diez.domain.validators;

namespace sem11.repository;

public class AchizitieFileRepository:InFileRepository<string,Achizitie>
{
    public AchizitieFileRepository(IValidator<Achizitie> vali, string fileName) : base(vali,fileName,EntityToFileMapping.CreateAchizitie)
    {
        
    }
}