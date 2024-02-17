using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal class Program
    {
        static void showQuestions(string[,]questions,int select,int question)
        { 
            for (int i = 0; i < 5; i++)
            {
                if (select == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(questions[question, i]);
                    Console.ForegroundColor = ConsoleColor.White;
                   continue;
                }
                Console.WriteLine(questions[question, i]);
            }

        }
        static void selectAnswer(string[,]questions,ref int points)
        {
            int question = 0;
            int select = 1;
            char answer = 'A'; 
            while (true) 
            {

                showQuestions(questions, select, question);
                ConsoleKeyInfo choice = Console.ReadKey();
                if (choice.Key == ConsoleKey.UpArrow)
                {
                    if (select == 1) { select = 4; }
                    else { select--; }
                }
                else if (choice.Key == ConsoleKey.DownArrow)
                { 
                    if (select == 4) { select = 1; }
                    else { select++; }
                }
                else if (choice.Key == ConsoleKey.Enter)
                {
                    if (select == 1) { answer = 'A'; }
                    else if (select == 2) { answer = 'B'; }
                    else if (select == 3) { answer = 'C'; }
                    else if (select == 4) { answer = 'D'; }
                    if (questions[question,5]==answer.ToString())
                    {
                        Console.WriteLine("Bu duz cavabdir) +5 xal");
                        points+=5;
                    }
                    else
                    {
                        Console.WriteLine("Bu sehv cavabdir(");
                    }
                    Thread.Sleep(1000);
                    question++;
                }
                Console.Clear();
                if (question==5) 
                {
                    Console.WriteLine($"Oyun bitdi)\nNeticeni - {points}");
                    return; 
                }
            }
        }
        static void Main(string[] args)
        { 
        
            int points = 0;
            string[,] questions = {
                { "Azerbaycanin paytaxti haradir?","A:Baki","B:Sumqayit","C:Gence","D:Ordubad","A" },
                { "Bu tapsiriga gore mene nece yazacaqsiz?","A:9","B:10","C:11","D:12","D" },
                { "Ikinci dunya muharubesu necencu ilde baslayib?","A:1914","B:1918","C:1939","D:1941","C" },
                { "Ordubad neyi ile meshurdu?","A:Encir","B:Limon","C:Nar","D:Qarpiz","B" },
                { "Azerbaycannan hansi olkeye visasiz getmek olar?","A:Yaponiya","B:Italiya","C:Monteneqro","D:Turkmenistan","C" } };

            selectAnswer(questions,ref points);

        }
    }
}
