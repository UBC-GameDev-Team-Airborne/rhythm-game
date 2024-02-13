using Data;

namespace Make
{
    public class SessionData
    {
        public static bool IsDeveloperMode = false;
        public static SongData LoadedSong = null;

        public static void ClearSong()
        {
            LoadedSong = null;
        }
    }
}