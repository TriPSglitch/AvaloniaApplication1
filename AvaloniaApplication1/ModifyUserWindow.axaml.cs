using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1;

public partial class ModifyUserWindow : Window
{
    private Window backWindow;
    private User user;
    
    public ModifyUserWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
    
    public ModifyUserWindow(Window window)
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        this.backWindow = window;
    }
    
    public ModifyUserWindow(Window window, User user)
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        
        this.backWindow = window;
        this.user = user;

        FioBox.Text = user.Fio;
        DateOfBirthBox.Text = user.DateOfBirth;
        PhoneNumberBox.Text = user.PhoneNumber;
        AddressBox.Text = user.Address;
        CountryBox.Text = user.IdcountryNavigation.Name;
    }
    
    
    private void BackButtonClick(object? sender, RoutedEventArgs e)
    {
        backWindow.Show();
        this.Close();
    }
    
    
    private void SaveButtonClick(object? sender, RoutedEventArgs e)
    {
        user.Fio = FioBox.Text;
        user.DateOfBirth = DateOfBirthBox.Text;
        user.PhoneNumber = PhoneNumberBox.Text;
        user.Address = AddressBox.Text;
        user.Idcountry = Convert.ToInt32(CountryBox.Text);
    }
}