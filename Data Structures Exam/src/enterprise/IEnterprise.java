package enterprise;

import java.util.UUID;

public interface IEnterprise extends Iterable<Employee> {

    void add(Employee employee);

    boolean contains(UUID id);

    boolean contains(Employee employee);

    boolean change(UUID id, Employee employee);

    boolean fire(UUID id);

    boolean raiseSalary(int months, int percent);

    int getCount();

    Employee getByUUID(UUID id);

    Position positionByUUID(UUID id);

    Iterable<Employee> getByPosition(Position position);

    Iterable<Employee> getBySalary(double minSalary);

    Iterable<Employee> getBySalaryAndPosition(double salary, Position position);

    Iterable<Employee> searchBySalary(double minSalary, double maxSalary);

    Iterable<Employee> searchByPosition(Iterable<Position> positions);

    Iterable<Employee> allWithPositionAndMinSalary(Position position, double minSalary);

    Iterable<Employee> searchByFirstName(String firstName);

    Iterable<Employee> searchByNameAndPosition(String firstName, String lastName, Position position);
}
