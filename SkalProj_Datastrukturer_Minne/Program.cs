using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

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
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 5, 6, 7, 8, 9, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. Calculate Even Number (Recursive)"
                    + "\n6. Calculate Fibonacci  (Recursive)"
                    + "\n7. Reverse Text"
                    + "\n8. Calculate Even Number (Iterative)"
                    + "\n9. Calculate Fibonacci  (Iterative)"
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
                    case '5':
                        CalculateEvenNumber();
                        break;
                    case '6':
                        CalculateFibonacci();
                        break;
                    case '7':
                        ReverseText();
                        break;
                    case '8':
                        IterativeEvenNumber();
                        break;
                    case '9':
                        IterativeCalculateFibonacci();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0)");
                        break;
                }
            }
        }

        /*
            Frågor

            1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
                The stack, can be seen as a number of boxes stacked on top of each other. Where we use the contents of the top 
                box and to access the bottom one, the above box must first be lifted off. For example, the stack can be seen as shoe 
                boxes in a shoe store, where to access the lower boxes you have to move the upper ones away.
                The heap is a form of structure where everything is available at once with easy access. The heap can be likened 
                to a pile of clean laundry spread over a bed: everything can be reached quickly and easily if we know what we want.
                The stack keeps track of which calls and methods are executed, when the method is executed it is thrown from the 
                stack and the next one is executed. The stack is thus self-maintaining and needs no help with memory. The heap, which 
                holds a large part of the information has no control over execution order, needs to worry about Garbage Collection.

            2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
                Value Types are types from System.ValueType listed below:
                bool, byte, char, decimal, double, enum, ﬂoat, int, long, sbyte , short , struct , uint , ulong , ushort
                Reference Types are types that inherit from System.Object like: class, interface, objects, delegates, thong
                A reference type is always stored on the heap. While Value types, are stored where they are declared. Thus, 
                value types can be stored both on the stack or the heap.

            3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
                in the first method when we write y=x; we copy the value of x and put it in y. so if y gets new value, the original 
                value of x will not change and remain 3.
                In second method we use Reference, so the value of y will be linked to x value. when we change the value of y the 
                value of x will be changed too, so the value of x will be 4 as value of y.

         */

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        /// 

        /*
            2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
                While adding the elements, if Count exceeds Capacity then the Capacity will increase automatically.

            3. Med hur mycket ökar kapaciteten?
                List starts with a capacity of 4 and when we add the 5th element in the List, the List will create another array with 
                the size of previous capacity multiply by 2, which in this case will be 8.

            4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
                When Capacity is increased it reallocating the internal array before copying the old elements and adding the new elements. 
                So it is not increase at the same rate as elements are added.

            5. Minskar kapaciteten när element tas bort ur listan?
                No it doesn't.

            6. När är det då fördelaktigt att använda en egendeﬁnierad array istället för en lista?
                An array has a fixed size and is used when we know the size of the data we'll be working with, and when we need to optimize for 
                performance. so If we need to optimize for performance and memory usage, we use an array.

         */

        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            // Create a list of type string
            List<string> theList = new List<string>();
            Console.WriteLine("Please use '+' to add to the list (+Adam) \n  '-': to remove from the list (-Adam) \n '0' to exit to main menue.");

            while (true)
            {
                // Getting user input
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);  // Add to list
                        Console.WriteLine($"{value} is added to the list");
                        Console.WriteLine($"List Count: {theList.Count}");  // Displaying list count
                        Console.WriteLine($"List Capacity: {theList.Capacity}"); // Displaying list capacity
                        break;
                    case '-':
                        theList.Remove(value);  // Remove from the list
                        Console.WriteLine($"{value} is removed from the list");
                        Console.WriteLine($"List Count: {theList.Count}");
                        Console.WriteLine($"List Capacity: {theList.Capacity}");
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter some valid input (+, - or 0)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            try
            {
                // Creating ICAqueue
                SimulateQueue<string> ICAqueue = new SimulateQueue<string>();

                while (true)
                {
                    Console.WriteLine("Please use '+' to enqueue \n  '-': to dequeue \n '0' to exit to main menue.");

                    // Getting user input
                    string input = Console.ReadLine();
                    char nav = input[0];

                    switch (nav)
                    {
                        case '+':
                            Console.WriteLine("Please enter name");
                            ICAqueue.Enqueue(Console.ReadLine());  // Putting element in the queue
                            break;
                        case '-':
                            ICAqueue.Dequeue();  // Removing element from the queue
                            break;
                        case '0':
                            return;
                        default:
                            Console.WriteLine("Please enter some valid input (+, - or 0)");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        /// 

        /*
             Varför är det inte så smart att använda en stack i det här fallet?
                Because stacks use the First In Last Out (FILO) principle.
         */

        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            try
            {
                // Creating ICAstack
                Stack<string> ICAstack = new Stack<string>();

                while (true)
                {
                    Console.WriteLine("Please use '+' to push \n  '-': to pop \n '0' to exit to main menue.");

                    // Getting user input
                    string input = Console.ReadLine();
                    char nav = input[0];

                    switch (nav)
                    {
                        case '+':
                            Console.WriteLine("Please enter name");
                            string name = Console.ReadLine();

                            ICAstack.Push(name);  // Inserting element to the stack
                            Console.WriteLine($"{name} ställer sig i kön");
                            break;
                        case '-':
                            if (ICAstack.Count > 0)
                                Console.WriteLine($"{ICAstack.Pop()} blir expedierad och lämnar kön");  // Removing element from the stack
                            break;
                        case '0':
                            return;
                        default:
                            Console.WriteLine("Please enter some valid input (+, - or 0)");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        static void CheckParanthesis()
        {
            /*
            Vilken datastruktur använder du?
                I will use Stack to solve this task
            */

            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            // Getting user input
            Console.WriteLine("Enter text");
            string text = Console.ReadLine();

            if (IsValid(text))  // Calling IsValid method
            {
                Console.WriteLine("The paranthesis in the string is correct");
            }
            else
            {
                Console.WriteLine("The paranthesis in the string is incorrect");
            }
        }

        static void ReverseText()
        {
            // Getting user input
            Console.WriteLine("Enter text");
            string text = Console.ReadLine();

            Stack<char> stack = new Stack<char>();  // Creating stack of type char

            foreach (char ch in text)
            {
                stack.Push(ch);  // Pushing char to stack
            }

            Console.Write("The reversed text: ");
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());  // Removing from the stack
            }

            Console.WriteLine();
        }

        public static bool IsValid(string text)
        {
            Stack<char> stack = new Stack<char>();  // Creating stack of type char
            bool valid = true;

            foreach (char ch in text)  // Using foreach-loop to get character from string
            {

                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);  // Pushing char to stack
                    valid = false;
                }

                if (ch == ')' && stack.Count != 0 && stack.Peek() == '(')
                {
                    stack.Pop();  // Removing from the stack
                    valid = true;
                }
                if (ch == '}' && stack.Count != 0 && stack.Peek() == '{')
                {
                    stack.Pop();  // Removing from the stack
                    valid = true;
                }
                if (ch == ']' && stack.Count != 0 && stack.Peek() == '[')
                {
                    stack.Pop();  // Removing from the stack
                    valid = true;
                }
            }
            return valid;
        }

        /*
            Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering. Vilken av ovanstående funktioner är mest minnesvänlig och varför?
                Recursion uses more memory in comparison to iteration because the memory allocation is greater than that of an iteration. 
                The function will keep the values in the stack until the call is finished. 
         */

        static void CalculateEvenNumber()
        {
            int n;
            Console.WriteLine("Enter the number");

            if (int.TryParse(Console.ReadLine(), out n))  // Getting user input and TryParse it
            {
                Console.WriteLine($"The {n}th even number is {RecursiveEven(n)}");  // Calling RecursiveEven method and display the result
            }
        }

        static void IterativeEvenNumber()
        {
            int n;
            Console.WriteLine("Enter the number");

            if (int.TryParse(Console.ReadLine(), out n))  // Getting user input and TryParse it
            {
                Console.WriteLine($"The {n}th even number is {IterativeEven(n)}");  // Calling IterativeEven method and display the result
            }
        }

        static void CalculateFibonacci()
        {
            int n;
            Console.WriteLine("Enter the number");

            if (int.TryParse(Console.ReadLine(), out n))  // Getting user input and TryParse it
            {
                Console.WriteLine($"The number in the Fibonacci sequence is {Fibonacci(n)}");  // Calling Fibonacci method and display the result
            }
        }

        static void IterativeCalculateFibonacci()
        {
            int n;
            Console.WriteLine("Enter the number");

            if (int.TryParse(Console.ReadLine(), out n))  // Getting user input and TryParse it
            {
                Console.WriteLine($"The number in the Fibonacci sequence is {IterativeFibonacci(n)}");  // Calling IterativeFibonacci method and display the result
            }
        }

        static int RecursiveEven(int n)
        {
            if (n == 1) return 2;
            return (RecursiveEven(n - 1) + 2);
        }

        static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        static int IterativeEven(int n)
        {
            int result = 2;

            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }

            return result;
        }

        static int IterativeFibonacci(int n)
        {
            int a = 0, b = 1, c = 0;

            if (n == 0)
                return a;

            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return b;
        }

    }
}

