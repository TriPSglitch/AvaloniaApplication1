using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1;

public partial class CountryWindow : Window, UpdatableWindow
{
    private Country country;
    private int countryID;

    public CountryWindow()
    {
        InitializeComponent();
    }

    public CountryWindow(Country country)
    {
        InitializeComponent();

        this.countryID = country.Id;

        Load();
    }

    public void Load()
    {
        this.Show();

        try
        {
            this.country = Connection.db.Countries.FirstOrDefault(item => item.Id == this.countryID);

            NameLabel.Content = country.Name;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void BackButtonClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private void ChangeButtonClick(object? sender, RoutedEventArgs e)
    {
        ModifyCountryWindow modifyCountryWindow = new ModifyCountryWindow(this, country);
        modifyCountryWindow.Show();
        this.Hide();
    }
}