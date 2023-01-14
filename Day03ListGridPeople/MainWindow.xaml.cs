using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day03ListGridPeople
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> peopleList = new List<Person>();
        const string DataFileName = @"..\..\people.txt";

        public MainWindow()
        {
            InitializeComponent();
            LvPeople.ItemsSource = peopleList;
        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (!ArePersonInputValid()) return;
            string name = TbxName.Text;
            int.TryParse(TbxAge.Text, out int age); // okay: no need to validate again
            peopleList.Add(new Person(name, age));
            LvPeople.Items.Refresh(); // tell ListView data has changed
            ResetFields();
        }

        private void ResetFields() 
        {

            TbxName.Text = "";
            TbxAge.Text = "";

        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            Person currSelPer = LvPeople.SelectedItem as Person;
            if (currSelPer == null) return;
            var result = MessageBox.Show(this, "Are you sure you want to delete this item? \n" +currSelPer,
                "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result != MessageBoxResult.Yes) return;
            peopleList.Remove(currSelPer);
            LvPeople.Items.Refresh();
            ResetFields();

        }
        private void BtnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {

            Person currSelPer = LvPeople.SelectedItem as Person;
            if (currSelPer == null) return;
            if(!ArePersonInputValid() ) return;
            string name = TbxName.Text;
            int.TryParse(TbxAge.Text,out int age);
            currSelPer.Name = name;
            currSelPer.Age = age;
            LvPeople.Items.Refresh();
            ResetFields();

        }

        private void LvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person currSelPer = LvPeople.SelectedItem as Person;
            if(currSelPer == null) 
            {
                ResetFields();
            }
            else
            {
                TbxName.Text = currSelPer.Name;
                TbxAge.Text = currSelPer.Age.ToString();
            }
        }

        private bool ArePersonInputValid()
        {

            if (!Person.IsNameValid(TbxName.Text, out string errorName))
            {
                MessageBox.Show(this, errorName, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Person.IsAgeValid(TbxAge.Text, out string errorAge))
            {
                MessageBox.Show(this, errorName, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }



        private void LoadDataFromFile() // call when window is loaded
        {
            // do your best with validation
            // data stored semicolon-separated, one per line:  Jerry;33

            try
            {
                if (!File.Exists(DataFileName)) return; // ignore if no file
                List<string> errorsList = new List<string>();
                string[] linesArray = File.ReadAllLines(DataFileName); // ex IO/System
                for (int i = 0; i < linesArray.Length; i++)
                {
                    string line = linesArray[i];
                    var data = line.Split(';');
                    if (data.Length != 2)
                    {
                        errorsList.Add($"Each line must have exactly 2 fields (line {i + 1})" +
                            "\n" + line);
                        continue;
                    }
                    // TODO: setters would allow us to avoid this code duplication
                    string name = data[0];
                    string ageStr = data[1];
                    if (!Person.IsNameValid(name, out string errorName))
                    {
                        errorsList.Add($"{errorName} (line {i + 1})");
                        continue;
                    }
                    int.TryParse(ageStr, out int age);
                    if (!Person.IsAgeValid(ageStr, out string errorAge))
                    {
                        errorsList.Add($"{errorAge} (line {i + 1})");
                        continue;
                    }
                    peopleList.Add(new Person(name, age));
                }
                LvPeople.Items.Refresh(); // tell ListView data has changed
                if (errorsList.Count != 0)
                {
                    string allErrors = String.Join("\n", errorsList);
                    MessageBox.Show(this, $"Warning: some lines were ignored due to {errorsList.Count} errors:\n" + allErrors, "Data errors", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from file\n" + ex.Message, "File access error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void SaveDataToFile() // call when window is closing
        {
            List<string> lines = new List<string>();
            foreach (Person p in peopleList)
            {
                lines.Add($"{p.Name};{p.Age}");
            }
            try { 
            File.WriteAllLines(DataFileName, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error writing to file \n" + ex.Message,
            "File access error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Fixme: if saving fails the program should not exit, it should ask the userlll
            SaveDataToFile();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataFromFile();
        }
    }
}
