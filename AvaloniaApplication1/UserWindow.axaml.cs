using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1;

public partial class UserWindow : Window, IUpdatableWindow
{
    private User user;
    private int userID;

    public UserWindow()
    {
        InitializeComponent();
    }

    public UserWindow(User user)
    {
        InitializeComponent();

        this.userID = user.Id;

        Load();
    }

    public void Load()
    {
        this.Show();

        try
        {
            this.user = Connection.db.Users.FirstOrDefault(item => item.Id == userID);

            FioLabel.Content = user.Fio;
            DateOfBirthLabel.Content = user.DateOfBirth;
            PhoneNumberLabel.Content = user.PhoneNumber;
            AddressLabel.Content = user.Address;
            CountryLabel.Content = user.IdcountryNavigation.Name;
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
        ModifyUserWindow modifyUserWindow = new ModifyUserWindow(this, user);
        modifyUserWindow.Show();
        this.Hide();
    }
}