namespace AbstractFactory.Core.BasicInterfaces.SpecificObjects
{
    public class Client
    {
        private readonly IChair _productChair;
        private readonly ITable _productTable;

        public Client(IFactory factory)
        {
            _productChair = factory.CreateProductChair();
            _productTable = factory.CreateProductTable();
        }

        public void Start()
        {
            _productChair.PrintInfo();
            _productTable.PrintInfo();
        }
    }
}
