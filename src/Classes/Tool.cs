using System.Collections.Generic;

namespace cab301 {

    class Tool:iTool {

        private List<iMember> borrowers;

        public Tool (string name) {
            borrowers = new List<iMember> ();
            Quantity = 1;
            AvailableQuantity = 1;
            NoBorrowings = 0;
            Name = name;
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int NoBorrowings { get; set; }

        public List<iMember> GetBorrowers { 
            get {
                return borrowers;
            }
         }

        public void addBorrower (iMember borrower) {
            borrowers.Add(borrower);
        }

        public void deleteBorrower (iMember borrower) {
            borrowers.Remove(borrower);
        }
    }
}