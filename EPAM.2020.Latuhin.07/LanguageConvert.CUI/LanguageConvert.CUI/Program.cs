using LanguageConvert.Core;

namespace LanguageConvert.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            const int lengthExample = 4;
            var programs = new ProgramConverter[lengthExample];

            programs[0] = new ProgramConverter();
            programs[1] = new ProgramHelper();
            programs[2] = new ProgramConverter();
            programs[3] = new ProgramHelper();

            foreach (var program in programs)
            {
                if (program is ICodeChecker codeChecker)
                {
                    codeChecker.CheckCodeSyntax("string for convert", "C#");
                    program.ConvertToCSharp("string for convert");
                }
                else
                {
                    program.ConvertToCSharp("string for convert to C#");
                    program.ConvertToVB("string for convert to VB");
                }
            }

        }
    }
}
