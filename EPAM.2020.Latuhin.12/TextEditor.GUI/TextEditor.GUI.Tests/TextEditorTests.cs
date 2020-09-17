using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

namespace TextEditor.GUI.Tests
{
    [TestClass]
    public class TextEditorTests
    {
        [TestMethod]
        public void Should_ReturnRightExtensionFile_InputPathToFile()
        {
            var ofd = new OpenFileDialog
            {
                FileName = @"C:\Users\Admin\source\test.TXT"
            };

            // expected
            const string expected = ".txt";

            // actual
            var actual = Path.GetExtension(ofd.FileName).ToLower();

            Assert.AreEqual(expected, actual);
        }
    }
}
