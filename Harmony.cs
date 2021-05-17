using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public ObservableCollection<HarmonyNode> Nodes = new ObservableCollection<HarmonyNode>();
        public ObservableCollection<NoteData> ScaleNotes;
        private int[] baseScale;

        public Harmony(int meanIndex, int[] scale)
        {
            baseScale = scale;
            var meanNote = new NoteData(meanIndex);
            int degree = 0;
            foreach (int ii in MusicalScale.ToValue(baseScale))
            {
                try
                {
                    Nodes.Add(new HarmonyNode(meanNote, degree++, baseScale));
                }
                catch (Exception e)
                {
                    Debug.Write(e.Message);
                }

            }
        }


    }
}
