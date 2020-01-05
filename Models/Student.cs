namespace StudentApi.Models
{
  public class Student
  {
    public int Id { get; set; }
    public string FullName { get; set; }
    public double? GPA { get; set; }
    public bool IsJoyful { get; set; } = true;
  }
}