namespace Literature
{
    public class Hall
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Hall(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Name} — {Description}";
        }
    }
}