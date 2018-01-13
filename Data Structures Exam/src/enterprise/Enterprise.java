package enterprise;

import java.util.*;
import java.util.stream.Collectors;


public class Enterprise implements IEnterprise {

    private Map<UUID, Employee> byId;
    private Map<Position, List<Employee>> byPosition;

    public Enterprise() {
        this.byId = new LinkedHashMap<>();
        this.byPosition = new HashMap<Position, List<Employee>>() {{
            put(Position.DEVELOPER, new ArrayList<>());
            put(Position.MANAGER, new ArrayList<>());
            put(Position.HR, new ArrayList<>());
            put(Position.TEAM_LEAD, new ArrayList<>());
            put(Position.OWNER, new ArrayList<>());
        }};
    }

    @Override
    public void add(Employee employee) {
        this.byId.put(employee.getId(), employee);
        this.byPosition.get(employee.getPosition()).add(employee);
    }

    @Override
    public boolean contains(UUID id) {
        return this.byId.containsKey(id);
    }

    @Override
    public boolean contains(Employee employee) {
        return this.byId.containsKey(employee.getId());
    }

    @Override
    public boolean change(UUID id, Employee employee) {
        if (this.contains(id)) {
            this.byPosition.get(employee.getPosition()).remove(employee);

            Employee current = this.byId.get(id);
            current.setFirstName(employee.getFirstName());
            current.setLastName(employee.getLastName());
            current.setHireDate(employee.getHireDate());
            current.setPosition(employee.getPosition());
            current.setSalary(employee.getSalary());

            this.byPosition.get(employee.getPosition()).add(current);

            return true;
        }

        return false;
    }

    @Override
    public boolean fire(UUID id) {
        if (!this.contains(id)) {
            return false;
        }

        Employee employee = this.getByUUID(id);

        this.byId.remove(employee.getId());
        this.byPosition.get(employee.getPosition()).remove(employee);

        return true;
    }

    @Override
    public boolean raiseSalary(int months, int percent) {
        Date currentDate = new Date();
        int currentYear = currentDate.getYear();
        int currentMonth = currentDate.getMonth();

        List<Employee> matches = new ArrayList<>();
        this.byId.values().stream()
                .filter(employee -> ((currentYear - employee.getHireDate().getYear()) * 12 +
                        currentMonth - employee.getHireDate().getMonth()) >= months)
                .forEach(matches::add);

        double increase = (100.0 + percent) / 100.0;
        for (Employee employee : matches) {
            employee.setSalary(employee.getSalary() * increase);
        }

        return !matches.isEmpty();
    }

    @Override
    public int getCount() {
        return this.byId.size();
    }

    @Override
    public Employee getByUUID(UUID id) {
        Employee employee = this.byId.get(id);

        if (employee == null) {
            throw new IllegalArgumentException();
        }

        return employee;
    }

    @Override
    public Position positionByUUID(UUID id) {
        if (!this.byId.containsKey(id)) {
            throw new IllegalArgumentException();
        }
        return this.getByUUID(id).getPosition();
    }

    @Override
    public Iterable<Employee> getByPosition(Position position) {
        if (this.byPosition.get(position).isEmpty()) {
            throw new IllegalArgumentException();
        }
        return this.byPosition.get(position);
    }

    @Override
    public Iterable<Employee> getBySalary(double minSalary) {
        List<Employee> result = this.byId.values().stream()
                .filter(employee -> employee.getSalary() >= minSalary)
                .collect(Collectors.toList());

        if (result.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return result;
    }

    @Override
    public Iterable<Employee> getBySalaryAndPosition(double salary, Position position) {
        List<Employee> result = this.byPosition.get(position).stream()
                .filter(employee -> employee.getSalary() == salary)
                .collect(Collectors.toList());

        if (result.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return result;
    }

    @Override
    public Iterable<Employee> searchBySalary(double minSalary, double maxSalary) {
        return this.byId.values().stream()
                .filter(employee -> employee.getSalary() >= minSalary && employee.getSalary() <= maxSalary)
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Employee> searchByPosition(Iterable<Position> positions) {
        Collection<Employee> result = new ArrayList<>();
        for (Position position : positions) {
            result.addAll(this.byPosition.get(position));
        }
        return result;
    }

    @Override
    public Iterable<Employee> allWithPositionAndMinSalary(Position position, double minSalary) {
        return this.byPosition.get(position).stream()
                .filter(employee -> employee.getSalary() >= minSalary)
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Employee> searchByFirstName(String firstName) {
        return this.byId.values().stream()
                .filter(employee -> firstName.equals(employee.getFirstName()))
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Employee> searchByNameAndPosition(String firstName, String lastName, Position position) {
        return this.byId.values().stream()
                .filter(employee -> employee.getPosition() == position &&
                        firstName.equals(employee.getFirstName()) &&
                        lastName.equals(employee.getLastName()))
                .collect(Collectors.toList());
    }

    @Override
    public Iterator<Employee> iterator() {
        return this.byId.values().iterator();
    }
}
