using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private SortedDictionary<string, Person> byEmail;
    private Dictionary<string, SortedSet<Person>> byDomain;
    private Dictionary<string, SortedSet<Person>> byNameAndTown;
    private OrderedDictionary<int, SortedSet<Person>> byAge;
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> byTownAndAge;

    public PersonCollection()
    {
        byEmail = new SortedDictionary<string, Person>();
        byDomain = new Dictionary<string, SortedSet<Person>>();
        byNameAndTown = new Dictionary<string, SortedSet<Person>>();
        byAge = new OrderedDictionary<int, SortedSet<Person>>();
        byTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (byEmail.ContainsKey(email))
        {
            return false;
        }

        var person = new Person(email, name, age, town);

        byEmail.Add(email, person);

        AddByDomain(email, person);

        AddByNameAndTown(name, town, person);

        AddByAge(age, person);

        AddByTownAndAge(age, town, person);

        return true;
    }

    private void AddByTownAndAge(int age, string town, Person person)
    {
        if (!byTownAndAge.ContainsKey(town))
        {
            byTownAndAge.Add(town, new OrderedDictionary<int, SortedSet<Person>>());
        }

        if (!byTownAndAge[town].ContainsKey(age))
        {
            byTownAndAge[town].Add(age, new SortedSet<Person>());
        }

        byTownAndAge[town][age].Add(person);
    }

    private void AddByAge(int age, Person person)
    {
        if (!byAge.ContainsKey(age))
        {
            byAge.Add(age, new SortedSet<Person>());
        }

        byAge[age].Add(person);
    }

    private void AddByNameAndTown(string name, string town, Person person)
    {
        var key = GetNameAndTownKey(name, town);

        if (!byNameAndTown.ContainsKey(key))
        {
            byNameAndTown.Add(key, new SortedSet<Person>());
        }

        byNameAndTown[key].Add(person);
    }

    private static string GetNameAndTownKey(string name, string town)
    {
        return $"{name}{town}";
    }

    private void AddByDomain(string email, Person person)
    {
        var domain = GetDomain(email);

        if (!byDomain.ContainsKey(domain))
        {
            byDomain.Add(domain, new SortedSet<Person>());
        }

        byDomain[domain].Add(person);
    }

    private static string GetDomain(string email)
    {
        return email.Split('@')[1];
    }

    public int Count => byEmail.Count;

    public Person FindPerson(string email)
    {
        return byEmail.ContainsKey(email) ? byEmail[email] : null;
    }

    public bool DeletePerson(string email)
    {
        if (!byEmail.ContainsKey(email))
        {
            return false;
        }

        var person = byEmail[email];

        byEmail.Remove(email);
        byDomain[GetDomain(email)].Remove(person);
        byNameAndTown[GetNameAndTownKey(person.Name, person.Town)].Remove(person);
        byAge[person.Age].Remove(person);
        byTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!byDomain.ContainsKey(emailDomain))
        {
            return Enumerable.Empty<Person>();
        }

        return byDomain[emailDomain];
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var key = GetNameAndTownKey(name, town);

        if (!byNameAndTown.ContainsKey(key))
        {
            return Enumerable.Empty<Person>();
        }

        return byNameAndTown[key];
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var range =  byAge.Range(startAge, true, endAge, true);

        foreach (var kvp in range)
        {
            foreach (var person in kvp.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        if (byTownAndAge.ContainsKey(town))
        {
            var range = byTownAndAge[town].Range(startAge, true, endAge, true);

            foreach (var kvp in range)
            {
                foreach (var person in kvp.Value)
                {
                    yield return person;
                }
            }
        }
    }
}
