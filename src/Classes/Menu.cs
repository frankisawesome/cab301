using System;

namespace cab301
{
    //Could've gone into ToolLibrarySystem but this is not where the main stuff is so I thought I'd make the file more readable.
    //As a result there are a few methods made public in the ToolLibrarySystem class so we can access them here.
    class Menu
    {
        private ToolLibrarySystem library;
        public Menu()
        {
            library = new ToolLibrarySystem();
        }

        //this is the main menu and the default entry point
        public void level1()
        {
            Console.Clear();
            string welcomeMessage = @"Wecome to the Tool Library
            =========Main Menu=========
            1. Staff Login
            2. Member Login
            0. Exit
            ===========================

            Please make a selection (1-2, or 0 to exit)
            ";

            Console.WriteLine(welcomeMessage);
            int selection = 0;
            try
            {
                selection = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                level1();
            }
            select(selection);
        }

        private void select(int selection)
        {
            switch (selection)
            {
                case 1:
                    staff();
                    break;
                case 2:
                    member();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid input, try again:");
                    int selection2 = Convert.ToInt32(Console.ReadLine());
                    select(selection2);
                    break;
            }
        }

        private void staff()
        {
            Boolean loginSuccess = staffLogin();
            if (loginSuccess)
            {
                staffMenu();
            }
            else
            {
                Console.WriteLine("Login failed, back to main menu!");
                level1();
            }
        }

        //this is just a primitive static method to fake as a login, since it's not our focus.
        static Boolean staffLogin()
        {
            Console.WriteLine("Enter your username:");
            string enteredUsername = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string enteredPassword = Console.ReadLine();

            return enteredUsername == "staff" && enteredPassword == "today123";
        }

        //this is a very nasty method, but I don't see how I can avoid it
        //can potentially turn some the menu controllers into static method
        //however that feels quite pointless since they can't be reused.
        private void staffMenu()
        {
            Console.Write(@"
            Welcome to the Tool Lirary
            ============Staff Menu============
            1. Add a new tool
            2. Add new pieces of an existing tool
            3. Remove some pieces of a tool
            4. Register a new member
            5. Remove a member
            6. Find the contact number of a member
            0. Return to main menu
            ");
            Console.WriteLine("Please make a selection (1-6, or 0 to return)");
            int selection = Convert.ToInt16(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    try
                    {
                        library.selectCollection();
                        Console.WriteLine("Enter tool name: ");
                        string toolName = Convert.ToString(Console.ReadLine());
                        library.add(new Tool(toolName));
                        Console.WriteLine("Success!");
                        staffResults();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Action failed! Error: " + e);
                        staffResults();
                    }
                    break;
                case 2:
                    try
                    {
                        library.selectCollection();
                        library.displayTools();
                        Console.WriteLine("Type in the tool you're adding: \n");
                        string toolName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("How many are you adding? \n");
                        int toolCount = Convert.ToInt16(Console.ReadLine());
                        library.add(new Tool(toolName), toolCount);
                        Console.WriteLine("Success!");
                        staffResults();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Action failed! Error: " + e);
                        staffResults();
                    }
                    break;
                case 3:
                    try
                    {
                        library.selectCollection();
                        library.displayTools();
                        Console.WriteLine("Type in the tool you're deleting");
                        string toolName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("How many are you deleting? \n");
                        int toolCount = Convert.ToInt16(Console.ReadLine());
                        library.add(new Tool(toolName), 0 - toolCount);
                        Console.WriteLine("Success!");
                        staffResults();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Action failed! Error: " + e);
                        staffResults();
                    }
                    break;
                case 4:
                    try
                    {
                        Console.WriteLine("Enter first name: ");
                        string firstName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter last name: ");
                        string lastName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter contact number: ");
                        string contact = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter pin code: ");
                        string pin = Convert.ToString(Console.ReadLine());
                        library.add(new Member(firstName, lastName, contact, pin));
                        Console.WriteLine("Success!");
                        staffResults();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Action failed! Error: " + e);
                        staffResults();
                    }
                    break;
                case 5:
                    try
                    {
                        Console.WriteLine("Enter first name: ");
                        string firstName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter last name: ");
                        string lastName = Convert.ToString(Console.ReadLine());
                        //this works because member uses first and last name to compare
                        library.delete(new Member(firstName, lastName, "", ""));
                        Console.WriteLine("Success!");
                        staffResults();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Action failed! Error: " + e);
                        staffResults();
                    }
                    break;
                case 6:
                    try
                    {
                        Console.WriteLine("Enter first name: ");
                        string firstName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter last name: ");
                        string lastName = Convert.ToString(Console.ReadLine());
                        //this works because member uses first and last name to compare
                        library.printContat(firstName, lastName);
                        staffResults();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Action failed! Error: " + e);
                        staffResults();
                    }
                    break;
                case 0:
                    level1();
                    break;
                default:
                    staffMenu();
                    break;
            }
        }

        //take user back to menu after results are shown
        private void staffResults()
        {
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
            staffMenu();
        }

        private void memberResults()
        {
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
            memberMenu();
        }

        private void member()
        {
            try
            {
                memberLogin();
            }
            catch (Exception)
            {
                Console.WriteLine("Log in failed, try again!");
                memberLogin();
            }
        }

        private void memberLogin()
        {
            library.logIn();
            memberMenu();
        }

        private void memberMenu()
        {
            Console.WriteLine(@"
            Welcome to the Tool Library
            =========Member Menu=============
            1. Display all the tools of a tool type
            2. Borrow a tool
            3. Return a tool
            4. List all the tools that I am renting
            5. Display top three (3) most frequently rented tools
            0. Return to main menu
            ===================================

            Please make a selection:
            ");
            int selection = 0;
            try
            {
                selection = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception)
            {
                memberMenu();
            }
            switch (selection)
            {
                case 1:
                    library.selectCollection();
                    library.displayTools();
                    memberResults();
                    break;
                case 2:
                    try
                    {
                        library.selectCollection();
                        library.displayTools();
                        Console.WriteLine("Please enter the tool name you wish to borrow: ");
                        string entered = Convert.ToString(Console.ReadLine());
                        library.borrowTool(new Tool(entered));
                        Console.WriteLine("Successfully borrowed tool!");
                        memberResults();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Action failed, try again!");
                        memberResults();
                    }
                    break;
                case 3:
                    try
                    {
                        library.selectCollection();
                        library.displayBorrowingTools();
                        Console.WriteLine("Please enter the tool you wish to return");
                        string entered = Convert.ToString(Console.ReadLine());
                        library.returnTool(new Tool(entered));
                        Console.WriteLine("Successfully returned tool!");
                        memberResults();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Action failed, try again!");
                        memberResults();
                    }
                    break;
                case 4:
                    try
                    {
                        Console.WriteLine("Displaying borrowing tools: \n");
                        library.displayBorrowingTools();
                        memberResults();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Action failed, try again!");
                        memberResults();
                    }
                    break;
                case 0:
                    level1();
                    break;
                default:
                    Console.WriteLine("Invalid Selection.");
                    memberResults();
                    break;
            }
        }
    }
}