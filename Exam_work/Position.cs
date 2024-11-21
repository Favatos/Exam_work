namespace Exam_work;

public class Position
{
    public Position(){}

    public Position(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }

    public string Name {  get; set; }
    public int Salary { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Salary}";
    }
}
