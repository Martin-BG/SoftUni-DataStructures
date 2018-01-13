package organization;

import java.util.*;

public class Organization implements IOrganization {

    private List<Person> personList;
    private NavigableMap<Integer, Set<Person>> personsByNameLength;
    private Map<String, Set<Person>> personsByName;

    public Organization() {
        this.personList = new ArrayList<>();
        this.personsByNameLength = new TreeMap<>();
        this.personsByName = new HashMap<>();
    }

    @Override
    public int getCount() {
        return this.personList.size();
    }

    @Override
    public boolean contains(Person person) {
        Set set = this.personsByName.get(person.getName());
        return set != null && set.contains(person);
    }

    @Override
    public boolean containsByName(String name) {
        return this.personsByName.containsKey(name);
    }

    @Override
    public void add(Person person) {
        this.personList.add(person);
        String name = person.getName();
        int nameLength = name.length();
        this.personsByNameLength.putIfAbsent(nameLength, new LinkedHashSet<>());
        this.personsByNameLength.get(nameLength).add(person);
        this.personsByName.putIfAbsent(name, new LinkedHashSet<>());
        this.personsByName.get(name).add(person);
    }

    @Override
    public Person getAtIndex(int index) {
        if (index >= this.getCount()) {
            throw new IllegalArgumentException();
        }
        return this.personList.get(index);
    }

    @Override
    public Iterable<Person> getByName(String name) {
        Set<Person> set = this.personsByName.get(name);
        if (set == null) {
            return new ArrayList<>();
        }
        return set;
    }

    @Override
    public Iterable<Person> firstByInsertOrder() {
        return this.personList.subList(0, 1);
    }

    @Override
    public Iterable<Person> firstByInsertOrder(int count) {
        if (count > this.getCount()) {
            count = this.getCount();
        }
        return this.personList.subList(0, count);
    }

    @Override
    public Iterable<Person> searchWithNameSize(int minLength, int maxLength) {
        List<Person> persons = new ArrayList<>();
        this.personsByNameLength.subMap(minLength, maxLength).values().forEach(persons::addAll);
        return persons;
    }

    @Override
    public Iterable<Person> getWithNameSize(int length) {
        if (!this.personsByNameLength.containsKey(length)) {
            throw new IllegalArgumentException();
        }
        return this.personsByNameLength.get(length);
    }

    @Override
    public Iterable<Person> peopleByInsertOrder() {
        return this.personList;
    }

    @Override
    public Iterator<Person> iterator() {
        return this.personList.iterator();
    }
}
