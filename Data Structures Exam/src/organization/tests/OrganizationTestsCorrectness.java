package organization.tests;

import org.junit.Assert;
import org.junit.Test;
import organization.IOrganization;
import organization.Organization;
import organization.Person;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class OrganizationTestsCorrectness {

    @Test
    public void Add_SingleElement_ShouldAddElement() {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.add(p);

        // Assert
        for (Person person : org) {
            Assert.assertEquals(p.getName(), person.getName());
            Assert.assertEquals(p.getSalary(), person.getSalary(), 0.00001);
        }
    }

    @Test
    public void Add_SingleElement_ShouldIncreaseCount() {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.add(p);

        // Assert
        Assert.assertEquals(1, org.getCount());
    }

    @Test
    public void Add_SingleElement_ShouldBeReturnedAsFirstElementByIndex() {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.add(p);

        // Assert
        Assert.assertEquals(p, org.getAtIndex(0));
    }

    @Test
    public void Contains_ExistingElement_ShouldReturnTrue() {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.add(p);
        boolean actual = org.contains(p);

        // Assert
        Assert.assertTrue(actual);
    }

    @Test
    public void Contains_NonExistingElement_ShouldReturnTrue() {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        boolean actual = org.contains(p);

        // Assert
        Assert.assertFalse(actual);
    }

    @Test
    public void ContainsByName_ExistingName_ShouldReturnTrue() {
        // Arrange
        IOrganization org = new Organization();
        Person p = new Person("pesho", 500);

        // Act
        org.add(p);
        boolean actual = org.containsByName(p.getName());

        // Assert
        Assert.assertTrue(actual);
    }

    @Test
    public void ContainsByName_NonExistingName_ShouldReturnFalse() {
        // Arrange
        IOrganization org = new Organization();

        // Act
        boolean actual = org.containsByName("Ivan");

        // Assert
        Assert.assertFalse(actual);
    }

    @Test
    public void Add_MultipleElements_ShouldAddCorrectElements() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        // Act
        for (Person person : people) {
            org.add(person);
        }

        // Assert
        Person[] people1 = new Person[org.getCount()];
        int idx = 0;
        for (Person person : org) {
            people1[idx++] = person;
        }

        Arrays.sort(people);
        Arrays.sort(people1);

        Assert.assertArrayEquals(people, people1);
    }

    @Test
    public void Add_MultipleElements_ShouldIncreaseCount() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        // Act
        for (Person person : people) {
            org.add(person);
        }

        // Assert
        Assert.assertEquals(people.length, org.getCount());
    }

    @Test
    public void Add_MultipleElements_ShouldAddElementsInCorrectInsertionOrder() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        // Act
        for (Person person : people) {
            org.add(person);
        }

        Iterable<Person> people1 = org.peopleByInsertOrder();
        Person[] result = new Person[org.getCount()];
        int index = 0;
        for (Person person : people1) {
            result[index++] = person;
        }

        // Assert
        Assert.assertArrayEquals(result, people);
    }

    @Test
    public void GetByName_OnMultipleEqualNames_ShouldReturnCorrectObjects() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("pesho", 350),
                        new Person("Pesho", 1200),
                        new Person("Pesho", 20),
                        new Person("peshO", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("peshO", 3000)
                };

        // Act
        for (Person person : people) {
            org.add(person);
        }

        List<Person> pesho = Arrays.stream(people).filter(e -> e.getName().equals("Pesho")).collect(Collectors.toList());
        Iterable<Person> pehso = org.getByName("Pesho");
        Person[] expected = new Person[pesho.size()];
        for (int i = 0; i < expected.length; i++) {
            expected[i] = pesho.get(i);
        }
        List<Person> result = new ArrayList<>();
        for (Person person : pehso) {
            result.add(person);
        }

        Person[] finalResult = new Person[result.size()];
        for (int i = 0; i < finalResult.length; i++) {
            finalResult[i] = result.get(i);
        }

        Arrays.sort(expected);
        Arrays.sort(finalResult);

        Assert.assertArrayEquals(expected, finalResult);
    }

    @Test
    public void GetByName_OnNonExistingElement_ShouldReturnEmptyCollection() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        for (Person person : people) {
            org.add(person);
        }

        // Act & Assert
        Iterable<Person> ivan = org.getByName("ivan");
        for (Person person : ivan) {
            Assert.fail();
        }
    }

    @Test
    public void GetAtIndex_WithManyElements_ShouldReturnCorrectly() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        for (Person person : people) {
            org.add(person);
        }

        // Act & Assert
        Assert.assertEquals(people[1], org.getAtIndex(1));
        Assert.assertEquals(people[3], org.getAtIndex(3));
        Assert.assertEquals(people[5], org.getAtIndex(5));
    }

    @Test(expected = IllegalArgumentException.class)
    public void GetAtIndex_OnNonExistingIndex_ShouldThrow() {
        // Arrange
        IOrganization org = new Organization();

        org.getAtIndex(3);
    }

    @Test
    public void GetWithNameSize_OnManyElements_ShouldReturnCorrectElements() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        for (Person person : people) {
            org.add(person);
        }

        List<Person> collect = Arrays.stream(people).filter(p -> p.getName().length() == 4).collect(Collectors.toList());
        Iterable<Person> withNameSize = org.getWithNameSize(4);
        Person[] expected = new Person[collect.size()];
        for (int i = 0; i < expected.length; i++) {
            expected[i] = collect.get(i);
        }
        List<Person> result = new ArrayList<>();
        for (Person person : withNameSize) {
            result.add(person);
        }

        Person[] finalResult = new Person[result.size()];
        for (int i = 0; i < finalResult.length; i++) {
            finalResult[i] = result.get(i);
        }

        Arrays.sort(expected);
        Arrays.sort(finalResult);

        Assert.assertArrayEquals(expected, finalResult);
    }

    @Test(expected = IllegalArgumentException.class)
    public void GetWithNameSize_WithInvalidLength_ShouldThrow() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        for (Person person : people) {
            org.add(person);
        }


        org.getWithNameSize(3);
    }

    @Test(expected = IllegalArgumentException.class)
    public void SearchWithNameSize_OnExistingRange_ShouldReturnElementsInRange() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        for (Person person : people) {
            org.add(person);
        }

        // Act
        org.getWithNameSize(3);
    }

    @Test
    public void FirstInInsertOrder_OnPartialRange_ShouldReturnPartialRange() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        for (Person person : people) {
            org.add(person);
        }

        // Act
        Iterable<Person> people1 = org.firstByInsertOrder(300);
        List<Person> result = new ArrayList<>();
        for (Person person : people1) {
            result.add(person);
        }
        Person[] finalResult = new Person[result.size()];
        for (int i = 0; i < finalResult.length; i++) {
            finalResult[i] = result.get(i);
        }

        // Assert
        Assert.assertArrayEquals(people, finalResult);
    }

    @Test
    public void FirstInInsertOrder_OnNonExistingRange_ShouldReturnEmptyCollection() {
        // Arrange
        IOrganization org = new Organization();

        // Act
        Iterable<Person> result = org.firstByInsertOrder(300);

        // Assert
        for (Person person : result) {
            Assert.fail();
        }
    }

    @Test
    public void FirstByInsertOrder_WithParameters_ShouldReturnCorrectElements() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20)
                };

        for (Person person : people) {
            org.add(person);
        }

        // Act
        Iterable<Person> result = org.firstByInsertOrder(3);
        List<Person> elements = new ArrayList<>();
        for (Person person : result) {
            elements.add(person);
        }
        Person[] finalResult = new Person[elements.size()];
        for (int i = 0; i < elements.size(); i++) {
            finalResult[i] = elements.get(i);
        }


        // Assert
        Assert.assertArrayEquals(people, finalResult);
    }

    @Test
    public void FirstByInsertOrder_WithoutParameters_ShouldReturnFirstElement() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                };

        for (Person person : people) {
            org.add(person);
        }

        // Act
        Iterable<Person> result = org.firstByInsertOrder();
        List<Person> collect = Arrays.stream(people).limit(1).collect(Collectors.toList());
        List<Person> elements = new ArrayList<>();
        for (Person person : result) {
            elements.add(person);
        }

        Person[] expected = new Person[collect.size()];
        Person[] finalResult = new Person[elements.size()];

        int idx = 0;
        for (Person person : collect) {
            expected[idx++] = person;
        }

        idx = 0;
        for (Person element : elements) {
            finalResult[idx++] = element;
        }

        Assert.assertArrayEquals(expected, finalResult);
    }

    @Test
    public void FirstInInsertOrder_OnPartialRange_ShouldReturnPartialRange1() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        for (Person person : people) {
            org.add(person);
        }

        // Act
        Iterable<Person> result = org.firstByInsertOrder(500);
        List<Person> elements = new ArrayList<>();
        for (Person person : result) {
            elements.add(person);
        }

        Person[] finalResult = new Person[elements.size()];
        for (int i = 0; i < finalResult.length; i++) {
            finalResult[i] = elements.get(i);
        }

        Assert.assertArrayEquals(people, finalResult);
    }

    @Test
    public void SearchWithNameSize_OnPartiallyExistingRange_ShouldReturnCorrectElements() {
        // Arrange
        IOrganization org = new Organization();
        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        for (Person person : people) {
            org.add(person);
        }

        // Act
        Iterable<Person> search = org.searchWithNameSize(5, 15);
        List<Person> collect = Arrays.stream(people).filter(p -> p.getName().length() >= 5 && p.getName().length() <= 15).collect(Collectors.toList());
        List<Person> elements = new ArrayList<>();
        for (Person person : search) {
            elements.add(person);
        }

        Person[] expected = new Person[collect.size()];
        for (int i = 0; i < expected.length; i++) {
            expected[i] = collect.get(i);
        }

        Person[] result = new Person[elements.size()];
        for (int i = 0; i < result.length; i++) {
            result[i] = elements.get(i);
        }


        Arrays.sort(expected);
        Arrays.sort(result);

        // Assert
        Assert.assertArrayEquals(expected, result);
    }

    @Test
    public void PeopleByInsertOrder_OnMultipleElements_ShouldReturnCorrectElements() {
        // Arrange
        IOrganization org = new Organization();

        Person[] people = new Person[]
                {
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000),
                        new Person("Ivan", 350),
                        new Person("Pesho", 1200),
                        new Person("Mitko", 20),
                        new Person("Maria", 0),
                        new Person("Stamat", 1500),
                        new Person("Alex", 850),
                        new Person("Rosi", 3000)
                };

        for (Person person : people) {
            org.add(person);
        }

        // Act
        Iterable<Person> result = org.peopleByInsertOrder();
        Person[] finalResult = new Person[org.getCount()];
        int idx = 0;
        for (Person person : result) {
            finalResult[idx++] = person;
        }

        // Assert
        Assert.assertArrayEquals(people, finalResult);
    }
}
