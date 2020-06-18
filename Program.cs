using Colorful;
using Figgle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Console = Colorful.Console;

namespace assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            bool to_continue = true;

            
            Figlet figlet = new Figlet();


            while (to_continue)
            {
                Console.WriteWithGradient(FiggleFonts.Big.Render("Menu"), Color.HotPink, ColorTranslator.FromHtml("#ff6969"), 3);

                
                Console.WriteWithGradient("(1) Pay\n", Color.HotPink, ColorTranslator.FromHtml("#ff6969"), 3);
                Console.WriteWithGradient("(2) Months\n", Color.HotPink, ColorTranslator.FromHtml("#ff6969"), 3);
                Console.WriteWithGradient("(3) Exam\n", Color.HotPink, ColorTranslator.FromHtml("#ff6969"), 3);
                Console.WriteWithGradient("(4) Exit\n\n", Color.HotPink, ColorTranslator.FromHtml("#ff6969"), 3);

                //Colorful.Console.ReplaceAllColorsWithDefaults();
                //Console.ReplaceAllColorsWithDefaults();
                Console.WriteFormatted("Please choose an option: ", Color.White);

                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteWithGradient(FiggleFonts.Big.Render("Pay Calculation"), Color.HotPink, ColorTranslator.FromHtml("#ff6969"), 3);
                        bool hw_running = true;
                        int time_worked = 0;
                        while (hw_running == true){
                            Console.WriteFormatted("Please enter the number of hours worked. Valid input is between 0 and 60: ", Color.White);
                            string read_line = Console.ReadLine();
                            bool success = Int32.TryParse(read_line, out time_worked);
                            if (success != true)
                            {
                                Console.Clear();
                                Console.WriteFormatted(String.Format("'{0}' is not a valid number.\n", read_line), Color.Red);
                            }
                            else { hw_running = false; }

                        }
                        

                        decimal pay_amount = pay_calc(time_worked);
                        Console.WriteLine(pay_amount.ToString("C2"));
                        
                        break;

                    case "2":
                        int chosen_month_int = get_months();
                        int length_of_month = months(chosen_month_int);
                        Console.WriteLineFormatted("The length of the month selected is " + length_of_month.ToString(), Color.White);
                        break;

                    case "3":
                        exam();
                        break;

                    case "4":
                        to_continue = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
                //Console.Clear();
            }

        }

        // 
        // $27/hour
        // tax rate 20% after 5 hours
        // 35% after 45 hours
        // no more than 60h worked
        //
        static decimal pay_calc(decimal hours_worked)
        {
            Console.Clear();
            decimal forty_five = 45;
            decimal five = 5;



            if (hours_worked > 60)
            {
                Console.WriteLine("Unable to pay more than 60h.");
                return (0);
            }

            else if (hours_worked < 0)
            {
                Console.WriteLine("Please enter a positive number.");
                return (0);
            }

            else if(hours_worked > 45)
            {
                decimal val = (tax_calc((hours_worked - 45), 35, 27));
                return (val + pay_calc(forty_five));
            }

            else if (hours_worked > 5)
            {
                decimal val = (tax_calc((hours_worked - 5), 20, 27));
                return (val + pay_calc(five));
            }

            else if (hours_worked <= 5)
            {
                return (tax_calc(hours_worked, 0, 27));

            }

            else
            {
                Console.WriteLine("Some undefined error");
                return 0;
            }


        }

        // 
        // returns the amount earned with tax deducted
        // 

        static decimal tax_calc(decimal hours, decimal percentage_tax_rate, decimal pay_rate)
        {
            return (hours*pay_rate - (hours * pay_rate * (percentage_tax_rate / 100)));
        }

        static int get_months()
        {
            Console.Clear();

            string[] months_array = { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Colorful.Console.ReplaceAllColorsWithDefaults();

            Console.WriteWithGradient(FiggleFonts.Big.Render("Months"), Color.HotPink, ColorTranslator.FromHtml("#ff6969"), 3);

            for (int i = 0; i < months_array.Length; i++)
            {
                Console.WriteFormatted(String.Format("{0} {1}\n", i + 1, months_array[i]), Color.White);
            }

            bool running = true;
            int test = 0;
            while (running == true)
            {
                
                Console.WriteFormatted(("Month would you like to find the length of: "), Color.White);
                string in_put = Console.ReadLine();

                bool can_convert = int.TryParse(in_put, out test);
                //Console.WriteLine(test);
                if ((can_convert == true) & (test < months_array.Length+1) & (test > 0))
                {
                    running = false;
                }
                
                else {
                    Console.Clear();
                    Console.WriteFormatted((in_put + " " + "is not a valid selection\nPlease try again\n"), Color.Red); }
            }

            //Console.WriteFormatted(test.ToString(), Color.White);



            return test;
        }

        static int months(int month_type)
        {
            string[] months_array = { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int[] months_length = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };



            if (month_type == 2)
            {
                int year = 0;
                while (year < 1)
                {
                    Console.WriteFormatted("Year: ", Color.White);
                    string year_input = Console.ReadLine();

                    bool can_convert = int.TryParse(year_input, out year);
                    if (year < 1)
                    {
                        Console.WriteFormatted(String.Format("{0} is not a valid year\nPlease try again\n", year_input), Color.Red);
                    }

                }

                if (((year % 4) == 0) & ((year % 100) != 0) || ((year % 400) == 0))
                {
                    Console.Clear();
                    Console.WriteFormatted(String.Format("{0} is a leap year\n", year), Color.White);

                    return (29);
                }
                else
                {
                    Console.Clear();
                    Console.WriteFormatted(String.Format("{0} is not a leap year\n", year), Color.White);
                    return (28);
                }

            }

            else
            {
                Console.Clear();
                return (months_length[month_type - 1]);
            }

        }

        static void exam()
        {

            Console.Clear();

            Console.ReplaceAllColorsWithDefaults();
            Console.WriteWithGradient(FiggleFonts.Big.Render("Exam"), Color.HotPink, ColorTranslator.FromHtml("#ff6969"), 3);

            string marks_file = "marks.txt";

            if (File.Exists(marks_file))
            {
                //
                // reads file "marks_file" into a list where every line is a element
                //
                string[] lines = System.IO.File.ReadAllLines(marks_file);

                //
                // creates list names that contains the objects students which have
                // name and grade
                //

                List<Student> names = new List<Student>();


                foreach (string line in lines)
                {
                    //
                    // splits every line into "name" and "grade"
                    //

                    var words = line.Split(' ');
                    names.Add(new Student(words[1], Int16.Parse(words[0]), ""));

                }
                //
                // sorts the students by their grade
                //
                var result1 = names.OrderByDescending(a => a.Score).Reverse();
                if (File.Exists(marks_file)) { File.Delete("distinctionList.txt"); }
                foreach (Student stu in result1)
                {
                    
                    if ((stu.Score > 100) | (stu.Score < 0)) { stu.Grade = "Error"; }
                    else if (stu.Score > 85) { stu.Grade = "Distinction"; }
                    else if (stu.Score >= 75) { stu.Grade = "Credit"; }
                    else if (stu.Score > 50) { stu.Grade = "Pass"; }
                    else { stu.Grade = "Fail"; }

                    
                    string to_file = (stu.Grade + " " + stu.Score + "% " + stu.Name + "\n");
                    Console.WriteFormatted(to_file, Color.White);
                    if (stu.Grade == "Distinction")
                    {
                        File.AppendAllText("distinctionList.txt", to_file);
                    }
                    
                }
                //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

            }
            else {Console.WriteFormatted("File 'marks.txt' does not exist\nPlease re-run the program once this file exists\n", Color.Red); }

        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string Grade { get; set; }

        public Student(string name, int score, string grade)
        {
            Name = name;
            Score = score;
            Grade = grade;
        }
    }
}
