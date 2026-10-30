namespace Literature
{
    public class FictionGenre : Genre
    {
        public FictionGenre(string name) : base(name)
        {
        }

        public override string GetInfo()
        {
            return $"Художественная литература: {Name}";
        }
    }
}