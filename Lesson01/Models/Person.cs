namespace Lesson01.Models
{
    public class Person
    {
        static int id = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public Person(string name,string surName)
        {
            this.Name = name;
            this.SurName = surName;
            this.Id = ++id;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {SurName}" ; 
        }
    }
}