namespace LanguageConvert.Core
{
    public interface IConvertible
    {
        string ConvertToCSharp(string inputString);
        string ConvertToVB(string inputString);
    }
}
