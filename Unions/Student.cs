using System;
using System.Collections.Generic;
using System.Text;

namespace Unions;

public class Student : IComparable<Student>
{
    public Student(int id, string name, Gender gender)
    {
        Id = id;
        Name = name;
        Gender = gender;
    }

    public int Id { get; private set; }

    public string Name { get; private set; }

    public Gender Gender { get; private set; }

    public int CompareTo(Student other)
    {
        return Id.CompareTo(other.Id);
    }
}