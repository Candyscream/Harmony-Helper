using System.Collections.Generic;

namespace Harmony_Helper
{
    public class HarmonyNode
    {
        ChordType type = ChordType.Unknown;
        enum ChordType
        {
            Unknown,
            Major7,
            Major7b5,
            Major7s5,
            Dominant7,
            Dominant7b5,
            Dominant7s5,
            Minor7,
            Minor7b5,
            MinorMajor7,
            Diminished7,
            Augmented7
        }

        public NoteData meanNote { get; set; }
        public NoteData thirdNote { get; set; }
        public NoteData fourthNote { get; set; }
        public NoteData fifthNote { get; set; }
        public NoteData seventhNote { get; set; }

        private int degree;
        private int[] baseScale;

        int GetSum(int[] scale, int offset, int steps)
        {
            int sum = 0;
            for (int ii = 0; ii < steps; ++ii)
            {
                sum += scale[(offset + ii) % 7];
            }
            return sum;
        }

        private ChordType CalculateChordType()
        {
            const int MinorThird = 3;
            const int MajorThird = 4;

            const int DiminishedFifth = 6;
            const int NaturalFifth = 7;
            const int AugmentedFifth = 8;

            const int Major7 = 11;
            const int Minor7 = 10;
            const int Diminished7 = 9;

            var third = thirdNote.Index - meanNote.Index;
            var fifth = fifthNote.Index - meanNote.Index;
            var seventh = seventhNote.Index - meanNote.Index;

            if (third == MajorThird && seventh == Major7)
            {
                if (fifth == NaturalFifth)
                    return ChordType.Major7;

                if (fifth == DiminishedFifth)
                    return ChordType.Major7b5;

                if (fifth == AugmentedFifth)
                    return ChordType.Major7s5;
            }

            if (third == MajorThird && seventh == Minor7)
            {
                if (fifth == NaturalFifth)
                    return ChordType.Dominant7;

                if (fifth == DiminishedFifth)
                    return ChordType.Dominant7b5;

                if (fifth == AugmentedFifth)
                    return ChordType.Dominant7s5;
            }

            if (third == MinorThird)
            {
                if (fifth == NaturalFifth)
                {
                    if (seventh == Minor7)
                        return ChordType.Minor7;

                    if (seventh == Major7)
                        return ChordType.MinorMajor7;
                }

                if (fifth == DiminishedFifth)
                {
                    if (seventh == Minor7)
                        return ChordType.Minor7b5;

                    if (seventh == Diminished7)
                        return ChordType.Diminished7;
                }
            }

            return ChordType.Unknown;
        }

        public HarmonyNode(NoteData key, int degree, int[] scale)
        {
            this.degree = degree;
            this.meanNote = new NoteData(key.Index + GetSum(scale, 0, degree)); ;
            this.thirdNote = new NoteData(meanNote.Index + GetSum(scale, degree, 2));
            this.fourthNote = new NoteData(meanNote.Index + GetSum(scale, degree, 3));
            this.fifthNote = new NoteData(meanNote.Index + GetSum(scale, degree, 4));
            this.seventhNote = new NoteData(meanNote.Index + GetSum(scale, degree, 6));
            type = CalculateChordType();
            this.baseScale = scale;
        }

        public string BaseNote
        {
            get
            {
                return $"{meanNote.Name} {type}";
            }
        }

        public bool IsMinor
        {
            get { return thirdNote.Index - meanNote.Index == 3; }
        }
        public string ChordLetter
        {
            get
            {
                string Letter = meanNote.Name;
                Letter = IsMinor ? Letter.ToLower() : Letter;
                return Letter;
            }
        }
        public string Chord
        {
            get
            {
                return $"{ChordLetter} {type}";
            }
        }

        public string Degree
        {
            get
            {
                string numeral = Numerals[degree];
                numeral = IsMinor ? numeral.ToLower() : numeral;
                return $"{numeral}";
            }
        }

        public string DegreeChord
        {
            get
            {
                return $"{Degree} {type}";
            }
        }

        public string Type
        {
            get { return $"{type}"; }
        }

        public string Notes
        {
            // TODO
            get { return BaseNote; }
        }

        private static Dictionary<int, string> Numerals = new Dictionary<int, string>
        {
            { 0, "I" },
            { 1, "II" },
            { 2, "III" },
            { 3, "IV" },
            { 4, "V" },
            { 5, "VI" },
            { 6, "VII" },
            { 7, "VIII" }
        };

        public override string ToString()
        {
            return $"{Numerals[degree]} - {meanNote.Name} {type}";
        }
    }
}