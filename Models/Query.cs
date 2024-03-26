using HotChocolate.Validation.Types;
using Microsoft.AspNetCore.CookiePolicy;
using DemoChoco.Data;
using DemoChoco.Models;

namespace HotChocolate.Validation
{
    public class Query
    {
        public Query()
        {
            A = "A";
            B = "B";
            C = "C";
            D = "D";
            Y = "Y";
            dataRepository = new DataRepository();
        }

        private readonly DataRepository dataRepository;

        public string A { get; set; }

        public string B { get; set; }

        public string C { get; set; }

        public string D { get; set; }

        public string Y { get; set; }

        public Query F1 => new Query();

        public Query F2 => new Query();

        public Query F3 => new Query();

        public Query GetField() => this;

        public Dog? GetDog()
        {
            return dataRepository.dogs.FirstOrDefault();
        }

        public Dog? FindDog(ComplexInput? complex)
        {
            if (complex == null)
                return null;

            if (complex.Owner != null)
            {
                return dataRepository.dogs.FirstOrDefault(_ => _.Name == complex.Name && _.Owner?.Name == complex.Owner);
            }
            return dataRepository.dogs.FirstOrDefault(_ => _.Name == complex.Name);
        }

        public Dog FindDog2(ComplexInput2 complex)
        {
            if (complex.Owner != null)
            {
                return dataRepository.dogs.FirstOrDefault(_ => _.Name == complex?.Name && _.Owner?.Name == complex.Owner);
            }
            return dataRepository.dogs.FirstOrDefault(_ => _.Name == complex?.Name);
        }

        public bool? BooleanList(bool[]? booleanListArg)
        {
            return true;
        }

        public Human GetHuman()
        {
            return dataRepository.humans.FirstOrDefault();
        }

        public IPet GetPet()
        {
            return dataRepository.dogs.FirstOrDefault();
        }

        public IPet[] GetPets()
        {
            return dataRepository.cats.ToArray();
        }

        public IBeing GetBeing()
        {
            return dataRepository.dogs.FirstOrDefault();
        }

        public IBeing[] GetBeings()
        {
            return dataRepository.dogs.ToArray();
        }

        public object GetCatOrDog()
        {
            return dataRepository.dogs.FirstOrDefault();
        }

        public object GetDogOrHuman()
        {
            return dataRepository.humans.FirstOrDefault();
        }

        public string[] GetStringList()
        {
            return dataRepository.stringList;
        }

        public int[] GetIntegerList()
        {
            return dataRepository.integerList;
        }

        public string GetFieldWithArg(
            string arg,
            string arg1,
            string arg2,
            string arg3)
        {
            return arg;
        }

    }
}
