using System;
using System.Collections.Generic;

namespace cab301 {
    class ToolLibrarySystem:iToolLibrarySystem {
        private Dictionary<String, ToolCollection> gardeningTools = new Dictionary<string, ToolCollection>();
        private Dictionary<String, ToolCollection> flooringTools = new Dictionary<string, ToolCollection>();
        private Dictionary<String, ToolCollection> fencingTools = new Dictionary<string, ToolCollection>();
        private Dictionary<String, ToolCollection> measuringTools = new Dictionary<string, ToolCollection>();
        private Dictionary<String, ToolCollection> cleaningTools = new Dictionary<string, ToolCollection>();
        private Dictionary<String, ToolCollection> paintingTools = new Dictionary<string, ToolCollection>();
        private Dictionary<String, ToolCollection> electronicTools = new Dictionary<string, ToolCollection>();
        private Dictionary<String, ToolCollection> electricityTools = new Dictionary<string, ToolCollection>();
        private Dictionary<String, ToolCollection> automotiveTools = new Dictionary<string, ToolCollection>();
        private MemberCollection members;
        private Member currentMember;
        private ToolCollection currentCollection;

        public ToolLibrarySystem () {
            initDictionaries();
            members = new MemberCollection();
        }

        public void add (iTool tool) {
            currentCollection.add(tool);
        } 
        //this is some crazy code - written solely to work with the method contraints
        //this method finds the existing tool in the collection, basically deep clones the Tool object
        //deletes the old Tool and adds the newly updated tool
        public void add (iTool tool, int quantity) {
            if (!currentCollection.search(tool)) {
                throw new Exception("Invalid tool name");
            }
            iTool[] tools = currentCollection.toArray();
            for (int i = 0; i < tools.Length; i++) {
                if (tools[i].Name == tool.Name) {
                    tool.Quantity = tools[i].Quantity + quantity;
                    tool.NoBorrowings = tools[i].NoBorrowings;
                    tool.AvailableQuantity = tools[i].Quantity + quantity;
                }
            }
            //this works because our delete only checks name
            currentCollection.delete(tool);
            currentCollection.add(tool);
        } 

        //I don't see any functionality of this, tools can't be deleted based on the menu?
        public void delete (iTool tool) {
            
        } 
        public void delete (iTool tool, int quantity) {
            if (!currentCollection.search(tool)) {
                throw new Exception("Invalid tool name");
            }
            iTool[] tools = currentCollection.toArray();
            for (int i = 0; i < tools.Length; i++) {
                if (tools[i].Name == tool.Name) {
                    if (tools[i].AvailableQuantity < quantity) {
                        throw new Exception ("You're trying to delete too many items!");
                    }
                    tool.Quantity = tools[i].Quantity - quantity;
                    tool.NoBorrowings = tools[i].NoBorrowings;
                    tool.AvailableQuantity = tools[i].Quantity - quantity;
                }
            }
            //this works because our delete only checks name
            currentCollection.delete(tool);
            currentCollection.add(tool);
        } 
        public void add (iMember member) {
            iMember searchResult = members.search(member);
            if (searchResult == null) {
                members.add(member);
            } else {
                throw new Exception ("Member already exists");
            }
        }
        public void delete (iMember member) {
            iMember searchResult = members.search(member);
            if (searchResult != null) {
                members.delete(member);
            } else {
                throw new Exception ("Member doesnt' exist");
            }
        }
        public void displayBorrowingTools (iMember member) {

        }
        public void displayTools () {
            if (currentCollection == null) {
                selectCollection();
            }
            Console.WriteLine("Current selection of tools includes:");
            iTool[] tools = currentCollection.toArray();
            for (int i = 0; i < tools.Length; i++) {
                Console.WriteLine((i + 1) + ". " + tools[i].Name);
                Console.WriteLine("Quantity: " + tools[i].Quantity.ToString());
                Console.WriteLine("Available: " + tools[i].AvailableQuantity.ToString() + "\n");
            }
        }

        public void printContat (string firstName, string lastName) {
            iMember member = members.search(new Member(firstName, lastName, "", ""));
            if (member == null) {
                Console.WriteLine("Member not found!");
            } else {
                Console.WriteLine("Contact Number of " + firstName + ": " + member.ContactNumber);
            }
        }
        public void borrowTool (iMember member, iTool tool) {

        }
        public void returnTool (iMember member, iTool tool) {

        }
        public string[] listTools (iMember member) {
            return new string[] {};
        }
        public void displayTopThree () {

        }

        //long and boring method adding tool collections to each tool category dictionary
        private void initDictionaries () {
            String[] gardeningToolTypes = {"Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheelbarrows", "Garden Power Tools"};
            foreach (String type in gardeningToolTypes)
            {
                gardeningTools.Add(type, new ToolCollection());
            }
            
            String[] flooringToolTypes = {"Scrapers", "Floor Lasers", "Floor Levelling Tools", "Floor Levelling Materials", "Floor Hand Tools", "Tiling Tools"};
            foreach (String type in flooringToolTypes)
            {
                flooringTools.Add(type, new ToolCollection());
            }
            
            String[] fencingToolTypes = {"Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories"};
            foreach (String type in fencingToolTypes)
            {
                fencingTools.Add(type, new ToolCollection());
            }
        }

        //another long and boring method that gets user to select which tool type they're performing actions on
        public void selectCollection () {
            currentCollection = null;
            Console.Write(@"Select tool category:
                    1. Gardening Tools
                    2. Flooring Tools
                    3. Fencing Tools
                    4. Measuring Tools
                    5. Cleaning Tools
                    6. Painting Tools
                    7. Electronic Tools
                    8. Elecricity Tools
                    9. Automotive Tools");
            Console.Write("\nEnter your tool category number\n");
            int categorySelection = Convert.ToInt16(Console.ReadLine());
            String typeSelection;
            switch (categorySelection)
            {
                case 1:
                    Console.Write("\nSelect a tool type: " +
                        "\n1. Line Trimmers" +
                        "\n2. Lawn Mowers" +
                        "\n3. Hand Tools" +
                        "\n4. Wheelbarrows" +
                        "\n5. Garden Power Tools\n");
                    Console.Write("Enter your tool type (in string): ");
                    typeSelection = Convert.ToString(Console.ReadLine());
                    gardeningTools.TryGetValue(typeSelection, out currentCollection);
                    break;
                case 2:
                    Console.Write("Select a tool type: " +
                        "\n1. Scrapers" +
                        "\n2. Floor Lasers" +
                        "\n3. Floor Levelling Tools" +
                        "\n4. Floor Levelling Materials" +
                        "\n5. Floor Hand Tools" +
                        "\n6. Tiling Tools\n");
                    Console.Write("Enter your tool type (in string): ");
                    typeSelection = Convert.ToString(Console.ReadLine());
                    gardeningTools.TryGetValue(typeSelection, out currentCollection);
                    break;
                case 3:
                    Console.Write("Select a tool type: " +
                        "\n1. Hand Tools" +
                        "\n2. Electric Fencing" +
                        "\n3. Steel Fencing Tools" +
                        "\n4. Power Tools" +
                        "\n5. Fencing Accessories\n");
                    Console.Write("Enter your tool type (in string): ");
                    typeSelection = Convert.ToString(Console.ReadLine());
                    gardeningTools.TryGetValue(typeSelection, out currentCollection);
                    break;
                case 4:
                    Console.Write("Select a tool type: " +
                        "\n1. Distance Tools" +
                        "\n2. Laser Measurer" +
                        "\n3. Measuring Jugs" +
                        "\n4. Temperature & Humidity Tools" +
                        "\n5. Levelling Tools" +
                        "\n6. Markers\n");
                    Console.Write("Enter your tool type (in string): ");
                    typeSelection = Convert.ToString(Console.ReadLine());
                    gardeningTools.TryGetValue(typeSelection, out currentCollection);
                    break;
                case 5:
                    Console.Write("Select a tool type: " +
                        "\n1. Draining" +
                        "\n2. Car Cleaning" +
                        "\n3. Vacuum" +
                        "\n4. Pressure Cleaners" +
                        "\n5. Pool Cleaning" +
                        "\n6. Floor Cleaning\n");
                    Console.Write("Enter your tool type (in string): ");
                    typeSelection = Convert.ToString(Console.ReadLine());
                    gardeningTools.TryGetValue(typeSelection, out currentCollection);
                    break;
                case 6:
                    Console.Write("Select a tool type: " +
                        "\n1. Sanding Tools" +
                        "\n2. Brushes" +
                        "\n3. Rollers" +
                        "\n4. Paint Removal Tools" +
                        "\n5. Paint Scrapers" +
                        "\n6. Sprayers\n");
                    Console.Write("Enter your tool type (in string): ");
                    typeSelection = Convert.ToString(Console.ReadLine());
                    gardeningTools.TryGetValue(typeSelection, out currentCollection);
                    break;
                case 7:
                    Console.Write("Select a tool type: " +
                        "\n1. Voltage Tester" +
                        "\n2. Oscilloscopes" +
                        "\n3. Thermal Imaging" +
                        "\n4. Data Test Tool" +
                        "\n5. Insulation Testers\n");
                    Console.Write("Enter your tool type (in string): ");
                    typeSelection = Convert.ToString(Console.ReadLine());
                    gardeningTools.TryGetValue(typeSelection, out currentCollection);
                    break;
                case 8:
                    Console.Write("Select a tool type: " +
                        "\n1. Test Equipment" +
                        "\n2. Safety Equipment" +
                        "\n3. Basic Equipment" +
                        "\n4. Circuit Protection" +
                        "\n5. Cable Tools\n");
                    Console.Write("Enter your tool type (in string): ");
                     typeSelection = Convert.ToString(Console.ReadLine());
                    gardeningTools.TryGetValue(typeSelection, out currentCollection);
                    break;
                case 9:
                    Console.Write("Select a tool type: " +
                        "\n1. Jacks" +
                        "\n2. Air Compressors" +
                        "\n3. Battery Chargers" +
                        "\n4. Socket Tools" +
                        "\n5. Braking" +
                        "\n6. Drivetrain\n");
                    Console.Write("Enter your tool type (in string): ");
                    typeSelection = Convert.ToString(Console.ReadLine());
                    gardeningTools.TryGetValue(typeSelection, out currentCollection);
                    break;
                default:
                    Console.WriteLine("Invalid Input, try again:");
                    selectCollection();
                    break;
            }
            if (currentCollection == null) {
                Console.WriteLine("Did you type in the right type? Try again!");
                selectCollection();
            } 
        }
    }
}