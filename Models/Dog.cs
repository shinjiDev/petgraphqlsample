namespace HotChocolate.Validation
{
    public class Dog
        : IPet
    {
        public string Name { get; set; }

        public string? Nickname { get; set; }

        public int? BarkVolume { get; set; }
        
        public bool Barks { get; set; }

        public Human? Owner { get; set; }

        public bool DoesKnowCommand(DogCommand dogCommand)
        {
            return true;
        }

        public bool IsHouseTrained(bool? atOtherHomes)
        {
            return true;
        }
    }
}
