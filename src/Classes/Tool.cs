namespace cab301 {

    class Tool:iTool {

        private iMemberCollection borrowers;

        public Tool (string name) {
            Name = name;
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int NoBorrowings { get; set; }

        public iMemberCollection GetBorrowers { 
            get {
                return borrowers;
            }
         }

        public void addBorrower (iMember borrower) {
            borrowers.add(borrower);
        }

        public void deleteBorrower (iMember borrower) {
            borrowers.delete(borrower);
        }
    }
}