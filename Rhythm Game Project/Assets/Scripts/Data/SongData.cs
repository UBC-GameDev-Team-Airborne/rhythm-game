using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Data
{
    public class SongData
    {
        public enum SetGenres { Pop, Hiphop, Rock, Dance, Electronic, Jazz, Classical, RnB, Country }
        public enum Difficulties { Easy, Medium, Hard, Chaos }


        public string Title { get; set; }
        public List<string> Artists { get; set; }

        public string SongFileName { get; set; }
        public string CoverFileName { get; set; }

        public List<SetGenres> Genres { get; set; }
        public string Language { get; set; }
        public bool? IsOriginal { get; set; }

        public int? BPM { get; set; }
        public int? Duration { get; set; }
        public (int?, int?) PreviewRange { get; set; }

        public Difficulties? Difficulty { get; set; }


        public LinkedList<NoteData> Notes { get; set; }


        public SongData()
        {

        }

        public SongData(string title, List<string> artists, string songFileName, string coverFileName, List<SetGenres> genre, string language, bool isOriginal, int bpm, int duration, (int, int) previewRange, Difficulties difficulty, LinkedList<NoteData> notes)
        {
            Title = title;
            Artists = artists;
            SongFileName = songFileName;
            CoverFileName = coverFileName;
            Genres = genre;
            Language = language;
            IsOriginal = isOriginal;
            BPM = bpm;
            Duration = duration;
            PreviewRange = previewRange;
            Difficulty = difficulty;
            Notes = notes;
        }

        public void SetGenresFromString(string genresString)
        {
            Genres = CommaDelimitedStringToGenres(genresString);
        }

        public bool AFieldIsNull()
        {
            if (Title == null) return true;
            if (Artists == null) return true;
            if (SongFileName == null) return true;
            if (CoverFileName == null) return true;
            if (Genres == null) return true;
            if (Language == null) return true;
            if (IsOriginal == null) return true;
            if (BPM == null) return true;
            if (Duration == null) return true;
            if (PreviewRange.Item1 == null) return true;
            if (PreviewRange.Item2 == null) return true;
            if (Difficulty == null) return true;
            if (Notes == null) return true;

            return false;
        }

        static public Difficulties StringToDifficulty(string difficultyString)
        {
            Difficulties difficulty;
            Enum.TryParse(difficultyString, out difficulty);
            return difficulty;
        }

        static public List<SetGenres> CommaDelimitedStringToGenres(string genresString)
        {
            Regex whitespace = new Regex(@"\s+");
            string noSpaces = whitespace.Replace(genresString, "");

            string[] genresStringArray = noSpaces.Split(",", StringSplitOptions.None);
            var genres = new List<SetGenres>();

            foreach (var genreString in genresStringArray)
            {
                SetGenres genre;
                if (Enum.TryParse(genreString, out genre))
                {
                    genres.Add(genre);
                }
            }

            return genres;
        }

        static public string GenresToCommaDelimitedString(List<SetGenres> genres)
        {
            if (genres.Count == 0) return "";

            StringBuilder genresString = new StringBuilder();
            foreach (var genre in genres)
            {
                genresString.Append(genre.ToString());
                genresString.Append(',');
            }
            return genresString.ToString();
        }
    }
}