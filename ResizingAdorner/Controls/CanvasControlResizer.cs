using Avalonia;
using Avalonia.Controls;

namespace ResizingAdorner.Controls;

public class CanvasControlResizer : IControlResizer
{
    private double _left;
    private double _top;
    private double _width;
    private double _height;

    public bool EnableSnap { get; set; }

    public double SnapX { get; set; }

    public double SnapY { get; set; }

    private double SnapXValue(double value)
    {
        return EnableSnap ? Snap.SnapValue(value, SnapX) : value;
    }

    private double SnapYValue(double value)
    {
        return EnableSnap ? Snap.SnapValue(value, SnapY) : value;
    }

    public void Start(Control control)
    {
        _left = Canvas.GetLeft(control);
        _top = Canvas.GetTop(control);
        _width = control.Bounds.Width;
        _height = control.Bounds.Height;
    }

    public void Move(Control control, Vector vector)
    {
        var left = _left + vector.X;
        Canvas.SetLeft(control, SnapXValue(left));

        var top = _top + vector.Y;
        Canvas.SetTop(control, SnapYValue(top));
    }

    public void Left(Control control, Vector vector)
    {
        var left = _left + vector.X;
        var width = _width - vector.X;
        if (width >= 0)
        {
            Canvas.SetLeft(control, SnapXValue(left));
            // TODO: Check for MinWidth
            control.Width = SnapXValue(width);
        }
    }

    public void Right(Control control, Vector vector)
    {
        _width = control.Bounds.Width;
        var width = _width + vector.X;
        if (width >= 0)
        {
            // TODO: Check for MinWidth
            control.Width = SnapXValue(width);
        }
    }

    public void Top(Control control, Vector vector)
    {
        var top = _top + vector.Y;
        var height = _height - vector.Y;
        if (height >= 0)
        {
            Canvas.SetTop(control, SnapYValue(top));
            // TODO: Check for MinHeight
            control.Height = SnapYValue(height);
        }
    }

    public void Bottom(Control control, Vector vector)
    {
        _height = control.Bounds.Height;
        var height = _height + vector.Y;
        if (height >= 0)
        {
            // TODO: Check for MinHeight
            control.Height = SnapYValue(height);
        }
    }
}
