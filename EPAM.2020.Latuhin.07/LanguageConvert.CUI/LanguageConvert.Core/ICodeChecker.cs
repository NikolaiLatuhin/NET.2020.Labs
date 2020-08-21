namespace LanguageConvert.Core
{
    public interface ICodeChecker
    {
        bool CheckCodeSyntax(string checkableString, string language);
    }
}
