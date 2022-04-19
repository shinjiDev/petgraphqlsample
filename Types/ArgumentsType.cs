using HotChocolate.Types;
using System.Reflection.Metadata.Ecma335;

namespace HotChocolate.Validation.Types
{
    public class ArgumentsType
        : ObjectType
    {
        public ArgumentsType()
        {
        }

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Arguments");

            // multipleReqs(x: Int!, y: Int!): Int!
            descriptor.Field("multipleReqs")
                .Argument("x", t => t.Type<NonNullType<IntType>>())
                .Argument("y", t => t.Type<NonNullType<IntType>>())
                .Type<NonNullType<IntType>>()
                .Resolve(() => 10);

            descriptor.Field("multipleOpts")
                .Argument("opt1", t => t.Type<IntType>())
                .Argument("opt2", t => t.Type<IntType>())
                .Type<NonNullType<IntType>>()
                .Resolve(() => 11);

            descriptor.Field("multipleOptsAndReqs")
                .Argument("req1", t => t.Type<NonNullType<IntType>>())
                .Argument("req2", t => t.Type<NonNullType<IntType>>())
                .Argument("opt1", t => t.Type<IntType>())
                .Argument("opt2", t => t.Type<IntType>())
                .Type<NonNullType<IntType>>()
                .Resolve(() => 12);

            //  booleanArgField(booleanArg: Boolean) : Boolean
            descriptor.Field("booleanArgField")
                .Argument("booleanArg", t => t.Type<BooleanType>())
                .Type<BooleanType>()
                .Resolve((ctx) => ctx.ArgumentValue<bool>("booleanArg"));

            // floatArgField(floatArg: Float): Float
            descriptor.Field("floatArgField")
                .Argument("floatArg", t => t.Type<FloatType>())
                .Type<FloatType>()
                .Resolve((ctx) => ctx.ArgumentValue<float>("floatArg"));

            // nonNullFloatArgField(floatArg: Float): Float
            descriptor.Field("nonNullFloatArgField")
                .Argument("floatArg", t => t.Type<NonNullType<FloatType>>())
                .Type<FloatType>()
                .Resolve((ctx) => ctx.ArgumentValue<float>("floatArg"));

            // intArgField(intArg: Int): Int!
            descriptor.Field("intArgField")
                .Argument("intArg", t => t.Type<IntType>())
                .Type<NonNullType<IntType>>()
                .Resolve((ctx) => ctx.ArgumentValue<int>("intArg"));

            // nonNullIntArgField(intArg: Int!): Int!
            descriptor.Field("nonNullIntArgField")
                .Argument("intArg", t => t.Type<NonNullType<IntType>>())
                .Type<NonNullType<IntType>>()
                .Resolve((ctx) => ctx.ArgumentValue<int>("intArg"));

            // nonNullBooleanArgField(nonNullBooleanArg: Boolean!): Boolean!
            descriptor.Field("nonNullBooleanArgField")
                .Argument("nonNullBooleanArg",
                    t => t.Type<NonNullType<BooleanType>>())
                .Type<NonNullType<BooleanType>>()
                .Resolve((ctx) => ctx.ArgumentValue<bool>("nonNullBooleanArg"));

            // booleanListArgField(booleanListArg: [Boolean]!) : [Boolean]
            descriptor.Field("booleanListArgField")
                .Argument("booleanListArg",
                    t => t.Type<NonNullType<ListType<BooleanType>>>())
                .Type<ListType<BooleanType>>()
                .Resolve((ctx) => ctx.ArgumentValue<List<bool>>("booleanListArg"));

            // nonNullBooleanListArgField(booleanListArg: [Boolean!]!) : [Boolean]
            descriptor.Field("nonNullBooleanListArgField")
                .Argument("booleanListArg",
                    t => t.Type<NonNullType<ListType<NonNullType<BooleanType>>>>())
                .Type<ListType<BooleanType>>()
                .Resolve((ctx) => ctx.ArgumentValue<List<bool>>("booleanListArg"));

            // optionalNonNullBooleanArgField(optionalBooleanArg: Boolean! = false) : Boolean!
            descriptor.Field("optionalNonNullBooleanArgField")
                .Argument("optionalBooleanArg",
                    t => t.Type<NonNullType<BooleanType>>().DefaultValue(false))
                .Argument("y", t => t.Type<NonNullType<IntType>>())
                .Type<NonNullType<BooleanType>>()
                .Resolve((ctx) => ctx.ArgumentValue<bool>("optionalBooleanArg"));

            // optionalNonNullBooleanArgField2(optionalBooleanArg: Boolean = true) : Boolean!
            descriptor.Field("optionalNonNullBooleanArgField2")
                .Argument("optionalBooleanArg",
                    t => t.Type<BooleanType>().DefaultValue(true))
                .Type<BooleanType>()
                .Resolve((ctx) => ctx.ArgumentValue<bool>("optionalBooleanArg"));

            // booleanListArgField(booleanListArg: [Boolean]!) : [Boolean]
            descriptor.Field("nonNullBooleanListField")
                .Argument("nonNullBooleanListArg",
                    t => t.Type<NonNullType<ListType<BooleanType>>>())
                .Type<ListType<BooleanType>>()
                .Resolve((ctx) => ctx.ArgumentValue<List<bool>>("nonNullBooleanListArg"));

            // intArgField(intArg: ID): ID!
            descriptor.Field("idArgField")
                .Argument("idArg", t => t.Type<IdType>())
                .Type<NonNullType<IdType>>()
                .Resolve((ctx) => ctx.ArgumentValue<object>("idArg"));

            descriptor.Field("nonNullIdArgField")
                .Argument("idArg", t => t.Type<NonNullType<IdType>>())
                .Type<NonNullType<IdType>>()
                .Resolve((ctx) => ctx.ArgumentValue<object>("idArg"));

            // stringArgField(intArg: String): String!
            descriptor.Field("stringArgField")
                .Argument("stringArg", t => t.Type<StringType>())
                .Type<NonNullType<StringType>>()
                .Resolve((ctx) => ctx.ArgumentValue<string>("stringArg"));

            descriptor.Field("nonNullStringArgField")
                .Argument("stringArg", t => t.Type<NonNullType<StringType>>())
                .Type<NonNullType<StringType>>()
                .Resolve((ctx) => ctx.ArgumentValue<string>("stringArg"));

            descriptor.Field("stringListArgField")
                .Argument("stringListArg",
                    t => t.Type<ListType<StringType>>())
                .Type<ListType<StringType>>()
                .Resolve((ctx) => ctx.ArgumentValue<List<string>>("stringListArg"));

            // enumArgField(intArg: DogCommand): String!
            descriptor.Field("enumArgField")
                .Argument("enumArg", t => t.Type<EnumType<DogCommand>>())
                .Type<NonNullType<StringType>>()
                .Resolve((ctx) => ctx.ArgumentValue<string>("enumArg"));

            // "nonNullenumArgField(intArg: DogCommand!): String!
            descriptor.Field("nonNullEnumArgField")
                .Argument("enumArg", t => t.Type<NonNullType<EnumType<DogCommand>>>())
                .Type<NonNullType<StringType>>()
                .Resolve((ctx) => ctx.ArgumentValue<string>("enumArg"));

            descriptor.Field("complexArgField")
                .Argument("complexArg", t => t.Type<Complex3InputType>())
                .Type<NonNullType<StringType>>()
                .Argument("complexArg1", t => t.Type<Complex3InputType>())
                .Type<NonNullType<StringType>>()
                .Argument("complexArg2", t => t.Type<Complex3InputType>())
                .Type<NonNullType<StringType>>()
                .Resolve(() => "test");

            descriptor.Field("nonNullFieldWithDefault")
                .Argument("opt1", t => t.Type<NonNullType<IntType>>().DefaultValue(0))
                .Type<NonNullType<IntType>>()
                .Resolve(() => "test");

            descriptor.Field("nonNullFieldWithDefault")
                .Argument("nonNullIntArg", t => t.Type<NonNullType<IntType>>().DefaultValue(0))
                .Type<NonNullType<StringType>>()
                .Resolve(() => "test");

            descriptor.Field("nonNullField")
                .Argument("nonNullIntArg", t => t.Type<NonNullType<IntType>>())
                .Type<NonNullType<StringType>>()
                .Resolve((ctx) => ctx.ArgumentValue<string>("nonNullIntArg"));

            descriptor.Field("stringListNonNullArgField")
                .Argument(
                    "stringListNonNullArg",
                    t => t.Type<NonNullType<ListType<StringType>>>())
                .Type<NonNullType<StringType>>()
                .Resolve(() => "test");
        }
    }
}
