using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1;

public partial class UserWindow : Window
{
    public UserWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    public UserWindow(User user)
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        FioLabel.Content = user.Fio;
        DateOfBirthLabel.Content = user.DateOfBirth;
        PhoneNumberLabel.Content = user.PhoneNumber;
        AddressLabel.Content = user.Address;
        CountryLabel.Content = user.IdcountryNavigation.Name;
    }

    private void BackButtonClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private void ChangeButtonClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}