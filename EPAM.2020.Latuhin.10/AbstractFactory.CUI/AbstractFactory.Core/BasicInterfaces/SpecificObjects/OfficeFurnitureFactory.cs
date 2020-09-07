namespace AbstractFactory.Core.BasicInterfaces.SpecificObjects
{
    public class OfficeFurnitureFactory : IFactory
    {
        public IChair CreateProductChair()
        {
            return new OfficeChair();
        }
        public ITable CreateProductTable()
        {
            return new OfficeTable();
        }
    }
}
