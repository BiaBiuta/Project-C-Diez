using LabC_Diez.domain;
using LabC_Diez.service;

namespace LabC_Diez.ui;

public class UI
{
    private serviceForAll service;

    public UI(serviceForAll service)
    {
        this.service = service;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Exercise number:");
            int cmd = Int32.Parse(Console.ReadLine());

            switch (cmd)
            {
                case 1:
                    execute1();
                    break;
                case 2:
                    execute2();
                    break;
                case 3:
                    execute3();
                    break;
                case 4:
                    execute4();
                    break; 
                case 5:
                    execute5();
                    break;
                case 0:
                    return;
            }
        }
    }

    void execute1()
    {
        foreach (var s in service.Task1())
        {
         
            Console.WriteLine(s);
        }
    }
    
    void execute2()
    {
        foreach (var s in service.Task2())
        {
            Console.WriteLine(s);
        }
    }
    
    void execute3()
    {
        foreach (var s in service.Task3())
        {
            Console.WriteLine(s);
        }
    }
    
    void execute4()
    {
        foreach (var p in service.Task4())
        {
            Console.WriteLine(p);
        }
    }
    
    void execute5()
    {
        Console.WriteLine(service.Task5());
    }

}