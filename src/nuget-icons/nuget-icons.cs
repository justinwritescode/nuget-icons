namespace JustinWritesCode.NuGet;

public class GetRandomIcon : Microsoft.Build.Utilities.Task
{
    ITaskItem[] Icons { get; set; }
    [Output]
    ITaskItem OutputIcon { get; set; }

    public bool Execute()
    {
        var random = new Random();
        var index = random.Next(0, Icons.Length);
        var icon = Icons[index];
        Log.LogMessage("Selected icon: {0}", icon.ItemSpec);
        return true;
    }
}