using HotChocolate.Validation;
using System.Globalization;

namespace DemoChoco.Data
{
    public class DataRepository
    {
        public List<Human> humans = new List<Human>
        {
            new Human
            {
                Name = "foo",
                Address = "foo"
            },
            new Human
            {
                Name = "foo2",
                Address = "foo2"
            }
        };

        public List<Dog> dogs = new List<Dog>
        {
            new Dog
            {
                Barks = true,
                BarkVolume = 1,
                Name =  "Tofu",
                Nickname = "Tofu",
                Owner = new Human
                {
                    Name = "foo",
                    Address = "foo"
                }
            },
            new Dog
            {
                Barks = true,
                BarkVolume = 3,
                Name =  "Ink",
                Nickname = "Ink"
            }
        };

        public List<Cat> cats = new List<Cat>
        {
            new Cat
            {
                MeowVolume = 1,
                Name =  "Tofu",
                Nickname = "Tofu"
            },
            new Cat
            {
                MeowVolume = 3,
                Name =  "Ink",
                Nickname = "Ink"
            }
        };

        public string[] stringList =
        {
            "foo", "asd", "bar", "baz"
        };

        public void AddCat(List<Object> cat)
        {
            cats.Add(new Cat
            {
                Name = (string)cat[0],
                MeowVolume = (int?)cat[2],
                Nickname = (string)cat[1]
            });
        }

        public void AddDog(List<Object> dog)
        {
            dogs.Add(new Dog
            {
                Name = (string)dog[0],
                BarkVolume = (int?)dog[2],
                Nickname = (string)dog[1]
            });
        }
    }
}
