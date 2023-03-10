using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication1;

public class User
{
    public User(string Fio, string DateOfBirth, string PhoneNumber, string Address)
    {
        this.Fio = Fio;
        this.DateOfBirth = DateOfBirth;
        this.PhoneNumber = PhoneNumber;
        this.Address = Address;
    }

    public string Fio;
    public string DateOfBirth;
    public string PhoneNumber;
    public string Address;
}

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        try
        {
            User user = new User("Karbyshev", "01.08.2003", "89009214113", "Stadionnaya 13");

            List<User> usersList = new List<User>();
            usersList.Add(user);

            UsersList.Items = usersList;
            UsersList.SelectedIndex = 0;

            MessageBox ms = new MessageBox(usersList.Count().ToString());
            ms.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }

    private void UsersListClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}