using System;

namespace AbstractFactory.Core.BasicInterfaces.SpecificObjects
{
    public class WickerTable : ITable
    {
        public void PrintInfo()
        {
            Console.WriteLine("Плетеный стол");
        }
    }
}
