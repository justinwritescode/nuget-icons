// 
// IconDrawer.cs
// 
//   Created: 2022-10-10-08:26:19
//   Modified: 2022-11-11-03:38:03
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

#pragma warning disable
namespace NuGet.Icons;
using System.Drawing;
using System.Xml;
using System.Drawing.Imaging;

public record NuGetIconSettings(IconColor.IconColorEnum FillColor = default, IconColor.IconBorderColorEnum LinesColor = default, TileType TileType = TileType.None, IconColor.IconColorEnum TileColor = default);

public class NuGetIcon
{
    public const int BaseIconDimension = 288;
    public const int DrawnIconDimension = 1024;
    private Graphics Graphics { get; }
    public NuGetIcon(NuGetIconSettings settings)
    {
        var svg = string.Empty;
        switch (settings.TileType)
        {
            case TileType.Circle:
                svg = new StreamReader(typeof(NuGetIcon).Assembly.GetManifestResourceStream("JustinWritesCode.NuGet.Icons.IconComponents.CircularTile.svg")).ReadToEnd();
                break;
            case TileType.Square:
                svg = new StreamReader(typeof(NuGetIcon).Assembly.GetManifestResourceStream("JustinWritesCode.NuGet.Icons.IconComponents.SquareTile.svg")).ReadToEnd();
                break;
            case TileType.None:
                svg = new StreamReader(typeof(NuGetIcon).Assembly.GetManifestResourceStream("JustinWritesCode.NuGet.Icons.IconComponents.Blank.svg")).ReadToEnd();
                break;
        }
        svg = svg.Replace("COLOR", ColorTranslator.ToHtml(((Color)(IconColor)settings.TileColor)));
        var svgDoc = Svg.SvgDocument.Open<Svg.SvgDocument>(new XmlTextReader(new StringReader(svg)));
        Graphics = Graphics.FromImage(svgDoc.Draw());

        var svgFill = new StreamReader(typeof(NuGetIcon).Assembly.GetManifestResourceStream("JustinWritesCode.NuGet.Icons.IconComponents.IconFill.svg")).ReadToEnd();
        svgFill = svgFill.Replace("COLOR", ColorTranslator.ToHtml(((Color)(IconColor)settings.FillColor)));
        var svgFillDoc = Svg.SvgDocument.Open<Svg.SvgDocument>(new XmlTextReader(new StringReader(svgFill)));
        svgFillDoc.Draw(Graphics);

        var svgLines = new StreamReader(typeof(NuGetIcon).Assembly.GetManifestResourceStream("JustinWritesCode.NuGet.Icons.IconComponents.IconOutlines.svg")).ReadToEnd();
        svgLines = svgLines.Replace("COLOR", ColorTranslator.ToHtml(((Color)(IconColor)settings.LinesColor)));
        var svgLinesDoc = Svg.SvgDocument.Open<Svg.SvgDocument>(new XmlTextReader(new StringReader(svgLines)));
        svgLinesDoc.Draw(Graphics);
    }

    public virtual string GetIconUrl(bool useDataUri = false)
    {
        var tempFile = Path.GetTempFileName();
        var icon = Draw();
        icon.Save(tempFile, ImageFormat.Png);
        if (useDataUri)
        {
            return $"data:image/png;base64,{Convert.ToBase64String(File.ReadAllBytes(tempFile))}";
        }
        else
        {
            return "file://" + tempFile;
        }
    }

    public virtual Image Draw()
    {
        var img = new Bitmap(DrawnIconDimension, DrawnIconDimension);
        Graphics.DrawImage(img, 0, 0, DrawnIconDimension, DrawnIconDimension);
        return img;
    }

    public static Image DrawIcon(NuGetIconSettings settings)
    {
        var icon = new NuGetIcon(settings);
        return icon.Draw();
    }
}
