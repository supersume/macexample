using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MacExample;

public partial class MainWindow : Window
{
    ObservableCollection<string> animals = new ObservableCollection<string>() { "Giraffe", "Lion", "Cheetah" };
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        cbAnimals.ItemsSource = animals;
        lbGrid.ItemsSource = animals;

        var countries = CreateCountries();
        lbAnimals.ItemsSource = countries;

        cbAnimals.SelectedIndex = 0;
    }

    private void BtnAdd_OnClick(object? sender, RoutedEventArgs e)
    {
        string newAnimal = txtAnimal.Text.Trim();
        if (newAnimal != "")
        {
            animals.Add(newAnimal);
            txtAnimal.Text = string.Empty; //"";
        }
    }

    private void BtnDeleteLast_OnClick_OnClick(object? sender, RoutedEventArgs e)
    {
        if (animals.Any()) //if (animals.Count > 0)
        {
            animals.RemoveAt(animals.Count - 1);
        }
    }

    private List<Country> CreateCountries()
    {
        List<Country> countries = new List<Country>();
        countries.Add(new Country("Tanzania", "Dodoma", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/Flag_of_Tanzania.svg/330px-Flag_of_Tanzania.svg.png", new [] { "Kiswahili", "English" }));
        countries.Add(new Country("France", "Paris", "", new [] { "French" }));
        countries.Add(new Country("Mozambique", "Maputo", "", new [] { "Portuguese" }));
        countries.Add(new Country("Peru", "Lima", "", new [] { "Spanish", "Quechua" }));
        countries.Add(new Country("Japan", "Tokyo", "", new [] { "Japanese" }));
        countries.Add(new Country("Kenya", "Nairobi", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/Flag_of_Tanzania.svg/330px-Flag_of_Tanzania.svg.png", new [] { "English", "Kiswahili" }));
        countries.Add(new Country("Pakistan", "Islamabad", "", new [] { "Urdu" }));
        countries.Add(new Country("Turkey", "Istanbul", "", new [] { "Turkish" }));
        countries.Add(new Country("Italy", "Rome", "", new [] { "Italian" }));
        
        return countries;
    }
}

public class Country
{
    public string Name { get; set; }
    public string Capital { get; set; }
    public string Flag { get; set; }
    public string[] Languages { get; set; }
    
    public Country(string name, string capital, string flag, string[] languages)
    {
        Name = name;
        Capital = capital;
        Flag = flag;
        Languages = languages;
    }

    public string LanguageNames
    {
        get
        {
            return string.Join(", ", Languages);
        }
    }
    
    override public string ToString() => Name;
}