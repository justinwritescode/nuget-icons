// 
// IconColor.cs
// 
//   Created: 2022-10-11-10:43:12
//   Modified: 2022-11-11-03:27:48
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

using System.Security.AccessControl;
#pragma warning disable
namespace NuGet.Icons;

public struct IconColor
{
    public string Name { get; }
    public System.Drawing.Color Color { get; }
    private IconColor(string Name, System.Drawing.Color Color)
    {
        this.Name = Name;
        this.Color = Color;
    }
    private static IconColor Instance(string Name, System.Drawing.Color Color)
    {
        return new IconColor(Name, Color);
    }
    public static IconColor None = Instance(nameof(None), System.Drawing.Color.Transparent);
    public static IconColor Black = Instance(nameof(Black), System.Drawing.Color.FromArgb(0, 0, 0));
    public static IconColor Cyan = Instance(nameof(White), System.Drawing.Color.FromArgb(0, 255, 255));
    public static IconColor Green = Instance(nameof(White), System.Drawing.Color.FromArgb(0, 255, 0));
    public static IconColor Magenta = Instance(nameof(White), System.Drawing.Color.FromArgb(255, 0, 255));
    public static IconColor White = Instance(nameof(White), System.Drawing.Color.FromArgb(255, 255, 255));
    public static IconColor Yellow = Instance(nameof(White), System.Drawing.Color.FromArgb(255, 255, 0));
    public static readonly IconColor Blue = Instance(nameof(Blue), System.Drawing.ColorTranslator.FromHtml("#002AFF"));
    public static readonly IconColor BurntOrange = Instance(nameof(BurntOrange), System.Drawing.ColorTranslator.FromHtml("#FF9D00"));
    public static readonly IconColor Fuchsia = Instance(nameof(Fuchsia), System.Drawing.ColorTranslator.FromHtml("#FF00CC"));
    public static readonly IconColor Greenish = Instance(nameof(Greenish), System.Drawing.ColorTranslator.FromHtml("#00FFE1"));
    public static readonly IconColor LightTeal = Instance(nameof(LightTeal), System.Drawing.ColorTranslator.FromHtml("#00FFE6"));
    public static readonly IconColor Olive = Instance(nameof(Olive), System.Drawing.ColorTranslator.FromHtml("#AAFF00"));
    public static readonly IconColor PukeYellow = Instance(nameof(PukeYellow), System.Drawing.ColorTranslator.FromHtml("#E1FF00"));
    public static readonly IconColor Red = Instance(nameof(Red), System.Drawing.ColorTranslator.FromHtml("#FF0000"));
    public static readonly IconColor RedGray = Instance(nameof(RedGray), System.Drawing.ColorTranslator.FromHtml("#FF0055"));
    public static readonly IconColor ToastedPlum = Instance(nameof(ToastedPlum), System.Drawing.ColorTranslator.FromHtml("#EA00FF"));

    public static implicit operator System.Drawing.Color(IconColor color)
    {
        return color.Color;
    }
    public static implicit operator IconColor(IconColorEnum e) => e switch
    {
        IconColorEnum.None => None,
        IconColorEnum.Black => Black,
        IconColorEnum.Cyan => Cyan,
        IconColorEnum.Green => Green,
        IconColorEnum.Magenta => Magenta,
        IconColorEnum.White => White,
        IconColorEnum.Yellow => Yellow,
        IconColorEnum.Blue => Blue,
        IconColorEnum.BurntOrange => BurntOrange,
        IconColorEnum.Fuchsia => Fuchsia,
        IconColorEnum.Greenish => Greenish,
        IconColorEnum.LightTeal => LightTeal,
        IconColorEnum.Olive => Olive,
        IconColorEnum.PukeYellow => PukeYellow,
        IconColorEnum.Red => Red,
        IconColorEnum.RedGray => RedGray,
        IconColorEnum.ToastedPlum => ToastedPlum,
        _ => throw new System.ArgumentException($"Invalid value {e} for enum {nameof(IconColorEnum)}"),
    };

    public static implicit operator IconColorEnum(IconColor e) => e.Name switch
    {
        nameof(None) => IconColorEnum.None,
        nameof(Black) => IconColorEnum.Black,
        nameof(Cyan) => IconColorEnum.Cyan,
        nameof(Green) => IconColorEnum.Green,
        nameof(Magenta) => IconColorEnum.Magenta,
        nameof(White) => IconColorEnum.White,
        nameof(Yellow) => IconColorEnum.Yellow,
        nameof(Blue) => IconColorEnum.Blue,
        nameof(BurntOrange) => IconColorEnum.BurntOrange,
        nameof(Fuchsia) => IconColorEnum.Fuchsia,
        nameof(Greenish) => IconColorEnum.Greenish,
        nameof(LightTeal) => IconColorEnum.LightTeal,
        nameof(Olive) => IconColorEnum.Olive,
        nameof(PukeYellow) => IconColorEnum.PukeYellow,
        nameof(Red) => IconColorEnum.Red,
        nameof(RedGray) => IconColorEnum.RedGray,
        nameof(ToastedPlum) => IconColorEnum.ToastedPlum,
        _ => throw new System.ArgumentException($"Invalid value {e} for enum {nameof(IconColor)}"),
    };
    public static implicit operator IconColor(IconBorderColorEnum e) => e switch
    {
        IconBorderColorEnum.None => None,
        IconBorderColorEnum.Black => Black,
        IconBorderColorEnum.Green => Green,
        IconBorderColorEnum.BurntOrange => BurntOrange,
        IconBorderColorEnum.Red => Red,
        IconBorderColorEnum.RedGray => RedGray,
        IconBorderColorEnum.ToastedPlum => ToastedPlum,
        _ => throw new System.ArgumentException($"Invalid value {e} for enum {nameof(IconColorEnum)}"),
    };

    public static implicit operator IconBorderColorEnum(IconColor e) => e.Name switch
    {
        nameof(None) => IconBorderColorEnum.None,
        nameof(Black) => IconBorderColorEnum.Black,
        nameof(Green) => IconBorderColorEnum.Green,
        nameof(BurntOrange) => IconBorderColorEnum.BurntOrange,
        nameof(Red) => IconBorderColorEnum.Red,
        nameof(RedGray) => IconBorderColorEnum.RedGray,
        nameof(ToastedPlum) => IconBorderColorEnum.ToastedPlum,
        _ => throw new System.ArgumentException($"Invalid value {e} for enum {nameof(IconBorderColorEnum)}"),
    };

    public enum IconColorEnum
    {
        None,
        Cyan,
        Black,
        Blue,
        BurntOrange,
        Fuchsia,
        Green,
        Greenish,
        LightTeal,
        Magenta,
        Olive,
        PukeYellow,
        Red,
        RedGray,
        ToastedPlum,
        White,
        Yellow,

    }

    public enum IconBorderColorEnum
    {
        None,
        Black,
        BurntOrange,
        Green,
        Red,
        RedGray,
        ToastedPlum
    }


}
