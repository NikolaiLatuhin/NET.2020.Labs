using System;

namespace AbstractFactory.Core.BasicInterfaces.SpecificObjects
{
    public class OfficeTable : ITable
    {
        public void PrintInfo()
        {
            Console.WriteLine("Офисный стол");
        }
    }
}
