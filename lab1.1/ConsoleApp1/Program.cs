class Program
{
    static void Main(string[] args)
    {
        int age = 25;
        Console.Write("введите имя: ");
        string name = Console.ReadLine();
        GreetUser(name, age);
    }

    private static void GreetUser(string name, int age)
    {
        Console.WriteLine($"Привет, я {name}! Сегодня {DateTime.Now:dd.MM.yyyy}");
        Console.WriteLine($"Мне {age} лет");
    }
}