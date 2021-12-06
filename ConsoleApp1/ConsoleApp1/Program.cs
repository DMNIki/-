// See https://aka.ms/new-console-template for more information
{
    byte meny = 0;
    int i;
    double s;
    while (meny != 7)
    {
        Console.WriteLine(" 1) Ввод информации о студентах");
        Console.WriteLine(" 2) Получить сведения о студенте по его фамилии");
        Console.WriteLine(" 3) Получить список студентов с минимальным средним баллом");
        Console.WriteLine(" 4) Получить количество студентов на указанном курсе");
        Console.WriteLine(" 5) Получить средний балл в указанной группе");
        Console.WriteLine(" 6) Вывод всей информации");
        Console.WriteLine(" 7) Выход");
        meny = Convert.ToByte(Console.ReadLine());
        switch (meny)
        {
            case 1:
                Vvod();
                break;
            case 2:
                Family();
                break;
            case 3:
                MinStata();
                break;
            case 4:
                i = StudentsInCourse();
                Console.WriteLine(" Учащихся на указанном курсе: " + i);
                break;
            case 5:
                s = StataGroup();
                Console.WriteLine(" Средний балл в указанной группе: " + s);
                break;
            case 6:
                Vivod();
                break;
            case 7:
                break;
            default:
                Console.Write(" Такого пункта в меню нет. ");
                break;
        }
    }
    Console.ReadKey();
}
static void Vvod()
{
    FileStream FileMe = new FileStream("C:\\Users\\User\\Desktop\\txt.txt", FileMode.Append);
    StreamWriter writer = new StreamWriter(FileMe);
    students m;
    int exit = 0;
    while (exit != 2)
    {
        Console.Write(" Укажите фамилию: ");
        m.Family = Console.ReadLine();
        Console.Write(" Укажите имя: ");
        m.Name = Console.ReadLine();
        Console.Write(" Укажите отчество: ");
        m.MiddleName = Console.ReadLine();
        Console.Write(" Укажите группу: ");
        m.Group = Console.ReadLine();
        Console.Write(" Укажите средний балл: ");
        m.Stata = Console.ReadLine();
        Console.Write(" Укажите курс: ");
        m.Course = Console.ReadLine();
        String stroka = m.Family + " " + m.Name + " " + m.MiddleName + " " + m.Group + " " + m.Stata + " " + m.Course;
        writer.WriteLine(stroka);
        Console.WriteLine(" 1) Продолжить ввод.");
        Console.WriteLine(" 2) Выход.");
        exit = Convert.ToInt32(Console.ReadLine());
    }
    writer.Close();
}
static void Family()
{
    FileStream FileMe = new FileStream("C:\\Users\\User\\Desktop\\txt.txt", FileMode.Open);
    StreamReader reader = new StreamReader(FileMe);
    string family = null;
    string k = null;
    Console.WriteLine(" Введите фамилию студента: ");
    family = Console.ReadLine();
    while (!reader.EndOfStream)
    {
        k = reader.ReadLine();
        int simvol = k.IndexOf(family);
        if (simvol >= 0)
        {
            string[] words = k.Split(new char[] { ' ' });
            if (words[0] == family)
                Console.WriteLine(k);

        }
    }
    reader.Close();
}
static void MinStata()
{
    FileStream FileMe = new FileStream("C:\\Users\\User\\Desktop\\txt.txt", FileMode.Open);
    StreamReader reader = new StreamReader(FileMe);
    string k = null;
    double min = 6;
    int i = 0;
    double[] znak = new double[100];
    while (!reader.EndOfStream)
    {
        k = reader.ReadLine();
        string[] words = k.Split(new char[] { ' ' });
        znak[i] = Convert.ToInt32(words[4]);
        if (znak[i] < min)
            min = znak[i];
    }
    reader.Close();

    FileStream FileMeTwo = new FileStream("C:\\Users\\User\\Desktop\\txt.txt", FileMode.Open);
    StreamReader readerTwo = new StreamReader(FileMeTwo);
    while (!readerTwo.EndOfStream)
    {
        k = readerTwo.ReadLine();
        string[] words = k.Split(new char[] { ' ' });
        string minStr = Convert.ToString(min);

        int simvol = words[4].IndexOf(minStr);
        if (simvol >= 0)
            Console.WriteLine(k);
    }
    readerTwo.Close();
}
static void Vivod()
{
    FileStream FileMe = new FileStream("C:\\Users\\User\\Desktop\\txt.txt", FileMode.Open);
    StreamReader reader = new StreamReader(FileMe);
    Console.WriteLine(reader.ReadToEnd());
    reader.Close();

}
static int StudentsInCourse()
{
    FileStream FileMe = new FileStream("C:\\Users\\User\\Desktop\\txt.txt", FileMode.Open);
    StreamReader reader = new StreamReader(FileMe);
    string Course = null;
    string k = null;
    Console.WriteLine(" Введите курс(цифрой с ебучей единицы до пяти): ");
    Course = Console.ReadLine();
    int i = 0;
    while (!reader.EndOfStream)
    {
        k = reader.ReadLine();
        int simvol = k.IndexOf(Course);
        if (simvol >= 0)
        {
            string[] words = k.Split(new char[] { ' ' });
            if (words[5] == Course)
                i++;

        }
    }
    reader.Close();
    return i;
}
static double StataGroup()
{
    FileStream FileMe = new FileStream("C:\\Users\\User\\Desktop\\txt.txt", FileMode.Open);
    StreamReader reader = new StreamReader(FileMe);
    string Group, k;
    Console.WriteLine(" Введите название группы: ");
    Group = Console.ReadLine();
    double s = 0, i = 0, p;
    while (!reader.EndOfStream)
    {
        k = reader.ReadLine();
        int simvol = k.IndexOf(Group);

        if (simvol >= 0)
        {
            string[] words = k.Split(new char[] { ' ' });
            p = Convert.ToDouble(words[4]);
            s = s + p;
            i++;
        }

    }
    s = s / i;
    return s;
}

