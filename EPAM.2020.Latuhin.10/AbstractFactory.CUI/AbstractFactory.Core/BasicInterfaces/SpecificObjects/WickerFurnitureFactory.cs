namespace AbstractFactory.Core.BasicInterfaces.SpecificObjects
{
    public class WickerFurnitureFactory : IFactory
    {
        public IChair CreateProductChair()
        {
            return new WickerChair();
        }

        public ITable CreateProductTable()
        {
            return new WickerTable();
        }
    }
}
