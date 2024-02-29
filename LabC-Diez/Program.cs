// See https://aka.ms/new-console-template for more information

using LabC_Diez.domain;
using LabC_Diez.domain.validators;
using LabC_Diez.service;
using LabC_Diez.ui;
using sem11.repository;

Console.WriteLine("Cerinta ...........");


IValidator<Achizitie> validatorAchizitie = new AchizitieValidator();
IRepository<string, Achizitie> repoAchizitii = new AchizitieFileRepository(validatorAchizitie, "C:\\Users\\bianc\\RiderProjects\\LabC-Diez\\LabC-Diez\\data\\achizitii.txt");
AchizitiiService serviceAchizitii = new AchizitiiService(repoAchizitii);

  
IValidator<Document> validatorDocument = new DocumentValidator();
IRepository<string, Document> repoDocumente = new DocumenteFileRepository(validatorDocument,"C:\\Users\\bianc\\RiderProjects\\LabC-Diez\\LabC-Diez\\data\\documente.txt");
DocumenteService serviceDocument = new DocumenteService(repoDocumente);
IValidator<Factura> validatorFactura = new FacturaValidator();
IRepository<string, Factura> repoFactura = new FacturaFileRepository(validatorFactura, "C:\\Users\\bianc\\RiderProjects\\LabC-Diez\\LabC-Diez\\data\\facturi.txt");
FacturaService serviceFactura = new FacturaService(repoFactura);
serviceForAll serviceForAll=new serviceForAll(serviceAchizitii,serviceDocument,serviceFactura);
UI  ui =new UI(serviceForAll);
ui.Run();