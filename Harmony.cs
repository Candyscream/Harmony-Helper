using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony_Helper
{
    public static class MusicalScale
    {
        public static int[] Aeolian = new int[] { 1, 2, 1, 1, 2, 1, 1 };
        public static int[] Locrian = new int[] { 2, 1, 1, 2, 1, 1, 1 };
        public static int[] Ionian = new int[] { 1, 1, 2, 1, 1, 2, 1 };
        public static int[] Dorian = new int[] { 1, 2, 1, 1, 1, 2, 1 };
        public static int[] Phrygian = new int[] { 1, 2, 1, 1, 1, 2, 1 };
        public static int[] Lydian = new int[] { 1, 2, 1, 1, 1, 2, 1 };
        public static int[] Mixolydian = new int[] { 1, 2, 1, 1, 1, 2, 1 };
        public static int[] Minor = Aeolian;
        public static int[] Major = Ionian;

        public static int[] ToValue(int[] scale)
        {
            int sum = 0;
            int[] values = new int[7];

            for (int ii = 0; ii < 7; ++ii)
            {
                values[ii] = sum;
                sum += scale[ii];
            }
            return values;
        }
    }

    class Node
    {
        Harmony.Note m_note = Harmony.Note.C;
        bool m_isMinor = false;
        int m_offset = 0;
        string m_chordSymbols = "maj7";

        public Node(Harmony.Note note, int offset, bool isMinor)
        {
            m_isMinor = isMinor;
            m_offset = offset;
            m_note = note;
        }
        public string BaseNote
        {
            get
            {
                return m_note + Harmony.signs[m_offset];
            }
        }
        public string Chord
        {
            get
            {
                string chordName = m_isMinor ? BaseNote.ToLower() : BaseNote;
                chordName += m_chordSymbols;
                return chordName;
            }
        }

        public string Notes
        {
            // TODO
            get { return BaseNote; }
        }
    }

    class Harmony
    {
        public static readonly Dictionary<int, string> signs = new Dictionary<int, string>()
        {
            { -2, "bb" },
            { -1, "b" },
            { 0, "" },
            { 1, "#" },
            { 2, "##" }
        };

        public enum Note
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G
        };

        Note GetNote(int index)
        {
            return (Note)(index % 7);
        }

        public ObservableCollection<Node> Nodes = new ObservableCollection<Node>();
        public ObservableCollection<string> Scale = new ObservableCollection<string>();
        private int[] baseScale;


        public Harmony(Note mean = Note.C, bool minor = false)
        {
            baseScale = minor ? MusicalScale.Minor : MusicalScale.Major;
            foreach (int ii in MusicalScale.ToValue(baseScale))
            {
                var note = GetNote((int)mean + ii);
                Nodes.Add(new Node(note, 0, minor));
                Scale.Add("" + ii);
            }
        }


    }
}
