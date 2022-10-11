// 
// GetRandomIcon.cs
// 
//   Created: 2022-10-07-01:07:39
//   Modified: 2022-11-11-03:36:38
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace NuGet.Icons;
using System;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;

public class GetRandomNuGetIcon : Task
{
    [Required]
    public string Key { get; set; } = string.Empty;

    [Output]
    public Uri? IconUrl { get; set; } = null;

    public override bool Execute()
    {
        var iconSettings = new NuGet.Icons.NuGetIconSettings(
            (NuGet.Icons.IconColor.IconColorEnum)GetHash(17),
            (NuGet.Icons.IconColor.IconBorderColorEnum)GetHash(7),
            (NuGet.Icons.TileType)GetHash(3),
            (NuGet.Icons.IconColor.IconColorEnum)GetHash(17)
        );
        var icon = new NuGet.Icons.NuGetIcon(iconSettings);
        var iconUrl = icon.GetIconUrl();
        IconUrl = new Uri(iconUrl);
        return true;
    }

    private int GetHash(int n)
    {
        var hash = 0;
        foreach (var c in Key)
        {
            hash = (hash * 13) + c;
        }
        return hash % n;
    }
}
