using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony_Helper
{


    public class Harmony
    {
        public static ObservableCollection<NoteData> AllNotes
        {
            get
            {
                var collection = new ObservableCollection<NoteData>();
                for (int ii = -23; ii < 12 * 5; ++ii)
                {
                    collection.Add(new NoteData(ii));
                }

                return collection;
            }
        }

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

        public ObservableCollection<HarmonyNode> Nodes = new ObservableCollection<HarmonyNode>();
        public ObservableCollection<string> Scale = new ObservableCollection<string>();
        private int[] baseScale;


        public Harmony(Note mean = Note.C, bool minor = false)
        {
            baseScale = minor ? MusicalScale.Minor : MusicalScale.Major;
            foreach (int ii in MusicalScale.ToValue(baseScale))
            {
                var note = GetNote((int)mean + ii);
                Nodes.Add(new HarmonyNode(note, 0, minor));
                Scale.Add("" + ii);
            }
        }


    }
}
