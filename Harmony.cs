using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony_Helper
{
    public class Harmony : INotifyPropertyChanged
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
        private ObservableCollection<HarmonyNode> nodes;
        public ObservableCollection<HarmonyNode> Nodes
        {
            get { return nodes; }
            set { nodes = value; OnPropertyChanged("Nodes"); }
        }

        public ObservableCollection<NoteData> ScaleNotes;
        private int[] baseScale;

        public Harmony(int meanIndex, int[] scale)
        {
            baseScale = scale;
            var newNodes = new ObservableCollection<HarmonyNode>();
            var meanNote = new NoteData(meanIndex);
            int degree = 0;
            foreach (int ii in MusicalScale.ToValue(baseScale))
            {
                try
                {
                    newNodes.Add(new HarmonyNode(meanNote, degree++, baseScale));
                }
                catch (Exception e)
                {
                    Debug.Write(e.Message);
                }
            }

            Nodes = newNodes;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
