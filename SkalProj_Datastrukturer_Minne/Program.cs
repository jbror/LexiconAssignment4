using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            // Listan skapas här tom och har 0 i kapacitet. När jag lägger till en sträng ökas kapaciteten med 4.
            // När jag lägger ytterligare fyra strängar till och sedan överstiger kapaciteten fördubblas den och blir 8.
            // Att öka den i samma takt som man lägger leder till att listan behöver skrivas om och kopieras över ofta vilket kostar prestanda. 
            // Listor är smart och enkelt när man vill lägga till saker och inte behöva tänka själv på kapaciteten. 
            // Arrays är prestandamässigt bättre och passar bäst när man vet att kapaciteten är "klar" och inte har något behov att ändra.
            // Listan minskas inte automatiskt om jag tar bort saker. Det går dock att göra manuellt.


            List<string> theList = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter something to add or remove in my list! (+Input or -Input is accepted)");
                Console.WriteLine("If you want to exit enter exit");
                Console.WriteLine("-----------------");
                Console.WriteLine($"List count and capacity is at the moment: Count: {theList.Count} Capacity: {theList.Capacity}");
                Console.WriteLine("Enter input:");

                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "exit")
                {
                    Console.WriteLine("Bye bye");
                    break;
                }
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input can't be empty!\n");
                    continue;
                }
                if ((input[0] != '+' && input[0] != '-') || input.Length < 2 || char.IsWhiteSpace(input[1]))
                {
                    Console.WriteLine("Invalid input. + or - followed by input please. Try again!\n");
                    continue;
                }


                char nav = input[0];
                string value = input.Substring(1).Trim();


                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"{value} added to the list!\n");
                        break;

                    case '-':
                        int before = theList.Count;
                        theList.RemoveAll(s => s.Equals(value));
                        int removed = before - theList.Count;
                        Console.WriteLine($"Removed: {removed} containing: {value}.\n");
                        break;

                }


            }


            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {

        // I en "kö"(Queeue) så läggs element till i ordning liknande en tradionell "kö".
        // Om kön på Ica är tom och jag ställer mig i kön är jag alltså först i kön och kommer få hjäp och lämmna kön först.
        // Kalle som ställde sig i kön efter mig blir först i kön när jag blir expiderad osv. 

        // Ica kön [ ] (Tom kö)
        // Ica kön [Bror] (Jag ställer mig i kön)
        // Ica kön [Bror, Kalle] (Kalle ansluter till kön)
        // Ica kön [Kalle] (Jag blir expideras och lämmnar kön. Kalle är nu först i kön)


            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\n-- ICA Queue  --");
                Console.WriteLine("1. Enqueue  person");
                Console.WriteLine("2. Dequeue (serve) the first person");
                Console.WriteLine("3. Show  current queue");
                Console.WriteLine("4. Return to main menu");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {

                    case "1":
                        Console.Write("Enter the name of the person to enqueue: ");
                        string name = Console.ReadLine();
                        queue.Enqueue(name);
                        Console.WriteLine($"{name} has entered the queue.");
                        break;

                    case "2":
                        if (queue.Count > 0)
                        {
                            string served = queue.Dequeue();
                            Console.WriteLine($"{served} has been served and removed from the queue.");
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty. No one to serve.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("people currently in the queue:");
                        foreach (var person in queue)
                        {

                            Console.WriteLine(person);
                        }
                        if (queue.Count == 0)
                        {
                            Console.WriteLine("The queue is empty.");
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }


            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */




        }
        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {

            Console.WriteLine("Enter text and i will reverse it back to you.\nInput: ");
            string input = Console.ReadLine();

            Stack<char> stack  = new Stack<char>();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            Console.WriteLine("Text reversed: ");

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }




            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

