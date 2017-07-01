package test.helpers;

import main.Bunny;
import org.junit.Assert;

import java.util.Iterator;
import java.util.List;

public class TestUtils {

    public static void assertBunniesAreSame(List<BunnyDto> expected, Iterable<Bunny> actual) {
        Iterator<Bunny> enumerator = actual.iterator();

        for (BunnyDto bunny : expected) {
            Bunny current = enumerator.next();
            Assert.assertEquals(current.getName(), bunny.getName());
            Assert.assertEquals(current.getHealth(), bunny.getHealth());
            Assert.assertEquals(current.getScore(), bunny.getScore());
            Assert.assertEquals(current.getRoomId(), bunny.getRoomId());
            Assert.assertEquals(current.getTeam(), bunny.getTeam());
        }
    }
}
