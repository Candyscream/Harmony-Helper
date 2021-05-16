namespace Harmony_Helper
{
    public class HarmonyNode
    {
        Harmony.Note m_note = Harmony.Note.C;
        bool m_isMinor = false;
        int m_offset = 0;
        string m_chordSymbols = "maj7";

        public HarmonyNode(Harmony.Note note, int offset, bool isMinor)
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
}