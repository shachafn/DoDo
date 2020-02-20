using System;
using System.Collections.Generic;
using System.Linq;

namespace DoDoHashCode
{
    internal class Data
    {
        public Int64 GlobalBooksCount { get; set; }
        public Int64 GlobaLibrariesCount { get; set; }
        public Int64 GlobalDaysForScanningCount { get; set; }
        public Dictionary<Int64, Int64> GlobalBooksIdsToScoreMapping { get; set; } = new Dictionary<Int64, Int64>();

        public List<Library> GlobalLibrariesData = new List<Library>();

        public Data(string[] lines)
        {
            ParseGlobalData(lines);
            ParseScores(lines);
            ParseLibraries(lines);
        }

        private void ParseLibraries(string[] lines)
        {
            for (int i = 0; i < GlobaLibrariesCount; i++)
            {
                var libDataLine = lines[2 + i * 2];
                var libBooksDataLine = lines[2 + i * 2 + 1];

                var libData = libDataLine.Split(' ');
                var booksCount = Int64.Parse(libData[0]);
                var processTime = Int64.Parse(libData[1]);
                var booksPerDay = Int64.Parse(libData[2]);

                var libBooksData = libBooksDataLine.Split(' ').Select(l => Int64.Parse(l)).Select(id => new Book() { Id = id, Score = GlobalBooksIdsToScoreMapping[id] }).ToList();

                var lib = new Library()
                {
                    BooksCount = booksCount,
                    SignUpProcessTime = processTime,
                    BooksPerDay = booksPerDay,
                    Books = libBooksData
                };

                GlobalLibrariesData.Add(lib);
            }
        }

        private void ParseScores(string[] lines)
        {
            var scoresLine = lines[1];
            var scores = scoresLine.Split(' ').Select(l => Int64.Parse(l)).ToList();
            for (int i = 0; i < scores.Count(); i++)
            {
                GlobalBooksIdsToScoreMapping[i] = scores[i];
            }
        }

        private void ParseGlobalData(string[] lines)
        {
            var firstLine = lines[0];
            var numbers = firstLine.Split(' ');
            GlobalBooksCount = Int64.Parse(numbers[0]);
            GlobaLibrariesCount = Int64.Parse(numbers[1]);
            GlobalDaysForScanningCount = Int64.Parse(numbers[2]);
        }
    }
}