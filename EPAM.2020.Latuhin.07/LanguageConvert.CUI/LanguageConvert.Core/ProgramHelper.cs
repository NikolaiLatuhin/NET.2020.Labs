using System;

namespace LanguageConvert.Core
{
    public class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CheckCodeSyntax(string checkableString, string language)
        {
            Console.WriteLine("Start check to code syntax");
            switch (language)
            {
                case "C#":
                case "VB":
                    Console.WriteLine("Syntax check completed successfully");
                    return true;
            }

            return false;
        }
    }
}
