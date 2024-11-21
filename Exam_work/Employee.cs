namespace Exam_work;

public class Employee
{
    public Employee() { }

    public Employee(string name, string firstName, string lastName, string department, string post, string office)
    {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Department = department;
        Post = post;
        Office = office;
    }

    public string Name {  get; set; }
    public string FirstName { get; set; }   
    public string LastName { get; set; }
    public string Department { get; set; }
    public string Post {  get; set; }
    public string Office { get; set; }
}
