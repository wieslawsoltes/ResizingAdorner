﻿using System;
using Avalonia;
using Avalonia.Controls;
using ResizingAdorner.Controls.Model;
using ResizingAdorner.Controls.Utilities;

namespace ResizingAdorner.Editors;

public class ButtonEditor : IControlEditor
{
    public void Insert(Type type, Point point, object control, IControlDefaults? controlDefaults)
    {
        if (control is not Button button)
        {
            return;
        }

        if (TypeFactory.CreateControl(type) is not { } child)
        {
            return;
        }

        controlDefaults?.Auto(child);

        button.Content = child;
    }
}
