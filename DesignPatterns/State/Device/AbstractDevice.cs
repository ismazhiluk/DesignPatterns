namespace State.Device
{
    public abstract class AbstractDevice
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public Document[] Documents => new[]
        {
            new Document {Id = 11, Name = $"Первый документ на {Name.ReplaceLast("е")}", AmountOfPages = 1},
            new Document {Id = 12, Name = $"Второй документ на {Name.ReplaceLast("е")}", AmountOfPages = 2}
        };
    }
}
