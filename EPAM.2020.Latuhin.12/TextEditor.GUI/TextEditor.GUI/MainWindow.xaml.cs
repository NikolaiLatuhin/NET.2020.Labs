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
        /// <summary>
        /// Переменная для хранения пути к файлу при первом его открытии.
        /// Используется для быстрого сохранения изменений в этот же файл.
        /// </summary>
        private string _pathToFile;

        /// <summary>
        /// Флаг, для проверки открытия файла.
        /// </summary>
        private bool _isFileOpen;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик при открытии файла.
        /// </summary>
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
                // В названии программы отображается имя открытого файла.
                TitleChange();
                _isFileOpen = true;
            }

            catch
            {
                Console.WriteLine(@"Ошибка открытия файла");
            }

        }

        /// <summary>
        /// Обработчик при сохранении файла.
        /// </summary>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Если пользователь не открыл какой-либо файл, и нажимает сохранить,
            // то вызвать метод для создания файла через "Сохранить как".
            if (!_isFileOpen)
            {
                SaveAs_Click(new object(), new RoutedEventArgs());
                return;
            }

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

        /// <summary>
        /// Обработчик при "Сохранении как" файла.
        /// </summary>
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

                _pathToFile = sfd.FileName;
                // После "Сохранить как" файл создан, и является открытым в текстовом редакторе
                _isFileOpen = true;
                TitleChange();
            }
        }

        /// <summary>
        /// Пишет в названии имя открытого файла
        /// </summary>
        private void TitleChange()
        {
            const string baseTitle = "Текстовый редактор - ";
            var fileName = Path.GetFileName(_pathToFile);

            Title = baseTitle + fileName;
        }
    }
}
