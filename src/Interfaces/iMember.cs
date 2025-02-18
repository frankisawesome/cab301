﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cab301
{
    //The specification of Member ADT
    interface iMember: IComparable
    {
        
        string FirstName  //get and set the first name of this member
        {
            get;
            set;
        }
        string LastName //get and set the last name of this member
        {
            get;
            set;
        }

        string ContactNumber //get and set the contact number of this member
        {
            get;
            set;
        }

        string PIN //get and set the password of this member
        {
            get;
            set;
        }

        string[] Tools //get a list of tools that this memebr is currently holding
        {
            get;
        }

        void addTool(iTool aTool); //add a given tool to the list of tools that this member is currently holding

        void deleteTool(iTool aTool); //delete a given tool from the list of tools that this member is currently holding
    }
}
