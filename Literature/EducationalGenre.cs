namespace Literature
{
    public class EducationalGenre : Genre
    {
        // используем конструктор Genre
        public EducationalGenre(string name) : base(name)
        {
        }

        public override string GetInfo()
        {
            return $"Учебная литература: {Name}";
        }
    }
}