using System;

namespace assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            bool to_continue = true;

            string menu_text_ascii = @"  __  __                  
 |  \/  |                 
 | \  / | ___ _ __  _   _ 
 | |\/| |/ _ \ '_ \| | | |
 | |  | |  __/ | | | |_| |
 |_|  |_|\___|_| |_|\__,_| 
                                     ";

            

            while (to_continue)
            {
                Console.WriteLine(menu_text_ascii);
                Console.WriteLine("(1) Pay");
                Console.WriteLine("(2) Months");
                Console.WriteLine("(3) Exam");

                Console.WriteLine("Exit");

                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        decimal time_worked = decimal.Parse(Console.ReadLine());
                        decimal pay_amount = Pay_calc(time_worked);
                        Console.WriteLine(pay_amount.ToString("C2"));

                        break;

                    case "2":
                        int chosen_month_int = get_months();
                        Months(chosen_month_int);
                        break;

                    case "3":
                        //statement 
                        break;

                    default:
                        to_continue = false;
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
        static decimal Pay_calc(decimal hours_worked)
        {
            Console.Clear();
            decimal forty_five = 45;
            decimal five = 5;

            if (hours_worked >= 60)
            {
                Console.WriteLine("Unable to pay more than 60h");
                return (0);
            }

            else if(hours_worked > 45)
            {
                decimal val = (tax_calc((hours_worked - 45), 35, 27));
                return (val + Pay_calc(forty_five));
            }

            else if (hours_worked > 5)
            {
                decimal val = (tax_calc((hours_worked - 5), 20, 27));
                return (val + Pay_calc(five));
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


        static int Months(int Month_type)
        {
            string[] months_array = { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int[] months_length = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            Console.WriteLine(string.Join(",", months_length));

            return 0;
        }

        static int get_months()
        {
            string months_text_ascii = @"  __  __             _   _         
 |  \/  |           | | | |        
 | \  / | ___  _ __ | |_| |__  ___ 
 | |\/| |/ _ \| '_ \| __| '_ \/ __|
 | |  | | (_) | | | | |_| | | \__ \
 |_|  |_|\___/|_| |_|\__|_| |_|___/
                                   
                                   ";

            Console.Clear();

            string[] months_array = { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            Console.WriteLine(months_text_ascii);

            for (int i = 0; i < months_array.Length; i++)
            {
                Console.WriteLine("{0} {1}", i, months_array[i]);
            }

            int month_chosen = int.Parse(Console.ReadLine());
            return month_chosen;
        }


    }
}
