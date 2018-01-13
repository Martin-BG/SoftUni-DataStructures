package enterprise;

import java.util.Date;
import java.util.UUID;

public class Employee implements Comparable<Employee> {

    private UUID id;

    private Position position;

    private Date hireDate;

    private String firstName;

    private String lastName;

    private double salary;

    public Employee(String firstName, String lastName, double salary, Position position, Date hireDate) {
        this.id = UUID.randomUUID();

        this.setFirstName(firstName);
        this.setLastName(lastName);
        this.setSalary(salary);
        this.setPosition(position);
        this.setHireDate(hireDate);
    }

    public UUID getId() {
        return this.id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public Position getPosition() {
        return this.position;
    }

    public void setPosition(Position position) {
        this.position = position;
    }

    public Date getHireDate() {
        return this.hireDate;
    }

    public void setHireDate(Date hireDate) {
        this.hireDate = hireDate;
    }

    public String getFirstName() {
        return this.firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return this.lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public double getSalary() {
        return this.salary;
    }

    public void setSalary(double salary) {
        this.salary = salary;
    }

    @Override
    public int compareTo(Employee o) {
        return this.id.compareTo(o.getId());
    }

    @Override
    public int hashCode() {
        return this.id.hashCode();
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("enterprise.Employee{");
        sb.append("id=").append(id);
        sb.append(", position=").append(position);
        sb.append(", hireDate=").append(hireDate);
        sb.append(", firstName='").append(firstName).append('\'');
        sb.append(", lastName='").append(lastName).append('\'');
        sb.append(", salary=").append(salary);
        sb.append('}');
        return sb.toString();
    }
}
