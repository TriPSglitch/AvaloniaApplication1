using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1;

public partial class ModifyUserWindow : Window
{
    private IUpdatableWindow backWindow;
    private User user;

    public ModifyUserWindow()
    {
        InitializeComponent();
    }

    public ModifyUserWindow(IUpdatableWindow window)
    {
        InitializeComponent();

        try
        {
            this.backWindow = window;

            CountryBox.Items = Connection.db.Countries.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public ModifyUserWindow(IUpdatableWindow window, User user)
    {
        InitializeComponent();

        try
        {
            this.backWindow = window;
            this.user = user;

            FioBox.Text = user.Fio;
            DateOfBirthBox.Text = user.DateOfBirth;
            PhoneNumberBox.Text = user.PhoneNumber;
            AddressBox.Text = user.Address;
            CountryBox.Items = Connection.db.Countries.ToList();
            CountryBox.SelectedItem =
                (CountryBox.Items as List<Country>).Where(item => item.Name == user.IdcountryNavigation.Name)
                .FirstOrDefault();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void SaveButtonClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            user.Fio = FioBox.Text;
            user.DateOfBirth = DateOfBirthBox.Text;
            user.PhoneNumber = PhoneNumberBox.Text;
            user.Address = AddressBox.Text;

            if (CountryBox.SelectedItem != null)
            {
                user.Idcountry = (CountryBox.SelectedItem as Country).Id;
            }

            Connection.db.SaveChanges();

            Back();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void DeleteButtonClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            Connection.db.Users.Remove(user);

            Back();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void BackButtonClick(object? sender, RoutedEventArgs e)
    {
        Back();
    }

    private void Back()
    {
        backWindow.Load();
        this.Close();
    }
}