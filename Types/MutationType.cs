using DemoChoco.Data;
using HotChocolate.Types;

namespace HotChocolate.Validation.Types
{
    public class MutationType
        : ObjectType
    {
        private readonly DataRepository dataRepository = new DataRepository();

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Mutation");

            descriptor.Field("fieldB")
                .Type<NonNullType<StringType>>()
                .Resolve(() => "foo");

            descriptor.Field("addPet")
                .Argument("pet", a => a.Type<PetInputType>())
                .Type<PetType>()
                .Resolve((context) =>
                {
                    var pets = context.ArgumentValue<Dictionary<string, Dictionary<string, object>>>("pet");
                    if (pets.TryGetValue("cat", out var cat))
                    {
                        dataRepository.AddCat(cat.Values.ToList()); 
                    }
                    if (pets.TryGetValue("dog", out var dog))
                    {
                        dataRepository.AddDog(dog.Values.ToList());
                    }
                    return dataRepository.cats.FirstOrDefault();
                }) ;
        }

        public Query GetField([Parent] Query query, string a, string b, string c, string d) => new Query { A = a, B = b, C = c, D = d };
    }
}
