using System;

namespace cab301 {
    class ToolLibrarySystem:iToolLibrarySystem {
        private iToolCollection tools;
        private iMemberCollection members;

        public ToolLibrarySystem () {
            
        }

        public void add (iTool tool) {

        } 
        public void add (iTool tool, int quantity) {

        } 
        public void delete (iTool tool) {
            
        } 
        public void delete (iTool tool, int quantity) {
            
        } 
        public void add (iMember member) {

        }
        public void delete (iMember member) {

        }
        public void displayBorrowingTools (iMember member) {

        }
        public void displayTools (string toolType) {

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
    }
}