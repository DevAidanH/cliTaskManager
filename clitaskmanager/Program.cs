using System;

class Program
{
    //Output start menu
    //View a list of tasks outstanding
    //Complete a task
    //Add a task
    static List<string> tasks = new List<string>();
    static void Main()
    {
        bool running = true;
        string selectedTask;
        int menuSelection;

        while (running == true)
        {
            Console.WriteLine("=== Welcome to CLI Tasks ===\nPlease select an option from the menu below");
            Console.WriteLine("=== Main Menu ===\n1 - View outstanding tasks\n2 - Add a new task\n3 - Quit program");
            try
            {
                menuSelection = Int32.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        taskView();
                        break;
                    case 2:
                        Console.WriteLine("Please input your task >> ");
                        addTask(Console.ReadLine());
                        Console.WriteLine("Adding task...");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("Task added");
                        break;
                    case 3:
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        break;
                }
            }
            catch (FormatException) {
                Console.WriteLine("Please only enter a valid number");
            }
            System.Threading.Thread.Sleep(1000);
        }
    }
    //View task page
    static void taskView()
    {
        displayTasks();
        Console.WriteLine("Please type the name of a task to mark it as completed. Please type x to return to the main menu >> ");
        string userInput = Console.ReadLine();
        if (tasks.Contains(userInput))
        {
            tasks.Remove(userInput);
            Console.WriteLine("Marking complete...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Task Completed! - Returning to main menu...");
        }
        else
        {
            if (userInput == "x")
            {
                return;
            }
            else
            {
                Console.WriteLine("No matching task found - Returning to main menu...");
                System.Threading.Thread.Sleep(1000);
                return;
            }
        }
    }
    //Output tasks
    static void displayTasks()
    {
        Console.WriteLine("=== Tasks ===");
        foreach (var task in tasks)
        {
            Console.WriteLine($"* {task}");
        }
    }
    //Add a new task
    static void addTask(string task)
    {
        tasks.Add(task);
    }
}