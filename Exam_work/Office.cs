namespace Exam_work;

public class Office
{
    public Office() { }

    public string Name { get; set; }
    public string Department { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Department}";
    }
}
