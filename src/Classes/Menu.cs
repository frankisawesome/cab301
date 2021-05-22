using System;

namespace cab301 {
    class Menu {
        private iToolLibrarySystem library;

        public Menu () {
            library = new ToolLibrarySystem();
        }

        public void level1() {
            string welcomeMessage = @"Wecome to the Tool Library
            =========Main Menu=========
            1. Staff Login
            2. Member Login
            0. Exit
            ===========================

            Please make a selection (1-2, or 0 to exit)
            ";

            Console.WriteLine(welcomeMessage);
            int selection = Convert.ToInt32(Console.ReadLine());
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


        private void member() {

        }
    }
}