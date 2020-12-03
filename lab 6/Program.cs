//Для роботи з кутами у форматі: градуси, хвилини, секундистворити структуру та функції, що дозволяють: 
//a)вводити значення кута з клавіатури (файлу);
//b)виводити значення кута на екран (файл); 
//c)знаходити суму / різницю між двома кутами;
//d)множення кута на дійсне число; 
//e)переведення кута у радіани  та  навпаки. Створити    приклад  для  демонстрації  усіх  функціональних можливостей.
using System;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace lab4
{
    class Angle

    {
        private double[] num1;
        private double[] num2;
        public double result;
        public double result2;
        public double[] Num1
        {
            get
            {
                return num1;
            }
            private set
            {
                num1 = value;
            }
        }
        public double[] Num2
        {
            get
            {
                return num2;
            }
            private set
            {
                num2 = value;
            }
        }
        public Angle(double[] b)
        {
            num1 = new double[] { 125 };
            num2 = b;

        }
        public Angle(double[] a, double[] b)
        {
            num1 = a;
            num2 = b;
        }
        public static Angle Input()
        {
            while (true)
            {
                int sel;
                Console.WriteLine("Enter 1 to choose file variant\nEnter 2 to choose keyboard variant");
                while (true)
                {
                    try
                    {
                        Console.Write("You entered: ");
                        sel = Convert.ToInt32(Console.ReadLine());
                        if (sel == 1 || sel == 2)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("False variant");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unknown noun");
                    }
                }

                switch (sel)
                {
                    case 1:
                        {
                            Console.WriteLine("Entering out of file");
                            string path = @"C:\Users\giros\source\repos\lab4\angle.txt";
                            while (true)
                            {
                                if (!File.Exists(path))
                                {
                                    Console.WriteLine("No file in folder ");
                                    Console.ReadLine();
                                    continue;
                                }
                                else
                                {
                                    string Text = File.ReadAllText(path);
                                    if (Text == "")
                                    {
                                        Console.WriteLine($"File {Path.GetFileName(path)} is empty");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    try
                                    {
                                        string[] Textarr = Text.Split(" ");
                                        string a = Textarr[0];
                                        string b = Textarr[1];
                                        string[] A = a.Split(" ");
                                        double[] dA = Array.ConvertAll(A, double.Parse);
                                        string[] B = b.Split(" ");
                                        double[] dB = Array.ConvertAll(B, double.Parse);

                                        return new Angle(dA, dB);

                                    }

                                    catch (FormatException)
                                    {
                                        Console.WriteLine($"Unknown nouns in file");
                                    }

                                    break;
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Entering out of console");
                            string TextC = Console.ReadLine();
                            try
                            {
                                string[] TextCarr = TextC.Split(" ");
                                if (TextCarr.Length == 1)
                                {
                                    string b = TextCarr[0];
                                    string[] B = b.Split(" ");
                                    double[] dB = Array.ConvertAll(B, double.Parse);
                                    return new Angle(dB);
                                }
                                if (TextCarr.Length == 2)
                                {
                                    string a = TextCarr[0];
                                    string b = TextCarr[1];
                                    string[] A = a.Split(" ");
                                    double[] dA = Array.ConvertAll(A, double.Parse);
                                    string[] B = b.Split(" ");
                                    double[] dB = Array.ConvertAll(B, double.Parse);

                                    return new Angle(dA, dB);
                                }
                            }

                            catch (FormatException)
                            {
                                Console.WriteLine("Fornat exception");

                            }
                        }
                        break;
                }
            }
        }
        public void Output()
        {
            while (true)
            {
                int selection;
                Console.WriteLine("\nChoose type of outputing:\n1)In file\n2)In console");
                while (true)
                {
                    try
                    {
                        Console.Write("You entered: ");

                        selection = Convert.ToInt32(Console.ReadLine());
                        if (selection == 1 || selection == 2)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong variant");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unknown format");
                    }
                }

                switch (selection)
                {
                    case 1:
                        {
                            Console.WriteLine("Outputting in file");
                            Console.WriteLine(@"Path to file: C:\Users\giros\source\repos\lab4\Output.txt");
                            string PTF = @"C:\Users\giros\source\repos\lab4\Output.txt";

                            string Output = $"First angle: {num1[0]}\nSecond angle: {num2[0]}";
                            try
                            {
                                bool boolean = false;
                                using (StreamWriter sw = new StreamWriter(PTF, boolean, System.Text.Encoding.Unicode))
                                {
                                    sw.WriteLine(Output);
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Some troubles");
                            }

                        }
                        break;

                    case 2:
                        {
                            string Ouput = $"First angle: {num1[0]}\nSecond angle: {num2[0]}";
                            Console.WriteLine($"Your angles: {Ouput}");
                        }
                        break;

                }
                break;

            }
        }
        public void Arifm()
        {
            while (true)
            {
                int selection;
                Console.WriteLine("\nChoose what you want to get:\n1)Sum\n2)Difference");
                while (true)
                {
                    try
                    {
                        Console.Write("You entered: ");

                        selection = Convert.ToInt32(Console.ReadLine());
                        if (selection == 1 || selection == 2)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong variant");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unknown format");
                    }
                }
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("You will get result of summing");
                        double x = num1[0];
                        double y = num2[0];
                        result = 2 * (Math.Sin((x + y) / 2)) + (Math.Cos((x - y) / 2));
                        Console.WriteLine($"\nYour sum: {result}");

                        break;
                    case 2:
                        Console.WriteLine("You will get difference");
                        double x1 = num1[0];
                        double y2 = num2[0];

                        if (x1 > y2)
                        {
                            result = 2 * (Math.Sin((x1 - y2) / 2)) + (Math.Cos((x1 + y2) / 2));
                            Console.WriteLine($"\nYour difference: {result}");
                        }
                        else if (y2 > x1)
                        {
                            result = 2 * (Math.Sin((y2 - x1) / 2)) + (Math.Cos((y2 + x1) / 2));
                            Console.WriteLine($"\nYour difference: {result}");
                        }
                        break;



                }
                break;
            }
        }

        public void Multiply()
        {
            while (true)
            {
                int selection;
                Console.WriteLine($"\nChoose which angle you want to multiply:\n1){num1[0]}\n2){num2[0]}");
                while (true)
                {
                    try
                    {
                        Console.Write("You entered: ");

                        selection = Convert.ToInt32(Console.ReadLine());
                        if (selection == 1 || selection == 2)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong variant");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unknown format");
                    }
                }
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Enter your number:");
                        double noun = Convert.ToDouble(Console.ReadLine());
                        result2 = num1[0] * noun;
                        Console.WriteLine($"Your doubt: {result2}");
                        break;
                    case 2:
                        Console.WriteLine("Enter your number:");
                        double noun1 = Convert.ToDouble(Console.ReadLine());
                        result2 = num2[0] * noun1;
                        Console.WriteLine($"Your doubt: {result2}");
                        break;


                }
                break;
            }
        }
        public void Radian()
        {
            while (true)
            {
                int selection;
                Console.WriteLine($"\nChoose which angle you want to convert in Radian:\n1){num1[0]}\n2){num2[0]}");
                while (true)
                {
                    try
                    {
                        Console.Write("You entered: ");

                        selection = Convert.ToInt32(Console.ReadLine());
                        if (selection == 1 || selection == 2)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong variant");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unknown format");
                    }
                }
                switch (selection)
                {
                    case 1:

                        double radian = num1[0] * Math.PI / 180;
                        Console.WriteLine($"Your Radian:{radian}");
                        Console.WriteLine($"Your degrees:{num1[0]}");
                        break;

                    case 2:

                        double radian1 = num2[0] * Math.PI / 180;
                        Console.WriteLine($"Your Radian:{radian1}");
                        Console.WriteLine($"Your degrees:{num2[0]}");
                        break;
                }
                break;
            }
        }




        class Program
        {
            static void Main(string[] args)
            {
                Angle angle1 = Angle.Input();
                angle1.Output();
                angle1.Arifm();
                angle1.Multiply();
                angle1.Radian();
            }
        }
    }
}