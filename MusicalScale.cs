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
}
