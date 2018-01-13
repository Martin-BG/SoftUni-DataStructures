package enterprise.tests;

import enterprise.Employee;
import enterprise.Enterprise;
import enterprise.IEnterprise;
import enterprise.Position;
import org.junit.Assert;
import org.junit.Test;

import java.util.*;

public class EnterpriceTestCorrectness {

    @Test
    public void addEmployee_ShouldIncreaseCount() {
        IEnterprise enterprise = new Enterprise();

        enterprise.add(
                new Employee("pesho", "gosho", 123, Position.HR, new Date()));

        Assert.assertEquals(1, enterprise.getCount());
    }

    @Test
    public void addManyEmployees_ShouldIncreaseCount() {
        IEnterprise enterprise = new Enterprise();

        enterprise.add(
                new Employee("pesho", "gosho", 123, Position.HR, new Date()));
        enterprise.add(
                new Employee("pesho", "gosho", 123, Position.HR, new Date()));
        enterprise.add(
                new Employee("pesho", "gosho", 123, Position.HR, new Date()));
        enterprise.add(
                new Employee("pesho", "gosho", 123, Position.HR, new Date()));
        enterprise.add(
                new Employee("pesho", "gosho", 123, Position.HR, new Date()));

        Assert.assertEquals(5, enterprise.getCount());
    }

    @Test
    public void addNoEmployees_CountShouldBeZero() {
        IEnterprise enterprise = new Enterprise();

        Assert.assertEquals(0, enterprise.getCount());
    }

    @Test
    public void containsExistingEmployee_ShouldFind() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());
        enterprise.add(employee);

        boolean contains = enterprise.contains(employee.getId());
        Assert.assertTrue(contains);
    }

    @Test
    public void containsNonExistingEmployee_ShouldNotFind() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());
        enterprise.add(employee);

        boolean contains = enterprise.contains(UUID.randomUUID());
        Assert.assertFalse(contains);
    }

    @Test
    public void insertManyEmployees_SearchForExistingEmployee_ShouldReturnTrue() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());
        enterprise.add(employee);
        enterprise.add(new Employee("gosho", "pehso5", 321, Position.DEVELOPER, new Date()));
        enterprise.add(new Employee("gosho1", "pehso4", 321, Position.MANAGER, new Date()));
        enterprise.add(new Employee("gosho2", "pehso3", 321, Position.OWNER, new Date()));
        enterprise.add(new Employee("gosho3", "pehso2", 321, Position.TEAM_LEAD, new Date()));
        enterprise.add(new Employee("gosho4", "pehso1", 321, Position.MANAGER, new Date()));

        boolean contains = enterprise.contains(employee.getId());
        Assert.assertTrue(contains);
    }

    @Test
    public void insertManyEmployees_SearchForNonExistingEmployee_ShouldReturnFalse() {
        IEnterprise enterprise = new Enterprise();

        enterprise.add(new Employee("pesho", "gosho", 123, Position.HR, new Date()));
        enterprise.add(new Employee("gosho", "pehso5", 321, Position.DEVELOPER, new Date()));
        enterprise.add(new Employee("gosho1", "pehso4", 321, Position.MANAGER, new Date()));
        enterprise.add(new Employee("gosho2", "pehso3", 321, Position.OWNER, new Date()));
        enterprise.add(new Employee("gosho3", "pehso2", 321, Position.TEAM_LEAD, new Date()));
        enterprise.add(new Employee("gosho4", "pehso1", 321, Position.MANAGER, new Date()));

        boolean contains = enterprise.contains(UUID.randomUUID());
        Assert.assertFalse(contains);
    }

    @Test
    public void containsEmployeeShouldFind() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());
        enterprise.add(employee);

        Assert.assertTrue(enterprise.contains(employee));
    }

    @Test
    public void containsEmployee_ShouldNotFind() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());
        enterprise.add(employee);

        Assert.assertFalse(enterprise.contains(new Employee("no", "yes", 111, Position.HR, new Date())));
    }

    @Test
    public void insertMany_ContainsShouldReturnTrue() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());
        enterprise.add(employee);

        enterprise.add(new Employee("sosho", "pesho", 321, Position.MANAGER, new Date()));
        enterprise.add(new Employee("posho", "kosho", 55, Position.HR, new Date()));
        enterprise.add(new Employee("gosho", "mosho", 1, Position.MANAGER, new Date()));

        Assert.assertTrue(enterprise.contains(employee));
    }

    @Test
    public void insertMany_ContainsShouldReturnFalse() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());
        enterprise.add(employee);

        enterprise.add(new Employee("sosho", "pesho", 321, Position.MANAGER, new Date()));
        enterprise.add(new Employee("posho", "kosho", 55, Position.HR, new Date()));
        enterprise.add(new Employee("gosho", "mosho", 1, Position.MANAGER, new Date()));

        Employee notInStrcuture = new Employee("not", "in collection", 888, Position.DEVELOPER, new Date());
        Assert.assertFalse(enterprise.contains(notInStrcuture));
    }

    @Test
    public void changeUUIDExistingEmployee() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());
        enterprise.add(employee);

        Employee toReplace = new Employee("replaced", "replacedEmployee", 555, Position.OWNER, new Date());
        enterprise.add(new Employee("sosho", "pesho", 321, Position.MANAGER, new Date()));
        enterprise.add(new Employee("posho", "kosho", 55, Position.HR, new Date()));
        enterprise.add(new Employee("gosho", "mosho", 1, Position.MANAGER, new Date()));

        Assert.assertTrue(enterprise.change(employee.getId(), toReplace));
        Assert.assertTrue(enterprise.contains(employee.getId()));
    }

    @Test
    public void changeUUIDNonExistingEmployee() {
        IEnterprise enterprise = new Enterprise();

        UUID uuid = UUID.randomUUID();
        Employee toReplace = new Employee("replaced", "replacedEmployee", 555, Position.OWNER, new Date());
        Assert.assertFalse(enterprise.change(uuid, toReplace));
    }

    @Test
    public void changeUUIDExistingEmployeeCheckForData() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());
        enterprise.add(employee);

        Employee toReplace = new Employee("replaced", "replacedEmployee", 555, Position.OWNER, new Date());
        enterprise.add(new Employee("sosho", "pesho", 321, Position.MANAGER, new Date()));
        enterprise.add(new Employee("posho", "kosho", 55, Position.HR, new Date()));
        enterprise.add(new Employee("gosho", "mosho", 1, Position.MANAGER, new Date()));

        Assert.assertTrue(enterprise.change(employee.getId(), toReplace));
        Assert.assertTrue(enterprise.contains(employee.getId()));

        Employee byUUID = enterprise.getByUUID(employee.getId());
        Assert.assertEquals("replaced", byUUID.getFirstName());
        Assert.assertEquals("replacedEmployee", byUUID.getLastName());
        Assert.assertEquals(555, byUUID.getSalary(), 0.00001);
    }

    @Test
    public void fireExistingEmployee_ShouldReturnTrue() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "gosho", 123, Position.HR, new Date());

        enterprise.add(employee);
        enterprise.add(new Employee("sosho", "pesho", 321, Position.MANAGER, new Date()));
        enterprise.add(new Employee("posho", "kosho", 55, Position.HR, new Date()));
        enterprise.add(new Employee("gosho", "mosho", 1, Position.MANAGER, new Date()));

        boolean fire = enterprise.fire(employee.getId());
        Assert.assertTrue(fire);
    }

    @Test
    public void fireNonExistingEmployee_ShouldReturnTrue() {
        IEnterprise enterprise = new Enterprise();

        Assert.assertFalse(enterprise.fire(UUID.randomUUID()));
    }

    @Test
    public void fireMultipleEmployees_allShouldBeRemoved_CountShouldDecrese() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 777, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 777, Position.HR, new Date());
        Employee employee3 = new Employee("b", "11111", 777, Position.DEVELOPER, new Date());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        enterprise.add(new Employee("sosho", "pesho", 321, Position.MANAGER, new Date()));
        enterprise.add(new Employee("posho", "kosho", 55, Position.HR, new Date()));
        enterprise.add(new Employee("gosho", "mosho", 1, Position.MANAGER, new Date()));

        Assert.assertTrue(enterprise.fire(employee.getId()));
        Assert.assertTrue(enterprise.fire(employee1.getId()));
        Assert.assertTrue(enterprise.fire(employee2.getId()));
        Assert.assertTrue(enterprise.fire(employee3.getId()));

        Assert.assertEquals(3, enterprise.getCount());
    }

    @Test
    public void fireMultipleEmployees_NoneShouldBeRemoved_CountSame() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 777, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 777, Position.HR, new Date());
        Employee employee3 = new Employee("b", "11111", 777, Position.DEVELOPER, new Date());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        enterprise.add(new Employee("sosho", "pesho", 321, Position.MANAGER, new Date()));
        enterprise.add(new Employee("posho", "kosho", 55, Position.HR, new Date()));
        enterprise.add(new Employee("gosho", "mosho", 1, Position.MANAGER, new Date()));

        Assert.assertEquals(7, enterprise.getCount());

        Assert.assertFalse(enterprise.fire(UUID.randomUUID()));
        Assert.assertFalse(enterprise.fire(UUID.randomUUID()));
        Assert.assertFalse(enterprise.fire(UUID.randomUUID()));
        Assert.assertFalse(enterprise.fire(UUID.randomUUID()));

        Assert.assertEquals(7, enterprise.getCount());
    }

    @Test
    public void insertEmployees_RaiseSalaries_ShouldWorkCorrectly() {
        IEnterprise enterprise = new Enterprise();

        Calendar calendar = new GregorianCalendar(2017, 1, 1);
        Employee employee = new Employee("pesho", "123", 777, Position.HR, calendar.getTime());
        Employee employee1 = new Employee("a", "321", 777, Position.OWNER, calendar.getTime());
        Employee employee2 = new Employee("c", "111", 777, Position.HR, calendar.getTime());
        Employee employee3 = new Employee("b", "11111", 777, Position.DEVELOPER, calendar.getTime());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        boolean b = enterprise.raiseSalary(1, 50);
        Assert.assertTrue(b);

        Iterable<Employee> bySalary = enterprise.getBySalary(0);

        int size = 0;
        for (Employee employee4 : bySalary) {
            size++;
        }

        Assert.assertTrue(size == 4);
    }

    @Test
    public void insertEmployees_RaiseSalaries_CheckForNames() {
        IEnterprise enterprise = new Enterprise();

        Calendar calendar = new GregorianCalendar(2017, 1, 1);
        Employee employee = new Employee("pesho", "123", 777, Position.HR, calendar.getTime());
        Employee employee1 = new Employee("a", "321", 777, Position.OWNER, calendar.getTime());
        Employee employee2 = new Employee("c", "111", 777, Position.HR, calendar.getTime());
        Employee employee3 = new Employee("b", "11111", 777, Position.DEVELOPER, calendar.getTime());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        boolean b = enterprise.raiseSalary(1, 50);
        Assert.assertTrue(b);

        Iterable<Employee> bySalary = enterprise.getBySalary(1165.5);

        List<String> employeesNames = new ArrayList<>();
        for (Employee employee4 : bySalary) {
            employeesNames.add(employee4.getFirstName());
        }

        Collections.sort(employeesNames);
        String[] expected = new String[] { "a", "b", "c", "pesho"};
        int idx = 0;
        for (String employeesName : employeesNames) {
            Assert.assertEquals(expected[idx++], employeesName);
        }
    }

    @Test
    public void raiseSalary_GetByOldSalaryShouldBeRemovedCollection() {
        IEnterprise enterprise = new Enterprise();

        Calendar calendar = new GregorianCalendar(2017, 1, 1);
        Employee employee = new Employee("pesho", "123", 777, Position.HR, calendar.getTime());
        Employee employee1 = new Employee("a", "321", 777, Position.HR, calendar.getTime());
        Employee employee2 = new Employee("c", "111", 777, Position.HR, calendar.getTime());
        Employee employee3 = new Employee("b", "11111", 777, Position.HR, calendar.getTime());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        boolean b = enterprise.raiseSalary(1, 1);
        Assert.assertTrue(b);

        int count = 0;
        for (Employee current : enterprise) {
            count++;
        }

        Assert.assertEquals(4, count);

        count = 0;
        Iterable<Employee> byPosition = enterprise.getByPosition(Position.HR);
        for (Employee employee4 : byPosition) {
            count++;
        }

        Assert.assertEquals(4, count);
    }

    @Test
    public void iterateThroughElements_ShouldBeInTheSameOrder() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 777, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 777, Position.HR, new Date());
        Employee employee3 = new Employee("b", "11111", 777, Position.DEVELOPER, new Date());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);
        Employee employee4 = new Employee("sosho", "pesho", 321, Position.MANAGER, new Date());
        enterprise.add(employee4);
        Employee employee5 = new Employee("posho", "kosho", 55, Position.HR, new Date());
        enterprise.add(employee5);
        Employee employee6 = new Employee("gosho", "mosho", 1, Position.MANAGER, new Date());
        enterprise.add(employee6);

        List<Employee> expectedOrder = new ArrayList<>();
        expectedOrder.add(employee);
        expectedOrder.add(employee1);
        expectedOrder.add(employee2);
        expectedOrder.add(employee3);
        expectedOrder.add(employee4);
        expectedOrder.add(employee5);
        expectedOrder.add(employee6);

        int idx = 0;
        for (Employee current : enterprise) {
            Assert.assertEquals(expectedOrder.get(idx).getId(), current.getId());
            Assert.assertEquals(expectedOrder.get(idx).getFirstName(), current.getFirstName());
            Assert.assertEquals(expectedOrder.get(idx).getLastName(), current.getLastName());
            idx++;
        }
    }

//    enterprise.Employee getByUUID(UUID id);
    @Test
    public void testGettingEmployeeById() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        enterprise.add(employee);

        Employee byUUID = enterprise.getByUUID(employee.getId());
        Assert.assertEquals("pesho", byUUID.getFirstName());
        Assert.assertEquals("123", byUUID.getLastName());
        Assert.assertEquals(777, byUUID.getSalary(), 0.0001);
    }

    @Test(expected = IllegalArgumentException.class)
    public void getEmployeeByIdShouldThrowException() {
        IEnterprise enterprise = new Enterprise();

        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        enterprise.add(employee);

        Employee byUUID = enterprise.getByUUID(UUID.randomUUID());
    }

    @Test(expected = IllegalArgumentException.class)
    public void getByPositionThrowException() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 777, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 777, Position.HR, new Date());
        Employee employee3 = new Employee("b", "11111", 777, Position.DEVELOPER, new Date());

        enterprise.getByPosition(Position.TEAM_LEAD);
    }

    @Test
    public void getByPosition_findOnlyOneEmployee() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 777, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 777, Position.HR, new Date());
        Employee employee3 = new Employee("b", "11111", 777, Position.DEVELOPER, new Date());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        Iterable<Employee> byPosition = enterprise.getByPosition(Position.DEVELOPER);
        Employee next = byPosition.iterator().next();
        Assert.assertEquals(employee3.getId(), next.getId());
        Assert.assertEquals("b", next.getFirstName());
        Assert.assertEquals("11111", next.getLastName());


        int count = 0;
        for (Employee e : byPosition) {
            count++;
        }

        Assert.assertEquals(1, count);
    }

    @Test
    public void getByPosition_FindAllEmployees() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 777, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 777, Position.HR, new Date());
        Employee employee3 = new Employee("b", "11111", 777, Position.DEVELOPER, new Date());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        Iterable<Employee> byPosition = enterprise.getByPosition(Position.HR);
        UUID id = employee.getId();
        UUID id1 = employee2.getId();
        UUID[] uuids = new UUID[2];
        uuids[0] = id;
        uuids[1] = id1;

        int idx = 0;
        for (Employee employee4 : byPosition) {
            Assert.assertEquals(uuids[idx++], employee4.getId());
        }
    }

    @Test
    public void getEmployeesByMinSalary_ShouldReturnAllEmployees() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 123, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 7777777, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 231, Position.DEVELOPER, new Date());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        Employee[] employees = new Employee[] {
                employee1,
                employee2,
                employee3,
                employee
        };


        Iterable<Employee> bySalary = enterprise.getBySalary(0);
        List<Employee> result = new ArrayList<>();
        for (Employee e : bySalary) {
            result.add(e);
        }

        final int[] idx = {0};
        result.stream().sorted(Comparator.comparing(Employee::getFirstName)).forEach(e -> {
            System.out.println(e.getFirstName());
            Assert.assertEquals(employees[idx[0]++].getId(), e.getId());
        });
    }

    @Test(expected = IllegalArgumentException.class)
    public void getEmployeesBySalaryThrowException() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 777, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 123, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 1, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 231, Position.DEVELOPER, new Date());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        Employee[] employees = new Employee[] {
                employee1,
                employee2,
                employee3,
                employee
        };


        Iterable<Employee> bySalary = enterprise.getBySalary(1000000);
    }

    @Test
    public void getOnlyOneEmployeeWithSalarySameAsSearched() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 123, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 55, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 1, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 2, Position.DEVELOPER, new Date());

        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);

        Employee[] employees = new Employee[] {
                employee1,
                employee2,
                employee3,
                employee
        };


        Iterable<Employee> bySalary = enterprise.getBySalary(123);
        int count = 0;
        for (Employee employee4 : bySalary) {
            count++;
        }

        Assert.assertEquals(1, count);

        Employee next = bySalary.iterator().next();
        Assert.assertEquals(employee.getId(), next.getId());
    }


    @Test(expected = IllegalArgumentException.class)
    public void getEmployeesBySalaryAndPosition_ThrowException() {
        IEnterprise enterprise = new Enterprise();

        enterprise.getBySalaryAndPosition(111, Position.TEAM_LEAD);
    }


    @Test
    public void getEmployeesBySalary_ShouldFindCorrectEmployees() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 123, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 55, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 1, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 123, Position.DEVELOPER, new Date());


        enterprise.add(employee);
        enterprise.add(employee1);
        enterprise.add(employee2);
        enterprise.add(employee3);
        enterprise.add(employee4);

        Employee[] expected = new Employee[] {
                employee3,
                employee4
        };

        Iterable<Employee> bySalaryAndPosition = enterprise.getBySalaryAndPosition(123, Position.DEVELOPER);

        List<Employee> result = new ArrayList<>();
        for (Employee e : bySalaryAndPosition) {
            result.add(e);
        }

        final int[] idx = {0};
        result.stream().sorted(Comparator.comparing(Employee::getFirstName))
                .forEach(e -> Assert.assertEquals(expected[idx[0]++].getId(), e.getId()));
    }

    @Test
    public void searchBySalary_ShouldReturnEmptyCollection() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Iterable<Employee> employees = enterprise.searchBySalary(0, 0);
        for (Employee e : employees) {
            Assert.fail();
        }
    }

    @Test
    public void searchBySalary_ReturnAllEmployees() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Employee[] employees = new Employee[] {
                employee1,
                employee2,
                employee3,
                employee4,
                employee,
        };

        for (Employee e : employees) {
            enterprise.add(e);
        }

        Iterable<Employee> result = enterprise.searchBySalary(11266, 1156123);
        List<Employee> all = new ArrayList<>();
        for (Employee e : result) {
            all.add(e);
        }

        Assert.assertEquals(5, all.size());

        final int[] idx = {0};
        all.stream().sorted(Comparator.comparing(Employee::getFirstName))
                .forEach(e -> Assert.assertEquals(employees[idx[0]++].getId(), e.getId()));
    }

    @Test
    public void searchBySalary_FindOnlyOne() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Employee[] employees = new Employee[]{
                employee1,
                employee2,
                employee3,
                employee4,
                employee,
        };

        for (Employee e : employees) {
            enterprise.add(e);
        }

        Iterable<Employee> result = enterprise.searchBySalary(11266, 11266);
        int count = 0;
        for (Employee e : result) {
            count++;
        }

        Assert.assertEquals(1, count);

        Employee next = result.iterator().next();
        Assert.assertEquals(employee2.getId(), next.getId());
    }

    @Test
    public void searchByPositionEmptyCollection() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Employee[] employees = new Employee[]{
                employee1,
                employee2,
                employee3,
                employee4,
                employee,
        };

        for (Employee e : employees) {
            enterprise.add(e);
        }

        List<Position> positions = new ArrayList<>();
        positions.add(Position.MANAGER);

        Iterable<Employee> result = enterprise.searchByPosition(positions);
        for (Employee e : result) {
            Assert.fail();
        }
    }

    @Test
    public void searchByPositionShouldFindEmployees() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Employee[] employees = new Employee[]{
                employee1,
                employee2,
                employee3,
                employee4,
                employee,
        };

        Employee[] expected = new Employee[] {
                employee1,
                employee3,
                employee4
        };

        for (Employee e : employees) {
            enterprise.add(e);
        }

        List<Position> positions = new ArrayList<>();
        positions.add(Position.DEVELOPER);
        positions.add(Position.OWNER);

        Iterable<Employee> result = enterprise.searchByPosition(positions);
        List<Employee> foundEmployees = new ArrayList<>();
        for (Employee e : result) {
            foundEmployees.add(e);
        }

        final int[] idx = {0};
        foundEmployees.stream().sorted(Comparator.comparing(Employee::getFirstName))
                .forEach(e -> {
                    Assert.assertEquals(expected[idx[0]++].getId(), e.getId());
                });
    }

    @Test
    public void findEmployeesByFirstName_ReturnEmptyCollection() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Iterable<Employee> e = enterprise.searchByFirstName("gosho");
        for (Employee e1 : e) {
            Assert.fail();
        }
    }

    @Test
    public void findEmployeeByFirstName_WorkCorrectly() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("a", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Employee[] employees = new Employee[]{
                employee1,
                employee2,
                employee3,
                employee4,
                employee,
        };
        for (Employee employee5 : employees) {
            enterprise.add(employee5);
        }

        Iterable<Employee> e = enterprise.searchByFirstName("a");
        for (Employee e1 : e) {
            if (!e1.getLastName().equals("123") && !e1.getLastName().equals("321")) {
                Assert.fail();
            }
        }
    }

    @Test
    public void findByName_GetOnlyOneEmployee() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("a", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("b", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Employee[] employees = new Employee[]{
                employee1,
                employee2,
                employee3,
                employee4,
                employee,
        };
        for (Employee employee5 : employees) {
            enterprise.add(employee5);
        }

        Iterable<Employee> a = enterprise.searchByFirstName("a");
        int count = 0;
        for (Employee e : a) {
            count++;
        }

        Assert.assertEquals(1, count);

        Employee next = a.iterator().next();
        Assert.assertEquals(employee.getId(), next.getId());
    }


    //Iterable<enterprise.Employee> searchByNameAndPosition(String firstName, String lastName, enterprise.Position position);

    @Test
    public void searchByNameAndPositionEmptyCollection() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("a", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("b", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Employee[] employees = new Employee[]{
                employee1,
                employee2,
                employee3,
                employee4,
                employee,
        };

        for (Employee employee5 : employees) {
            enterprise.add(employee5);
        }

        Iterable<Employee> employees1 = enterprise.searchByNameAndPosition("gosho", "pesho", Position.TEAM_LEAD);
        for (Employee employee5 : employees1) {
            Assert.fail();
        }
    }

    @Test
    public void searchByNameAndPositionFindAllEmployees() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("a", "b", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "b", 51255, Position.HR, new Date());
        Employee employee2 = new Employee("a", "b", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("a", "b", 1156123, Position.HR, new Date());
        Employee employee4 = new Employee("a", "b", 126126, Position.HR, new Date());

        Employee[] employees = new Employee[]{
                employee,
                employee1,
                employee2,
                employee3,
                employee4
        };

        for (Employee employee5 : employees) {
            enterprise.add(employee5);
        }

        Iterable<Employee> employees1 = enterprise.searchByNameAndPosition("a", "b", Position.HR);
        int idx = 0;

        for (Employee employee5 : employees1) {
            Assert.assertEquals(employees[idx++].getId(), employee5.getId());
        }
    }

    @Test
    public void searchByNameAndPositionFindOneEmployee() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("a", "b", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("asd", "123", 51255, Position.HR, new Date());
        Employee employee2 = new Employee("asd", "321", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("asd", "123123", 1156123, Position.HR, new Date());
        Employee employee4 = new Employee("asd", "321321", 126126, Position.HR, new Date());

        Employee[] employees = new Employee[]{
                employee,
                employee1,
                employee2,
                employee3,
                employee4
        };

        for (Employee employee5 : employees) {
            enterprise.add(employee5);
        }

        Iterable<Employee> employees1 = enterprise.searchByNameAndPosition("a", "b", Position.HR);
        int count = 0;
        for (Employee employee5 : employees1) {
            count++;
        }

        Assert.assertEquals(1, count);

        Employee next = employees1.iterator().next();
        Assert.assertEquals(employee.getId(), next.getId());
    }

    //    Iterable<enterprise.Employee> allWithPositionAndMinSalary(enterprise.Position position, double minSalary);

    @Test
    public void searchAllWithPositionAndMinSalaryReturnNothing() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Employee[] employees = new Employee[]{
                employee,
                employee1,
                employee2,
                employee3,
                employee4
        };

        for (Employee e : employees) {
            enterprise.add(e);
        }

        Iterable<Employee> all = enterprise.allWithPositionAndMinSalary(Position.MANAGER, 1);
        for (Employee e : all) {
            Assert.fail();
        }
    }

    @Test
    public void searchAllWithPositionAndMinSalaryWorkCorrect() {
        IEnterprise enterprise = new Enterprise();
        Employee employee = new Employee("pesho", "123", 62342, Position.HR, new Date());
        Employee employee1 = new Employee("a", "321", 51255, Position.OWNER, new Date());
        Employee employee2 = new Employee("c", "111", 11266, Position.HR, new Date());
        Employee employee3 = new Employee("d", "11111", 1156123, Position.DEVELOPER, new Date());
        Employee employee4 = new Employee("e", "11111", 126126, Position.DEVELOPER, new Date());

        Employee[] employees = new Employee[]{
                employee,
                employee1,
                employee2,
                employee3,
                employee4
        };

        Employee[] expected = new Employee[] {
                employee,
                employee2
        };

        for (Employee e : employees) {
            enterprise.add(e);
        }

        Iterable<Employee> all = enterprise.allWithPositionAndMinSalary(Position.HR, 1);
        int idx = 0;
        for (Employee e : all) {
            Assert.assertEquals(expected[idx++].getId(), e.getId());
        }
    }
}
