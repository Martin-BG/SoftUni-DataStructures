package organization;

public interface IOrganization extends Iterable<Person> {

    int getCount();

    boolean contains(Person person);

    boolean containsByName(String name);

    void add(Person person);

    Person getAtIndex(int index);

    Iterable<Person> getByName(String name);

    Iterable<Person> firstByInsertOrder();

    Iterable<Person> firstByInsertOrder(int count);

    Iterable<Person> searchWithNameSize(int minLength, int maxLength);

    Iterable<Person> getWithNameSize(int length);

    Iterable<Person> peopleByInsertOrder();
}