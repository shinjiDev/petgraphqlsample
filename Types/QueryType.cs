using DemoChoco;
using HotChocolate.Types;

namespace HotChocolate.Validation.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field("arguments")
                .Type<ArgumentsType>()
                .Resolve(new ArgumentsType());

            descriptor.Field("invalidArg")
                .Type<StringType>()
                .Argument("arg", a => a.Type<InvalidScalar>())
                .Resolve((ctx) => ctx.ArgumentValue<string>("arg"));

            descriptor.Field("anyArg")
                .Type<StringType>()
                .Argument("arg", a => a.Type<AnyType>())
                .Resolve((ctx) => ctx.ArgumentValue<string>("arg"));

            descriptor.Field("field")
                .Argument("a", a => a.Type<StringType>())
                .Argument("b", a => a.Type<StringType>())
                .Argument("c", a => a.Type<StringType>())
                .Argument("d", a => a.Type<StringType>())
                .Type<QueryType>()
                .Resolve(() => new Query());

            descriptor.Field(t => t.GetCatOrDog())
                .Type<CatOrDogType>();

            descriptor.Field(t => t.GetDogOrHuman())
                .Type<DogOrHumanType>();

            descriptor.Field("nonNull")
                .Argument("a", a => a.Type<NonNullType<StringType>>().DefaultValue("abc"))
                .Resolve((ctx) => ctx.ArgumentValue<string>("a"));
        }
             


    }
}
