using Lesson01.Utils;
using System;
using System.ComponentModel;

namespace Lesson01.Models
{
    public class Person
    {
        static int id = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime? BirthOfDate { get; set; }

        public Person()
        {
            this.Id = ++id;
        }

        public Person(string name,string surName)
            :this()
        {
            this.Name = name;
            this.SurName = surName;
        }

        public Person(string name, string surName,DateTime birthOfDate)
            :this(name,surName)
        {
            BirthOfDate = birthOfDate;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {SurName}, DateOfBirth: {BirthOfDate.DateToText()}" ; 
        }
    }
}