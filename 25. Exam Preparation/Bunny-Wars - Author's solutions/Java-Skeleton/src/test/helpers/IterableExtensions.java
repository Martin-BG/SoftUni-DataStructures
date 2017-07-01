package test.helpers;

import java.util.Collection;
import java.util.TreeSet;
import java.util.stream.Stream;
import java.util.stream.StreamSupport;

public class IterableExtensions {

    public static <E> long getCount(Iterable<E> iterable) {
        if (iterable instanceof Collection) {
            return ((Collection)iterable).size();
        }

        return StreamSupport.stream(iterable.spliterator(), false).count();
    }

    public static <T extends Iterable<E>, E> Stream<E> take(Iterable<E> iterable, int count) {

        return StreamSupport.stream(iterable.spliterator(), false).limit(count);
    }
}
