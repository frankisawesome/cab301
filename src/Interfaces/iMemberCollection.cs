﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cab301
{
    //The specification of MemberCollection ADT, which is used to store and manipulate a collection of members
    
    interface iMemberCollection
    {
        int Number // get the number of members in the community library
        {
            get;
        }

        void add(iMember aMember); //add a new member to this member collection, make sure there are no duplicates in the member collection

        void delete(iMember aMember); //delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool

        //this is modified as returning a bool rather than the actual item makes 0 sense
        Member search(iMember aMember); //search a given member in this member collection. Return true if this memeber is in the member collection; return false otherwise.

        iMember[] toArray(); //output the memebers in this collection to an array of iMember
    }
}
