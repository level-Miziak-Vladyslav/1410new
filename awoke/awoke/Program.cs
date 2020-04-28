using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test
{
    public class Programm
    {
        public static ICustomerService _customerService = new CustomerService();

        public static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());

            Process();

            Console.ReadLine();
        }

        public static async void Process()
        {
            try
            {
                Task<GeneralInfo> generalInfo = _customerService.GetGeneralInfo();
                PersonalInfo personalInfo = await _customerService.GetPersonalInfo().ConfigureAwait(false);

                Task.WaitAll(generalInfo);

                Person p = new Person
                {
                    GeneralInfo = generalInfo.Result,
                    PersonalInfo = personalInfo
                };

                Console.WriteLine($"Surname: {p.GeneralInfo.Surname} \n {p.PersonalInfo.Age}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class GeneralInfo
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }

    public class PersonalInfo
    {
        public int Age { get; set; }

        public int Weight { get; set; }
    }

    public interface ICustomerService
    {
        Task<PersonalInfo> GetPersonalInfo();

        Task<GeneralInfo> GetGeneralInfo();
    }

    public class Person
    {
        public PersonalInfo PersonalInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
    }

    public class CustomerService : ICustomerService
    {
        public async Task<GeneralInfo> GetGeneralInfo()
        {
            await Task.Delay(2000);
            return new GeneralInfo
            {
                Name = "SomeName",
                Surname = "SomeSurname"
            };
        }

        public async Task<PersonalInfo> GetPersonalInfo()
        {
            await Task.Delay(4000);
            return new PersonalInfo
            {
                Age = 22,
                Weight = 70
            };
        }
    }

}
