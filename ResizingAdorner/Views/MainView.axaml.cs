using System;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;
using ResizingAdorner.XamlDom;

namespace ResizingAdorner.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        AttachedToVisualTree += OnAttachedToVisualTree;

        var gridDemo = new GridDemo();
        if (gridDemo.Dom.Root is { })
        {
            var sb = new StringBuilder();

            gridDemo.Dom.Root.Write(sb, 0);

            var xaml = sb.ToString();
            
            Console.WriteLine(xaml);

            // TODO: Content = gridDemo.Dom.Root.Control;
        }
    }

    private void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        if (this.GetVisualRoot() is TopLevel topLevel)
        {
            Global.ControlSelection?.Initialize(topLevel);
        }
    }

    public void OnDelete()
    {
        Global.ControlSelection?.Delete();
    }
}
