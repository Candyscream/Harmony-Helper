using System;
using System.Collections.Generic;

namespace Harmony_Helper
{
    public class NoteData
    {
        private static Dictionary<int, string> m_noteNames = new Dictionary<int, string>()
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

        public NoteData(int idx)
        {
            Index = idx;
        }

        public int Index = 0;
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
                return $"{m_noteNames[idx % 12]}";
            }
        }

        public override string ToString()
        {
            return $"{Index}: {Name} ({Octave})";
        }
    }
}
