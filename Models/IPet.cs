using DemoChoco.Models;

namespace HotChocolate.Validation
{
    public interface IPet : IBeing
    {
        string Name { get; }
    }
}
