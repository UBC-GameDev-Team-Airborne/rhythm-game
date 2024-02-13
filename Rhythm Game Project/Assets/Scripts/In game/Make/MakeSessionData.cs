using Data;

public class MakeSessionData
{
    public static bool IsDeveloperMode = false;
    public static SongData LoadedSong = null;

    public static void ClearSong()
    {
        LoadedSong = null;
    }
}
