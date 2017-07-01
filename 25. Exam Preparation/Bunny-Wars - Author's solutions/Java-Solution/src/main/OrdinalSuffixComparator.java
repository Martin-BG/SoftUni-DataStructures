package main;

import java.util.Comparator;

public class OrdinalSuffixComparator implements Comparator<Bunny> {

    @Override
    public int compare(Bunny o1, Bunny o2) {
        String x = o1.getName();
        String y = o2.getName();
        for (int xI = x.length() - 1, yI = y.length() - 1;
                xI >= 0 && yI >= 0 ; xI--, yI--) {
            if (x.charAt(xI) > y.charAt(yI))
                return 1;
            else if (x.charAt(xI) < y.charAt(yI))
                return -1;
        }

        if (x.length() > y.length())
            return 1;
        else if (x.length() < y.length())
            return -1;
        else
            return 0;
    }
}
