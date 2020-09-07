using System;

namespace AbstractFactory.Core.BasicInterfaces.SpecificObjects
{
    public class WickerChair : IChair
    {
        public void PrintInfo()
        {
            Console.WriteLine("Плетеный стул");
        }
    }
}
