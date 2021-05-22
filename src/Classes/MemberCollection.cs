using System;

namespace cab301 {
    class MemberCollection:iMemberCollection {
        private int number;

        public int Number { get { return number; } }

        public void add (iMember member) {

        }

        public void delete (iMember member) {

        }

        public Boolean search (iMember member) {
            return false;
        }  

        public iMember[] toArray() {
            return new iMember [] {};
        }
    }
}