namespace Literature
{
    public class Author
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }

        public Author(int id, string name, int birthYear)
        {
            Id = id;
            Name = name;
            BirthYear = birthYear;
        }

        public override string ToString()
        {
            return $"{Name} ({BirthYear})";
        }
    }
}