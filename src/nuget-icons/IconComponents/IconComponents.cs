// 
// IconComponents.cs
// 
//   Created: 2022-11-11-03:25:56
//   Modified: 2022-11-11-03:25:56
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
namespace NuGet.Icons;
using System.Reflection;

public static class IconComponents
{
    public static class Blank
    {
        public static readonly string svg
            = new StreamReader(typeof(IconComponents).Assembly.GetManifestResourceStream("NuGet.Icons.IconComponents.Blank.svg")).ReadToEnd();
    }
    public static class CircularTile
    {
        public static readonly string svg
            = new StreamReader(typeof(IconComponents).Assembly.GetManifestResourceStream("NuGet.Icons.IconComponents.CircularTile.svg")).ReadToEnd();
    }
    public static class Fill
    {
        public static readonly string svg
            = new StreamReader(typeof(IconComponents).Assembly.GetManifestResourceStream("NuGet.Icons.IconComponents.Fill.svg")).ReadToEnd();
    }
    public static class Outlines
    {
        public static readonly string svg
            = new StreamReader(typeof(IconComponents).Assembly.GetManifestResourceStream("NuGet.Icons.IconComponents.Outlines.svg")).ReadToEnd();
    }
    public static class SquareTile
    {
        public static readonly string svg
            = new StreamReader(typeof(IconComponents).Assembly.GetManifestResourceStream("NuGet.Icons.IconComponents.SquareTile.svg")).ReadToEnd();
    }
}
