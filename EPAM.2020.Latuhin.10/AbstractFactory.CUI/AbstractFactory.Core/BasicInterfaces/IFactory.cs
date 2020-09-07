namespace AbstractFactory.Core.BasicInterfaces
{
    public interface IFactory
    {
        IChair CreateProductChair();
        ITable CreateProductTable();
    }
}
