package enterprise.tests;

import enterprise.Employee;
import enterprise.Enterprise;
import enterprise.IEnterprise;
import enterprise.Position;
import org.junit.Assert;
import org.junit.Test;

import java.util.*;

public class EnterpriseTestsPerformance {

    @Test
    public void addEmployees() {
        IEnterprise enterprise = new Enterprise();

        long l = System.currentTimeMillis();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            enterprise.add(employee);
        }

        long l1 = System.currentTimeMillis();

        int count = enterprise.getCount();
        Assert.assertEquals(10000, count);

        Assert.assertTrue(l1 - l < 350);
    }

    @Test
    public void containsEmployees() {
        IEnterprise enterprise = new Enterprise();

        long l = System.currentTimeMillis();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l1 = System.currentTimeMillis();

        int count = enterprise.getCount();
        Assert.assertEquals(10000, count);

        Assert.assertTrue(l1 - l < 350);

        for (Employee employee : employees) {
            Assert.assertEquals(Boolean.TRUE, enterprise.contains(employee));
        }
    }

    @Test
    public void containsEmployeeId() {
        IEnterprise enterprise = new Enterprise();

        long l = System.currentTimeMillis();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }


        int count = enterprise.getCount();
        Assert.assertEquals(10000, count);

        long l1 = System.currentTimeMillis();

        Assert.assertTrue(l1 - l < 350);

        for (Employee employee : employees) {
            Assert.assertEquals(Boolean.TRUE, enterprise.contains(employee.getId()));
        }
    }

    @Test
    public void changeId() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }


        int count = enterprise.getCount();
        Assert.assertEquals(10000, count);


        long l = System.currentTimeMillis();

        for (Employee employee : employees) {
            Assert.assertEquals(Boolean.TRUE, enterprise.contains(employee.getId()));
            Employee byUUID = enterprise.getByUUID(employee.getId());
            enterprise.change(UUID.randomUUID(), byUUID);
        }
        long l1 = System.currentTimeMillis();

        Assert.assertTrue(l1 - l < 150);
    }

    @Test
    public void fireAllEmployees() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();
        Assert.assertEquals(10000, enterprise.getCount());


        for (Employee employee : employees) {
            enterprise.fire(employee.getId());
        }

        long l1 = System.currentTimeMillis();

        Assert.assertTrue(l1 - l < 150);
    }

    @Test
    public void raiseSalary() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        Assert.assertEquals(10000, enterprise.getCount());

        long l = System.currentTimeMillis();

        enterprise.raiseSalary(new Date().getMonth(), 1);

        long l1 = System.currentTimeMillis();

        Assert.assertTrue(l1 - l < 150);
    }

    @Test
    public void getById() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        for (Employee employee : employees) {
            Employee byUUID = enterprise.getByUUID(employee.getId());
            Assert.assertNotNull(byUUID);
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
    }

    @Test
    public void positionById() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        for (Employee employee : employees) {
            Position byUUID = enterprise.positionByUUID(employee.getId());
            Assert.assertNotNull(byUUID);
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
    }

    @Test
    public void getByPosition() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        Iterable<Employee> byPosition = enterprise.getByPosition(Position.HR);
        int count = 0;
        for (Employee employee : byPosition) {
            count++;
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
        Assert.assertEquals(10000, count);
    }

    @Test
    public void getBySalary() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        Iterable<Employee> byPosition = enterprise.getBySalary(1);
        int count = 0;
        for (Employee employee : byPosition) {
            count++;
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
        Assert.assertEquals(10000, count);
    }

    @Test
    public void getBySalaryAndPosition() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        Iterable<Employee> byPosition = enterprise.getBySalaryAndPosition(1, Position.HR);
        int count = 0;
        for (Employee employee : byPosition) {
            count++;
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
        Assert.assertEquals(10000, count);
    }

    @Test
    public void searchBySalary() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        Iterable<Employee> byPosition = enterprise.searchBySalary(1, 1);
        int count = 0;
        for (Employee employee : byPosition) {
            count++;
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
        Assert.assertEquals(10000, count);
    }

    @Test
    public void searchByPosition() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        List<Position> positions = new ArrayList<>();
        positions.add(Position.HR);
        Iterable<Employee> byPosition = enterprise.searchByPosition(positions);
        int count = 0;
        for (Employee employee : byPosition) {
            count++;
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
        Assert.assertEquals(10000, count);
    }

    @Test
    public void allWithPositionAndMinSalary() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1 + i, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        Iterable<Employee> byPosition = enterprise.allWithPositionAndMinSalary(Position.HR, 50);
        int count = 0;
        for (Employee employee : byPosition) {
            count++;
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
        Assert.assertEquals(9951, count);
    }

    @Test
    public void searchByFirstName() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1 + i, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        Iterable<Employee> byPosition = enterprise.searchByFirstName("a0");
        int count = 0;
        for (Employee employee : byPosition) {
            count++;
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
        Assert.assertEquals(1, count);
    }

    @Test
    public void searchByNameAndPosition() {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new ArrayList<>();
        for (int i = 0; i < 10000; i++) {
            Employee employee = new Employee("a" + i, "a" + i, 1 + i, Position.HR, new Date());

            employees.add(employee);
            enterprise.add(employee);
        }

        long l = System.currentTimeMillis();

        Iterable<Employee> byPosition = enterprise.searchByNameAndPosition("a0", "a0",  Position.HR);
        int count = 0;
        for (Employee employee : byPosition) {
            count++;
        }

        long l1 = System.currentTimeMillis();
        Assert.assertTrue(l1 - l < 150);
        Assert.assertEquals(1, count);
    }
}
