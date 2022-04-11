using HotChocolate.Execution.Configuration;

namespace DemoChoco
{
    public static class ValidationUtils
    {
        public static IRequestExecutorBuilder AddDirectiveType(
            this IRequestExecutorBuilder builder,
            string name,
            DirectiveLocation location) =>
            AddDirectiveType(builder, name, location, x => x);

        public static IRequestExecutorBuilder AddDirectiveType(
            this IRequestExecutorBuilder builder,
            string name,
            DirectiveLocation location,
            Func<IDirectiveTypeDescriptor, IDirectiveTypeDescriptor> configure) =>
            builder.AddDirectiveType(new DirectiveType(x =>
                configure(x.Name(name).Location(location))));
    }
}
