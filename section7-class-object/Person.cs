// namespace ConsoleApp1    // これを記述するとProgram.csと別の名前空間になるため、Program.csで using を記述する必要がある。
public class Person
{
    public string name = "初期値太郎";
    public int age = 0;

    public void ShowAgeAndName()
    {
        Console.WriteLine($"名前:{name} 年齢:{age}");
    }
    public void SetAgeAndName(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}