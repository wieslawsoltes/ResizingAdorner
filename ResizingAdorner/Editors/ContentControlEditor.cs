﻿using System;
using Avalonia;
using Avalonia.Controls;
using ResizingAdorner.Model;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.Editors;

public class ContentControlEditor : IControlEditor
{
    public void Insert(Type type, Point point, object control, IControlDefaults? controlDefaults)
    {
        if (control is not ContentControl contentControl)
        {
            return;
        }

        if (TypeFactory.CreateControl(type) is not { } child)
        {
            return;
        }

        controlDefaults?.Auto(child);

        contentControl.Content = child;
    }
}