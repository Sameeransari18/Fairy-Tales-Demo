using FairyTalesDemo.Models;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using Microsoft.Maui.Controls;
using System;


namespace FairyTalesDemo;

public partial class MainPage : ContentPage
{
    public ObservableCollection<FairyTale> FairyTales { get; set; }
    public ObservableCollection<FairyTale> FairyTales2 { get; set; }

    public MainPage()
	{
		InitializeComponent();
		ModifySearchBarIcon();
        InitializeTales();
        BindingContext = this;

	}

    private void InitializeTales()
    {
        FairyTales = new ObservableCollection<FairyTale>{
            new FairyTale{ Name = "Tanjiro", ReadTime = new TimeSpan(0, 15, 0), Image="sword.jpeg"},
            new FairyTale{ Name = "Itachi", ReadTime = new TimeSpan(0, 15, 0), Image="itachi.jpeg"},
            new FairyTale{ Name = "Moon", ReadTime = new TimeSpan(0, 30, 0), Image="moon.jpeg"},
            new FairyTale{ Name = "Red Moon", ReadTime = new TimeSpan(0, 45, 0), Image="redmoon.jpeg"},
            new FairyTale{ Name = "Beauty", ReadTime = new TimeSpan(0, 20, 0), Image="beauty.jpeg"},
        };

        FairyTales2 = new ObservableCollection<FairyTale>{
            new FairyTale{ Name = "Moon", ReadTime = new TimeSpan(0, 30, 0), Image="moon.jpeg"},
            new FairyTale{ Name = "Beauty", ReadTime = new TimeSpan(0, 10, 0), Image="beauty.jpeg"},
            new FairyTale{ Name = "Itachi", ReadTime = new TimeSpan(0, 30, 0), Image="itachi.jpeg"},
            new FairyTale{ Name = "Red Moon", ReadTime = new TimeSpan(0, 45, 0), Image="redmoon.jpeg"},
            new FairyTale{ Name = "Tanjiro", ReadTime = new TimeSpan(0, 15, 0), Image="sword.jpeg"}
        };
    }

    private void OnIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Bookmarked", "Bookmark icon tapped!", "OK");
    }

    private void ModifySearchBarIcon()
    {
        SearchBarHandler.Mapper.AppendToMapping("CustomSearchIconColor", (h, v) =>
        {
#if ANDROID
        var context = h.PlatformView.Context;
        var searchIconId = context.Resources.GetIdentifier("search_mag_icon", "id", context.PackageName);
        if (searchIconId != 0)
        {
            var searchIcon = h.PlatformView.FindViewById<Android.Widget.ImageView>(searchIconId);
            searchIcon.SetColorFilter(Android.Graphics.Color.Rgb(172, 157, 185), Android.Graphics.PorterDuff.Mode.SrcIn);
        }
#endif
        });
    }

}

