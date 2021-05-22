using System;

namespace cab301
{
  class Member : iMember
  {
    public string FirstName  { get; set; }

    public string LastName { get; set; }

    public string ContactNumber { get; set; }

    public string PIN { get; set; }

    private string[] _tools;
    public string[] Tools {
      get => _tools;
    }

    public Member (string first, string last, string contact, string pin) {
      this.FirstName = first;
      this.LastName = last;
      this.ContactNumber = contact;
      this.PIN = pin;
    }

    public void addTool (iTool tool) {

    }

    public void deleteTool (iTool tool) {

    }

    //implement IComparable
    public int CompareTo (object member) {
      iMember castedMember = (iMember)member;
      int compareLast = LastName.CompareTo(castedMember.LastName);

      if (compareLast == 0) {
        return FirstName.CompareTo(castedMember.FirstName);
      } else {
        return compareLast;
      }
    }

    
    //return a string containing the first name, lastname, and contact phone number of this memeber
    override public string ToString()
    {
      return "";
    }      
  }
}