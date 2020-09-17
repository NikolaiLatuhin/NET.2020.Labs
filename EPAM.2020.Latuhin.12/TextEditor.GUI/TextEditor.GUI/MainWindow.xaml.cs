using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Win32;

namespace TextEditor.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string _pathToFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog {Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*"};

            if (ofd.ShowDialog() != true) return;

            var document = new TextRange(DocBox.Document.ContentStart, DocBox.Document.ContentEnd);

            try
            {
                _pathToFile = ofd.FileName;

                using (var fs = new FileStream(_pathToFile, FileMode.Open))
                {
                    switch (Path.GetExtension(ofd.FileName).ToLower())
                    {
                        case ".txt":
                            document.Load(fs, DataFormats.Text);
                            break;
                        case ".rtf":
                            document.Load(fs, DataFormats.Rtf);
                            break;
                        default:
                            document.Load(fs, DataFormats.Xaml);
                            break;
                    }
                }
            }

            catch
            {
                Console.WriteLine(@"Ошибка открытия файла");
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var document = new TextRange(DocBox.Document.ContentStart, DocBox.Document.ContentEnd);

            using (var fs = File.Create(_pathToFile))
            {
                switch (Path.GetExtension(_pathToFile).ToLower())
                {
                    case ".txt":
                        document.Save(fs, DataFormats.Text);
                        break;
                    case ".rtf":
                        document.Save(fs, DataFormats.Rtf);
                        break;
                    default:
                        document.Save(fs, DataFormats.Xaml);
                        break;
                }

                MessageBox.Show("Изменения сохранены");
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter =
                    "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*"
            };

            if (sfd.ShowDialog() != true) return;

            var document = new TextRange(DocBox.Document.ContentStart, DocBox.Document.ContentEnd);
            using (var fs = File.Create(sfd.FileName))
            {
                switch (Path.GetExtension(sfd.FileName).ToLower())
                {
                    case ".txt":
                        document.Save(fs, DataFormats.Text);
                        break;
                    case ".rtf":
                        document.Save(fs, DataFormats.Rtf);
                        break;
                    default:
                        document.Save(fs, DataFormats.Xaml);
                        break;
                }

                MessageBox.Show("Файл сохранен");
            }
        }
    }
}
