using Rest.ASPNET.API.Models;

namespace Rest.ASPNET.API.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for(var i = 0; i < 6; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }

            return people;
        }        

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Matheus",
                LastName = "Ribeiro",
                Address = "Rua teste",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
            => person;
        
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person LastName " + i,
                Address = "SomeAddress " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
