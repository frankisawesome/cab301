using System;
using System.Collections.Generic;

namespace cab301
{
    class Member : iMember
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNumber { get; set; }

        public string PIN { get; set; }

        private List<iTool> tools;
        public string[] Tools
        {
            get
            {
                string[] toolsString = new string[tools.Count];
                for (int i = 0; i < tools.Count; i++)
                {
                    toolsString[i] = tools[i].Name;
                }
                return toolsString;
            }
        }

        public Member(string first, string last, string contact, string pin)
        {
            tools = new List<iTool>();
            this.FirstName = first;
            this.LastName = last;
            this.ContactNumber = contact;
            this.PIN = pin;
        }

        public void addTool(iTool tool)
        {
            tools.Add(tool);
        }

        public void deleteTool(iTool tool)
        {
            //remove match based on name
            iTool match = tools.Find(match => tool.Name == match.Name);
            tools.Remove(match);
        }

        //implement IComparable
        public int CompareTo(object member)
        {
            iMember castedMember = (iMember)member;
            int compareLast = LastName.CompareTo(castedMember.LastName);

            if (compareLast == 0)
            {
                return FirstName.CompareTo(castedMember.FirstName);
            }
            else
            {
                return compareLast;
            }
        }


        //return a string containing the first name, lastname, and contact phone number of this memeber
        override public string ToString()
        {
            return "Name: " + FirstName + " " + LastName + " Contact: " + ContactNumber;
        }
    }
}