using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1;

public partial class ModifyCountryWindow : Window
{
    private IUpdatableWindow backWindow;
    private Country country;

    public ModifyCountryWindow()
    {
        InitializeComponent();
    }

    public ModifyCountryWindow(IUpdatableWindow window)
    {
        InitializeComponent();

        try
        {
            this.backWindow = window;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public ModifyCountryWindow(IUpdatableWindow window, Country country)
    {
        InitializeComponent();

        try
        {
            this.backWindow = window;
            this.country = country;

            NameBox.Text = country.Name;
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
            country.Name = NameBox.Text;

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
            Connection.db.Countries.Remove(country);

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