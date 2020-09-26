﻿using Avalonia.Collections;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Avalonia.Controls.Ribbon
{
    public class RibbonMenu : RibbonMenuBase, IStyleable
    {
        Type IStyleable.StyleKey => typeof(RibbonMenu);


        private IEnumerable _menuItems = new AvaloniaList<object>();
        private IEnumerable _menuPlacesItems = new AvaloniaList<object>();

        public IEnumerable MenuItems
        {
            get { return _menuItems; }
            set { SetAndRaise(MenuItemsProperty, ref _menuItems, value); }
        }

        public IEnumerable MenuPlacesItems
        {
            get { return _menuPlacesItems; }
            set { SetAndRaise(MenuPlacesItemsProperty, ref _menuPlacesItems, value); }
        }

        public override bool IsMenuOpen
        {
            get
            {
                if (IsChecked != null)
                    return IsChecked.Value;
                else
                    return false;
            }
            set => IsChecked = value;
        }

        public static readonly DirectProperty<RibbonMenu, IEnumerable> MenuItemsProperty;
        public static readonly DirectProperty<RibbonMenu, IEnumerable> MenuPlacesItemsProperty;

        static RibbonMenu()
        {
            MenuItemsProperty = MenuBase.ItemsProperty.AddOwner<RibbonMenu>(x => x.MenuItems, (x, v) => x.MenuItems = v);
            MenuPlacesItemsProperty = ItemsControl.ItemsProperty.AddOwner<RibbonMenu>(x => x.MenuPlacesItems, (x, v) => x.MenuPlacesItems = v);
        }


    }
}
