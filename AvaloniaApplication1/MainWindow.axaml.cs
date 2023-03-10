using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

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
        if (UsersList.SelectedItem != null)
        {
            User user = UsersList.SelectedItem as User;

            if (user is User && user != null)
            {
                UserWindow userWindow = new UserWindow(user);
                userWindow.Show();
                this.Close();
            }
        }
    }

    private void CountriesListOnDoubleTapped(object? sender, RoutedEventArgs e)
    {
        try
        {
            Country country = CountriesList.SelectedItem as Country;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void AddCountryButtonClick(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddUserButtonClick(object? sender, RoutedEventArgs e)
    {
        ModifyUserWindow modifyUserWindow = new ModifyUserWindow(this);
        modifyUserWindow.Show();
        this.Close();
    }
}