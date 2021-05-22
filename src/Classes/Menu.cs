using System;

namespace cab301 {
    //Could've gone into ToolLibrarySystem but this is not where the main stuff is so I thought I'd make the file more readable.
    //As a result there are a few methods made public in the ToolLibrarySystem class so we can access them here.
    class Menu {
        private ToolLibrarySystem library;
        public Menu () {
            library = new ToolLibrarySystem();
        }

        public void level1() {
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
            try {
                selection = Convert.ToInt32(Console.ReadLine());
            } catch (Exception e) {
                level1();
            }
            select(selection);
        }

        private void select(int selection) {
             switch (selection) {
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

        private void staff() {
            Boolean loginSuccess = staffLogin();
            if (loginSuccess) {
                staffMenu();
            } else {
                Console.WriteLine("Login failed, back to main menu!");
                level1();
            }
        }

        static Boolean staffLogin() {
            Console.WriteLine("Enter your username:");
            string enteredUsername = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string enteredPassword = Console.ReadLine();

            return enteredUsername == "staff" && enteredPassword == "today123";
        }

        private void staffMenu() {
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

            switch (selection) {
                case 1:
                    try {
                        library.selectCollection();
                        Console.WriteLine("Enter tool name: ");
                        string toolName = Convert.ToString(Console.ReadLine());
                        library.add(new Tool(toolName));
                        Console.WriteLine("Success!");
                        staffMenu();
                    } catch (Exception e) {
                        Console.WriteLine("Action failed! Error: " + e);
                        staffMenu();
                    }
                    break;
                case 2:
                    try {
                        library.selectCollection();
                        library.displayTools();
                        Console.WriteLine("Type in the tool you're adding: \n");
                        string toolName = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("How many are you adding? \n");
                        int toolCount = Convert.ToInt16(Console.ReadLine());
                        library.add(new Tool(toolName), toolCount);
                        Console.WriteLine("Success!");
                        staffMenu();
                    } catch (Exception e) {
                        Console.WriteLine("Action failed! Error: " + e);
                        staffMenu();
                    }
                    break;
                case 3:
                    try {
                        library.selectCollection();
                        library.displayTools();
                        Console.WriteLine("Type in the tool you're deleting");
                        string toolName = Convert.ToString(Console.ReadLine());
                        library.delete(new Tool(toolName));
                        Console.WriteLine("Success!");
                        staffMenu();
                    } catch (Exception e) {
                        Console.WriteLine("Action failed! Error: " + e);
                        staffMenu();
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


        private void member() {

        }
    }
}