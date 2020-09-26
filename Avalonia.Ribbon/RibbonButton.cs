﻿using Avalonia.Media.Imaging;
using Avalonia.Styling;
using System;

namespace Avalonia.Controls.Ribbon
{
    public class RibbonButton : Button, IStyleable, IRibbonControl
    {

        public static readonly AvaloniaProperty<RibbonControlSize> SizeProperty;
        public static readonly AvaloniaProperty<RibbonControlSize> MinSizeProperty;
        public static readonly AvaloniaProperty<RibbonControlSize> MaxSizeProperty;
        public static readonly StyledProperty<object> IconProperty = AvaloniaProperty.Register<RibbonButton, object>(nameof(Icon));
        public static readonly StyledProperty<object> LargeIconProperty = AvaloniaProperty.Register<RibbonButton, object>(nameof(LargeIcon));
        //public static readonly StyledProperty<bool> CanAddToQuickAccessToolbarProperty;

        static RibbonButton()
        {
            //CanAddToQuickAccessToolbarProperty = AvaloniaProperty.Register<RibbonButton, bool>(nameof(CanAddToQuickAccessToolbar), true);
            RibbonControlHelper<RibbonButton>.SetProperties(out SizeProperty, out MinSizeProperty, out MaxSizeProperty);
            Button.FocusableProperty.OverrideDefaultValue<RibbonButton>(false);
        }

        Type IStyleable.StyleKey => typeof(RibbonButton);

        public object Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public object LargeIcon
        {
            get => GetValue(LargeIconProperty);
            set => SetValue(LargeIconProperty, value);
        }


        public RibbonControlSize Size
        {
            get => (RibbonControlSize)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        public RibbonControlSize MinSize
        {
            get => (RibbonControlSize)GetValue(MinSizeProperty);
            set => SetValue(MinSizeProperty, value);
        }

        public RibbonControlSize MaxSize
        {
            get => (RibbonControlSize)GetValue(MaxSizeProperty);
            set => SetValue(MaxSizeProperty, value);
        }

        /*public bool CanAddToQuickAccessToolbar
        {
            get => GetValue(CanAddToQuickAccessToolbarProperty);
            set => SetValue(CanAddToQuickAccessToolbarProperty, value);
        }*/
    }

}
