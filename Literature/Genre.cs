namespace Literature
{
    public abstract class Genre
    {
        public string Name { get; set; }

        protected Genre(string name)
        {
            Name = name;
        }

        public abstract string GetInfo();

        public override string ToString()
        {
            return Name;
        }
    }
}