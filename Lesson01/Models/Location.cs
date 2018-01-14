namespace Lesson01.Models
{
    //[ModelBinder(typeof(LocationModelBinder))]
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Location() {
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }

        static public Location Create(int x, int y, int z)
        {
            return new Location { X = x, Y = y, Z = z };
        }
    }
}