using System.Collections.Generic;

public class SongMetadata
{
    public enum SetGenres { Pop, Hiphop, Rock, Dance, Electronic, Jazz, Classical, RnB, Country }
    public enum Difficulties { Easy, Medium, Hard, Chaos }
    
    public string FileName { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }

    public List<SetGenres> Genres { get; set; }
    public string Language { get; set; }
    public bool IsOriginal { get; set; }

    public int BPM { get; set; }
    public int Duration { get; set; }
    public (int, int) PreviewRange { get; set; }

    public Difficulties Difficulty { get; set; }

    public SongMetadata(string fileName, string title, string artist, List<SetGenres> genre, string language, bool isOriginal, int bpm, int duration, (int, int) previewRange, Difficulties difficulty)
    {
        FileName = fileName;
        Title = title;
        Artist = artist;
        Genres = genre;
        Language = language;
        IsOriginal = isOriginal;
        BPM = bpm;
        Duration = duration;
        PreviewRange = previewRange;
        Difficulty = difficulty;
    }
}
