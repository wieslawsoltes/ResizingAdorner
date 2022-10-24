﻿using System;
using Avalonia;
using Avalonia.Controls;
using ResizingAdorner.Controls.Model;
using ResizingAdorner.Controls.Utilities;

namespace ResizingAdorner.Editors;

public class DecoratorEditor : IControlEditor
{
    public void Insert(Type type, Point point, object control, IControlDefaults? controlDefaults)
    {
        if (control is not Decorator decorator)
        {
            return;
        }

        if (TypeFactory.CreateControl(type) is not { } child)
        {
            return;
        }

        controlDefaults?.Auto(child);

        decorator.Child = child;
    }
}
