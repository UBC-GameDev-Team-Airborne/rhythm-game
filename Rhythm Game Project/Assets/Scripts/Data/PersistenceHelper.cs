using System.Collections.Generic;

namespace Data
{
    public interface PersistenceHelper
    {
        public bool SaveData(SongData data);
        public SongData LoadData(string title);
        public List<string> GetSongs();
    }
}