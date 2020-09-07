using System;

namespace AbstractFactory.Core.BasicInterfaces.SpecificObjects
{
    public class OfficeChair : IChair
    {
        public void PrintInfo()
        {
            Console.WriteLine("Офисный стул");
        }
    }
}
