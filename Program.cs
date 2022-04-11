using DemoChoco;
using HotChocolate.Validation;
using HotChocolate.Validation.Types;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    //.AddQueryType<Query>()
    .AddQueryType<QueryType>()
    .AddMutationType<MutationType>()
    .AddType<AlienType>()
    .AddType<CatOrDogType>()
    .AddType<CatType>()
    .AddType<DogOrHumanType>()
    .AddType<DogType>()
    .AddType<HumanOrAlienType>()
    .AddType<HumanType>()
    .AddType<PetType>()
    .AddType<BeingType>()
    .AddType<ArgumentsType>()
    .AddSubscriptionType<SubscriptionType>()
    .AddType<ComplexInputType>()
    .AddType<Complex2InputType>()
    .AddType<Complex3InputType>()
    .AddType<InvalidScalar>()
    .AddDirectiveType<ComplexDirective>()
    .AddDirectiveType(new CustomDirectiveType("directive"))
    .AddDirectiveType(new CustomDirectiveType("directive1"))
    .AddDirectiveType(new CustomDirectiveType("directive2"))
    .AddDirectiveType("onMutation", DirectiveLocation.Mutation)
    .AddDirectiveType("onQuery", DirectiveLocation.Query)
    .AddDirectiveType("onSubscription", DirectiveLocation.Subscription)
    .AddDirectiveType("onFragmentDefinition", DirectiveLocation.FragmentDefinition)
    .AddDirectiveType("onVariableDefinition", DirectiveLocation.VariableDefinition)
    .AddDirectiveType("directiveA",
        DirectiveLocation.Field |
        DirectiveLocation.FragmentDefinition)
    .AddDirectiveType("directiveB",
        DirectiveLocation.Field |
        DirectiveLocation.FragmentDefinition)
    .AddDirectiveType("directiveC",
        DirectiveLocation.Field |
        DirectiveLocation.FragmentDefinition)
    .AddDirectiveType("repeatable",
        DirectiveLocation.Field |
        DirectiveLocation.FragmentDefinition,
        x => x.Repeatable())
    .ModifyOptions(o =>
    {
        o.EnableOneOf = true;
        o.StrictValidation = false;
    });
var app = builder.Build();

app.MapGraphQL();

app.Run();
