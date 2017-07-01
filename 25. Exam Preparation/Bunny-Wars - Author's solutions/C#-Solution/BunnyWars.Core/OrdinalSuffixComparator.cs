namespace BunnyWars.Core
{
    using System.Collections.Generic;

    public class OrdinalSuffixComparator : IComparer<Bunny>
    {
        public int Compare(Bunny bunnyX, Bunny bunnyY)
        {
            var x = bunnyX.Name;
            var y = bunnyY.Name;
            for (int iX = x.Length - 1, iY = y.Length - 1;
                iX >= 0 && iY >= 0; iX--, iY--)
            {
                if (x[iX] > y[iY]) return 1;
                if (x[iX] < y[iY]) return -1;
            }

            if (x.Length == y.Length) return 0;
            if (x.Length > y.Length) return 1;

            return -1;
        }
    }
}
