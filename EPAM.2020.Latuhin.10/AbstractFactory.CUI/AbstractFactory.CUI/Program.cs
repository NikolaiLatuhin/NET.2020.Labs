using System;
using AbstractFactory.Core.BasicInterfaces;
using AbstractFactory.Core.BasicInterfaces.SpecificObjects;

namespace AbstractFactory.CUI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Тестирование работы абстрактная фабрика");

            IFactory factoryA = new WickerFurnitureFactory();
            Client clientA = new Client(factoryA);
            clientA.Start();

            IFactory factoryB = new OfficeFurnitureFactory();
            Client clientB = new Client(factoryB);
            clientB.Start();
        }
    }
}
