using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1;

public partial class MainWindow : Window, UpdatableWindow
{
    public MainWindow()
    {
        InitializeComponent();
        
        Load();
    }

    public void Load()
    {
        this.Show();
        
        try
        {
            UsersList.Items = Connection.db.Users.Include(item => item.IdcountryNavigation).ToList();

            CountriesList.Items = Connection.db.Countries.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void UsersListOnDoubleTapped(object? sender, RoutedEventArgs e)
    {
        try
        {
            User user = UsersList.SelectedItem as User;

            UserWindow userWindow = new UserWindow(user);
            userWindow.Show();
            this.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void AddUserButtonClick(object? sender, RoutedEventArgs e)
    {
        ModifyUserWindow modifyUserWindow = new ModifyUserWindow(this);
        modifyUserWindow.Show();
        this.Hide();
    }

    private void CountriesListOnDoubleTapped(object? sender, RoutedEventArgs e)
    {
        try
        {
            Country country = CountriesList.SelectedItem as Country;

            CountryWindow countryWindow = new CountryWindow(country);
            countryWindow.Show();
            this.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void AddCountryButtonClick(object? sender, RoutedEventArgs e)
    {
        ModifyCountryWindow modifyCountryWindow  = new ModifyCountryWindow(this);
        modifyCountryWindow.Show();
        this.Hide();
    }
}