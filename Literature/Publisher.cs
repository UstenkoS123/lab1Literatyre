namespace Literature
{
    public class Publisher
    {
        public string Name { get; set; }
        public string City { get; set; }

        public Publisher(string name, string city)
        {
            Name = name;
            City = city;
        }

        public override string ToString()
        {
            return $"{Name}, {City}";
        }
    }
}