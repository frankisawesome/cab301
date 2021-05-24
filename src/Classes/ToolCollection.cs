using System;

namespace cab301
{
  class ToolCollection : iToolCollection
  {
    private int number;

    private iTool[] collection;

    public int Number { get { return number; } }

    public ToolCollection()
    {
      collection = new Tool[127];
    }

    //adds the tool to next available position in the collection
    public void add(iTool tool)
    {
      for (int i = 0; i < collection.Length; i++)
      {
        if (collection[i] == null)
        {
          collection[i] = tool;
          number++;
          return;
        }
      }
      throw new Exception("Collection full!");
    }

    //loops through the array and deletes the tool with the same name
    public void delete(iTool tool)
    {
      for (int i = 0; i < collection.Length; i++)
      {
        if (collection[i].Name == tool.Name)
        {
          collection[i] = null;
          number--;
          return;
        }
      }
      throw new Exception("Tool not found! Deletion failed.");
    }

    public Boolean search(iTool tool)
    {
      for (int i = 0; i < collection.Length; i++)
      {
        if (collection[i].Name == tool.Name)
        {
          return true;
        }
      }
      return false;
    }
    public iTool[] toArray()
    {
      Tool[] reduced = new Tool[number];
      for (int i = 0; i < collection.Length; i++)
      {
        if (collection[i] != null)
        {
          reduced[i] = (Tool)collection[i];
        }
      }
      return reduced;
    }
  }
}