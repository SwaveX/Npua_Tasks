using System.Collections;
using System.Windows;
using System.Windows.Controls;
using SetLib;

namespace Unions;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    MySet<Student> _men = new();
    MySet<Student> _women = new();
    MySet<Student> _reading = new();
    MySet<Student> _writing = new();
    MySet<Student> _arithmetic = new();

    Dictionary<string, MySet<Student>> allSets = new();

    public MainWindow()
    {
        InitializeComponent(); // Սա կապում է դիզայնը կոդի հետ

        // Տվյալների ստեղծում
        Student james     = new Student(id: 1, name: "James", Gender.Male);
        Student robert    = new Student(id: 2, name: "Robert", Gender.Male);
        Student john      = new Student(id: 3, name: "John", Gender.Male);
        Student mark      = new Student(id: 4, name: "Mark", Gender.Male);
        Student otherMark = new Student(id: 5, name: "Mark", Gender.Male);
        _men.AddRange([james, robert, john, mark, otherMark]);

        Student liza   = new Student(id: 6, name: "Liza", Gender.Female);
        Student amy    = new Student(id: 7, name: "Amy", Gender.Female);
        Student evelyn = new Student(id: 8, name: "Evelyn", Gender.Female);
        _women.AddRange([liza, amy, evelyn]);

        _reading.AddRange([james, robert, liza]);
        _writing.AddRange([robert, mark, amy, liza]);
        _arithmetic.AddRange([john, mark, otherMark, amy]);

        allSets.Add("Men", _men);
        allSets.Add("Women", _women);
        allSets.Add("Reading", _reading);
        allSets.Add("Writing", _writing);
        allSets.Add("Arithmetic", _arithmetic);
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (string name in allSets.Keys)
        {
            leftSet.Items.Add(name);
            rightSet.Items.Add(name);
        }

        operation.Items.Add("UNION");
        operation.Items.Add("INTERSECTION");
        operation.Items.Add("DIFFERENCE");
        operation.Items.Add("SYMETRIC DIFF");
    }

    // Սա այն մեթոդն է, որը փնտրում է XAML-ը 6 և 8 տողերում
    private void Set_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox? combo = sender as ComboBox;

        if (combo == null || e.AddedItems.Count == 0)
        {
            return;
        }

        string selectedName = e.AddedItems[0].ToString();
        MySet<Student> selectedSet = allSets[selectedName];

        if (combo.Name == "leftSet")
        {
            leftMembers.Items.Clear();

            foreach (var s in selectedSet)
            {
                leftMembers.Items.Add(s.Name);
            }
        }
        else if (combo.Name == "rightSet")
        {
            rightMembers.Items.Clear();

            foreach (var s in selectedSet)
            {
                rightMembers.Items.Add(s.Name);
            }
        }
    }

    private void EvaluateButton_Click(object sender, RoutedEventArgs e)
    {
        if (leftSet.SelectedItem == null 
            || rightSet.SelectedItem == null 
            || operation.SelectedItem == null)
        {
            MessageBox.Show("Ընտրեք բոլոր դաշտերը:");

            return;
        }

        MySet<Student> left = allSets[leftSet.SelectedItem.ToString()];
        MySet<Student> right = allSets[rightSet.SelectedItem.ToString()];
        string op = operation.SelectedItem.ToString();

        MySet<Student> result = op switch
        {
            "UNION" => left.Union(right),
            "INTERSECTION" => left.Intersection(right),
            "DIFFERENCE" => left.Difference(right),
            "SYMETRIC DIFF" => left.SymmetricDifference(right),
            _ => new MySet<Student>()
        };

        resultSet.Items.Clear();

        foreach (var s in result)
        {
            resultSet.Items.Add(s.Name);
        }
    }
}