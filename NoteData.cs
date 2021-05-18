using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Harmony_Helper
{
    public class NoteData : INotifyPropertyChanged
    {
        public static readonly Dictionary<int, string> NoteNames = new Dictionary<int, string>()
        {
            { 0, "C" },
            { 1, "C#/Db" },
            { 2, "D" },
            { 3, "D#/Eb" },
            { 4, "E" },
            { 5, "F" },
            { 6, "F#/Gb" },
            { 7, "G" },
            { 8, "G#/Ab" },
            { 9, "A" },
            { 10, "A#/Bb" },
            { 11, "B" },
        };

        public static readonly Dictionary<string, int> NoteIndeces = new Dictionary<string, int>()
        {
            { "C", 0 },
            { "C#/Db", 1 },
            { "C#", 1 },
            { "Db", 1 },
            { "D", 2 },
            { "D#/Eb", 3 },
            { "D#", 3 },
            { "Eb", 3 },
            { "E", 4 },
            { "F", 5 },
            { "F#/Gb", 6 },
            { "F#", 6 },
            { "Gb", 6 },
            { "G", 7 },
            { "G#/Ab", 8 },
            { "G#", 8 },
            { "Ab", 8 },
            { "A", 9 },
            { "A#/Bb", 10 },
            { "A#", 10 },
            { "Bb", 10 },
            { "B", 11 },
        };
        public NoteData(int idx)
        {
            Index = idx;
        }
        private int index = 0;
        public int Index
        {
            get { return index; }
            set { index = value; OnPropertyChanged("Index"); }
        }

        public int Octave
        {
            get { return (int)(Index / 12) - 1; }
        }

        public string Name
        {
            get
            {
                int idx = Index;
                if (Index < 0)
                    idx += 12 * -Octave;
                var name = $"{NoteNames[idx % 12]}";
                return name;
            }
        }

        public override string ToString()
        {
            return $"{Index}: {Name} ({Octave})";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
