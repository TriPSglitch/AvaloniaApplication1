using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication1;

public partial class MessageBox : Window
{
    private string text;
    
    public MessageBox()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public MessageBox(string text)
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        
        try
        {
            this.text = text;
            Text.Content = "количество: ";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}