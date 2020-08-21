using System;

namespace LanguageConvert.Core
{
    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string inputString)
        {
            Console.WriteLine("Start convert to C#");
            return "Convert to C# language done";
        }

        public string ConvertToVB(string inputString)
        {
            Console.WriteLine("Start convert to VB");
            return "Convert to VB language done";
        }
    }
}
