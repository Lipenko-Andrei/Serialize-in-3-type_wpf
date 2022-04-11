using System;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Serialize_in_3_type_pdf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Users _users = new Users();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt Files (*.txt) | *.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                File_Puth.Text = "Выбран файл: " + openFileDialog.FileName;


                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    string[] text = streamReader.ReadToEnd().Split('\n');

                    foreach (string line in text)
                    {
                        var regex = Regex.Match(line, "Имя - (?<Name>\\S+), login - (?<Login>\\S+), password -  (?<Password>\\S+), Соль - (?<Salt>\\S+)");

                        string name = regex.Groups["Name"].Value;
                        string login = regex.Groups["Login"].Value;
                        string password = regex.Groups["Password"].Value;
                        string salt = regex.Groups["Salt"].Value;
                        Data data = new Data(name, login, password, salt);

                        _users.UserDataList.Add(data);
                    }
                }
            }
        }
        private void SerializerXML(Users users)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Users));
            using (FileStream fs = new FileStream("xmlData.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                xmlSerializer.Serialize(fs, users);
            }
        }

        private void Serialize_in_XML_Click(object sender, EventArgs e)
        {

            SerializerXML(_users);
        }

        private void Serialize_in_JSON_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Serialize_in_Binary_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
