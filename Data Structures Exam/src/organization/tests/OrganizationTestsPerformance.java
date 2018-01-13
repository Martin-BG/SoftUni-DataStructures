package organization.tests;

import org.junit.Assert;
import org.junit.Test;
import organization.IOrganization;
import organization.Organization;
import organization.Person;

import java.util.*;

public class OrganizationTestsPerformance {

    @Test
    public void Add_50000Elements_ShouldWork() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;

        long l = System.currentTimeMillis();
        // Act
        for (int i = 0; i < count; i++) {
            org.add(new Person(i + "", i));
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 250);
    }

    @Test
    public void Contains_Existing100000Elements_ShouldWorkCorrectly() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;
        Deque<Person> people = new ArrayDeque<>();

        long l = System.currentTimeMillis();
        for (int i = 0; i < count; i++) {
            people.addLast(new Person(i + "", i));
            org.add(people.getLast());
        }

        // Act
        for (Person person : people) {
            Assert.assertTrue(org.contains(person));
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 300);
    }

    @Test
    public void GetAtIndex_With100000Elements_ShouldWorkFast() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;
        List<Person> people = new ArrayList<>();

        long l = System.currentTimeMillis();

        for (int i = 0; i < count; i++) {
            people.add(new Person(i + "", i));
            org.add(people.get(i));
        }

        // Act & Assert
        Random rand = new Random();
        for (int i = 0; i < 50_000; i++) {
            int rnd = rand.nextInt(count - 1);
            Assert.assertEquals(people.get(rnd), org.getAtIndex(rnd));
        }

        long l1 = System.currentTimeMillis();

        Assert.assertTrue(l1 - l < 350);
    }

    @Test
    public void Count_OnManyElements_ShouldWork() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;

        long l = System.currentTimeMillis();

        // Act & Assert
        for (int i = 0; i < count; i++) {
            Assert.assertEquals(i, org.getCount());
            org.add(new Person(i + "", i));
        }

        long l1 = System.currentTimeMillis();

        Assert.assertTrue(l1 - l < 400);
    }

    @Test
    public void ContainsByName_On100000Elements_ShouldWorkFast() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;
        List<String> names = new ArrayList<>(100_000);

        long l = System.currentTimeMillis();

        for (int i = 0; i < count; i++) {
            Person p = new Person(i + "", i);
            org.add(p);
            names.add(p.getName());
        }

        // Act
        for (int i = 0; i < count; i++) {
            Assert.assertEquals(Boolean.TRUE, org.containsByName(names.get(i)));
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 400);
    }

    @Test
    public void GetByName_OnManyRepeatingNames_ShouldWorkFast() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;
        int filler = 0;

        long l = System.currentTimeMillis();

        for (int i = 0; i < count; i++) {
            if (filler == 100) {
                filler = 0;
            }

            org.add(new Person(filler + "", i));

            filler++;
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 200);

        Iterable<Person> byName = org.getByName("0");
        int size = 0;
        for (Person person : byName) {
            size++;
        }

        // Act & Assert
        Assert.assertEquals(1000, size);
    }

    @Test
    public void GetByName_OnTwoUniqueNamesWith100000Elements_ShouldWorkFast() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;

        long l = System.currentTimeMillis();

        for (int i = 0; i < count; i++) {
            org.add(new Person("0", i));
        }
        org.add(new Person("1", 1));

        Iterable<Person> byName = org.getByName("1");
        int size = 0;
        for (Person person : byName) {
            size++;
        }

        long l1 = System.currentTimeMillis();

        Assert.assertTrue(l1 - l < 150);

        // Act & Assert
        Assert.assertEquals(1, size);
    }

    @Test
    public void PeopleByInsertOrder_On100000Elements_ShouldWorkFast() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;
        Person[] people = new Person[count];

        long l = System.currentTimeMillis();

        for (int i = 0; i < count; i++) {
            people[i] = new Person(i + "", i);
            org.add(people[i]);
        }

        Person[] result = new Person[org.getCount()];
        Iterable<Person> elements = org.peopleByInsertOrder();

        long l1 = System.currentTimeMillis();

        Assert.assertTrue(l1 - l < 300);
        // Act & Assert
    }

    @Test
    public void GetWithNameSize_On100000ElementsWithRandomLength_ShouldWorkFast() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;
        int expected = 0;

        long l = System.currentTimeMillis();

        Random random = new Random();
        for (int i = 0; i < count; i++) {
            int len = random.nextInt(100);
            if (len == 35) {
                expected++;
                org.add(new Person("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 25));
            }
        }

        // Act
        Iterable<Person> withNameSize = org.getWithNameSize(35);

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);

        int size = 0;
        for (Person person : withNameSize) {
            size++;
        }

        Assert.assertEquals(expected, size);
    }

    @Test
    public void FirstByInsertOrder_On100000Elements_ShouldWorkFast() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;
        List<Person> people = new ArrayList<>();

        long l = System.currentTimeMillis();

        for (int i = 0; i < count; i++) {
            people.add(new Person(i + "", i));
            org.add(people.get(i));
        }


        Iterable<Person> result = org.firstByInsertOrder(50000);

        long l1 = System.currentTimeMillis();

        Assert.assertTrue(l1 - l < 500);
    }

    @Test
    public void SearchWithNameSize_OnLargeRange_ShouldWorkFast() {
        // Arrange
        IOrganization org = new Organization();
        int count = 100_000;
        int expected = 0;

        Random random = new Random();

        long l = System.currentTimeMillis();

        for (int i = 0; i < count; i++) {
            int len = random.nextInt(100);
            if (len >= 35 && len <= 635) {
                expected++;
                org.add(new Person("аааааааааааааааааааааааааааааааааааааааааааааааааа", 25));
            }
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);

        // Act
        Iterable<Person> getWithNameSize = org.searchWithNameSize(35, 635);
        int size = 0;
        for (Person person : getWithNameSize) {
            size++;
        }

        // Assert
        Assert.assertEquals(expected, size);
    }
}
