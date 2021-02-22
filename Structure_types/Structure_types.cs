using System;

namespace Structure_types
{
    class Program
    {
        struct employee
        {
            public int age;
            public string name;
            public string surname;
            public string job;
            public int salary;
            public double premium()
            {
                return salary*0.1;
            }
        }
        static void Main(string[] args)
        {
            employee[] tab = new employee[2];
            tab[0].age = 25;
            tab[1].age = 20;
            tab[0].name = "Jake";
            tab[1].name = "Harry";
            tab[0].surname = "Smith";
            tab[1].surname = "Jones";
            tab[0].job = "employer";
            tab[1].job = "employee";
            tab[0].salary = 3000;
            tab[1].salary = 2000;
            for (int i=0;i<2;i++)
            {
                Console.WriteLine("Name {0} surname {1} age {2} job {3} salary {4} premium {5}", tab[i].name, tab[i].surname, tab[i].age, tab[i].job, tab[i].salary, tab[i].premium());
            }
        }
    }
}
