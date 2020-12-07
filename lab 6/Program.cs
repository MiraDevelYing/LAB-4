//Для роботи з кутами у форматі: градуси, хвилини, секундистворити структуру та функції, що дозволяють: 
//a)вводити значення кута з клавіатури (файлу);
//b)виводити значення кута на екран (файл); 
//c)знаходити суму / різницю між двома кутами;
//d)множення кута на дійсне число; 
//e)переведення кута у радіани  та  навпаки. Створити    приклад  для  демонстрації  усіх  функціональних можливостей.
using System; 
using System.Text; 
using System.Linq; 
using System.IO;
 
namespace Task_4
{
    class Dates
    {
        private DateTime date;
        /*оголошення властивості з іменем Date*/
        public DateTime Date
        {
            get /*аксесор що використовується для читання значення з внут. поля класу*/
            {
                return date;
            }
            private set /*аксесор що використовується для запису  значення з внут. поля класу*/
            {
                date = value;
            }
        }
        public Dates(int y, int m, int d) /*конструктор здійснює ініціалізацію об'єкту класу при його створенні, має таке саме ім'я як і клас*/
        {   /*динамічне виділення пам'яті для об'яктів чи інших видів даних реалізується з допомогою оператора new*/
            int[] m30 = new int[] { 4, 6, 9, 11 };
            int[] m31 = new int[] { 1, 3, 5, 6, 7, 8, 10, 12 };
            if (!((1 > d || /*логічне або*/ d > 30 || !m30.Contains(m)) && /*логічне і*/
                (1 > d || d > 31 || !m31.Contains(m)) &&
                (1 > d || d > 29 || m != 2 || y % 4 != 0 || y % 100 != 0 || y % 400 != 0) &&
                (1 > d || d > 28 || m != 2 || y % 4 == 0 || y % 100 == 0 || y % 400 == 0)))
            {
                Date = new DateTime(y, m, d);
            }
            else
            {
                Console.WriteLine("Невірна дата");
                Variable.key = false;
            }
        }
        public string SubtractDates(DateTime value1, DateTime value2)/*Этот метод используется для вычитания указанного времени или продолжительности из этого экземпляра*/
        {
            int[] res = DateDifference(value1.Subtract(value2).TotalDays); /*использоваться для нахождения разницы между датой и временем между двумя экземплярами метода DateTime.*/
            return $"{res[0]} year {res[1]} month {res[2]} day";
        }
        private int[] DateDifference(double days)
        {
            double r = (int)days;
            int year = (int)((days - 30.417) / 365);
            r -= year * 365;
            int month = (int)(r / 30.417);
            r -= month * 30.417;
            int day = (int)(r + 1);
            return new int[] { year, month, day };
        }
        public double ToDays(DateTime dateValue)/* конвертація дати в дні*/
        {
            return dateValue.Day + (30.417 * dateValue.Month) + (365 * dateValue.Year);
        }
        public string ToDate(double days)/*конвертація назад у дату*/
        {
            int[] res = DateDifference(days);
            return new DateTime(res[0], res[1], res[2]).ToShortDateString();
        }
    }
    public static class Variable
    {
        public static bool key = true;
    }
    class Program
    {
        private static int[] DateTransformation(string text)
        {
            int[] res = new int[3];
            string[] textSplit = text.Split("/");
            for (int i = 0; i < textSplit.Length; i++)
            {
                try
                {
                    res[i] = Convert.ToInt32(textSplit[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не можна прочитати файл: {ex.Message}");
                    System.Diagnostics.Process.GetCurrentProcess().Kill();/* приложение убивается и нормально запускается по новой */
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;/*Возвращает или задает кодировку, которую консоль использует для записи вывода.*/
            Console.InputEncoding = Encoding.UTF8;/*Получает или задает кодировку, которую консоль использует для чтения ввода.*/

            Console.WriteLine("Оберіть тип введеня:\n1. З файлу \n2. З  консолі");


            int c;
            while (true)
            {
                try
                {
                    Console.Write("Ваша відповідь: ");
                    c = Convert.ToInt32(Console.ReadLine());
                    if (c == 1 || c == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Оберіть один із двох варіантів!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            switch (c)/*оператор вибору switch */
            {
                case 1:
                    {
                        Console.WriteLine("Ви обрали з файлу");
                        string pathDates = @"D:\second course\oop\lab_4.2\lab_4.txt";
                        if (!File.Exists(pathDates))
                        {
                            Console.WriteLine($"Файл {Path.GetFileName(pathDates)} не існує");
                            return;
                        }
                        else
                        {
                            if (new FileInfo(pathDates).Length == 0)
                            {
                                Console.WriteLine($"Файл {Path.GetFileName(pathDates)} пустий");
                                return;
                            }
                        }

                        using StreamReader sr = new StreamReader(pathDates);
                        int[] a3 = DateTransformation(sr.ReadLine());
                        int[] a4 = DateTransformation(sr.ReadLine());
                        Dates dateClass3 = new Dates(a3[0], a3[1], a3[2]);
                        Dates dateClass4 = new Dates(a4[0], a4[1], a4[2]);

                        if (!Variable.key)
                        {
                            return;
                        }

                        DateTime getDate3 = dateClass3.Date;
                        DateTime getDate4 = dateClass4.Date;

                        double getDateToDays3 = dateClass3.ToDays(getDate3);
                        double getDateToDays4 = dateClass4.ToDays(getDate4);

                        Console.WriteLine($"Перша дата: {getDate3.ToShortDateString()}");
                        Console.WriteLine($"Друга дата: {getDate4.ToShortDateString()}");

                        Console.WriteLine($"Різниця двох дат: {dateClass3.SubtractDates(getDate3, getDate4)}");
                        Console.WriteLine($"Сума двох дат: {getDateToDays3 + getDateToDays4:f0} днів");
                        Console.WriteLine($"Конвертація першої дати в дні: {getDateToDays3:f0}");
                        Console.WriteLine($"Конвертація назад в дату: {dateClass3.ToDate(getDateToDays3)}");
                        Console.WriteLine($"Конвертація другої дати в дні: {getDateToDays4:f0}");
                        Console.WriteLine($"Конвертація назад в дату: {dateClass4.ToDate(getDateToDays4)}");
                    }
                    break;
                case 2:

                    Console.WriteLine("Ви обрали з консолі");
                    Console.Write("Введіть першу дату у форматі yyyy/MM/dd: ");
                    int[] a1 = DateTransformation(Console.ReadLine());
                    Console.Write("Введіть другу дату у форматі yyyy/MM/dd: ");
                    int[] as2 = DateTransformation(Console.ReadLine());

                    /*вызов конструкторов*/
                    Dates dateClass1 = new Dates(a1[0], a1[1], a1[2]);
                    Dates dateClass2 = new Dates(as2[0], as2[1], as2[2]);

                    if (!Variable.key)
                    {
                        return;
                    }

                    DateTime getDate1 = dateClass1.Date;
                    DateTime getDate2 = dateClass2.Date;

                    double getDateToDays1 = dateClass1.ToDays(getDate1);
                    double getDateToDays2 = dateClass2.ToDays(getDate2);

                    Console.WriteLine($"Перша дата: {getDate1.ToShortDateString()}");
                    Console.WriteLine($"Друга дата: {getDate2.ToShortDateString()}");

                    Console.WriteLine($"Різниця двох дат: {dateClass1.SubtractDates(getDate1, getDate2)}");
                    Console.WriteLine($"Сума двох дат: {getDateToDays1 + getDateToDays2:f0} днів");
                    Console.WriteLine($"Конвертація першої дати в дні: {getDateToDays1:f0}");
                    Console.WriteLine($"Конвертація назад в дату: {dateClass1.ToDate(getDateToDays1)}");
                    Console.WriteLine($"Конвертація другої дати в дні: {getDateToDays2:f0}");
                    Console.WriteLine($"Конвертація назад в дату: {dateClass2.ToDate(getDateToDays2)}");

                    break;
                default:
                    break;
            }
        }
    }
}
