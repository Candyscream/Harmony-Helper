namespace Harmony_Helper
{
    public static class MusicalScale
    {
        static int T = 2; //Tone
        static int S = 1; //Semi-Tone
        static int A = 3; //Augmented second
        public static int[] Ionian = new int[] { T, T, S, T, T, T, S };
        public static int[] Dorian = new int[] { T, S, T, T, T, S, T };
        public static int[] Phrygian = new int[] { S, T, T, T, S, T, T };
        public static int[] Lydian = new int[] { T, T, T, S, T, T, S };
        public static int[] Mixolydian = new int[] { T, T, S, T, T, S, T };
        public static int[] Aeolian = new int[] { T, S, T, T, S, T, T };
        public static int[] Locrian = new int[] { S, T, T, S, T, T, T };
        public static int[] Minor = Aeolian;
        public static int[] Major = Ionian;

        public static int[] HarmonicMinor = new int[] { T, S, T, T, S, A, S };
        public static int[] MelodicMinor = new int[] { T, S, T, T, T, T, S };



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
}
