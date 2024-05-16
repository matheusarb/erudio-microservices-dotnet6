using Rest.ASPNET.API.Models;

namespace Rest.ASPNET.API.Services
{
    public interface IPersonService
    {
        Person FindById(long id);
        List<Person> FindAll();
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
