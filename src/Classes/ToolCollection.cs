using System;

namespace cab301 {
    class ToolCollection:iToolCollection {
        private int number;

        private iTool[] collection;

        public int Number { get { return number; } }

        public void add (iTool tool) {

        }

        public void delete (iTool tool) {

        }

        public Boolean search (iTool tool) {
            return false;
        }

        public iTool[] toArray () {
            return collection;
        }
    }
}