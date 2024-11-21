namespace Exam_work;

public class Department
{
    public Department() {}

    public Department(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public override string ToString()
    {
        return Name;
    }
}
