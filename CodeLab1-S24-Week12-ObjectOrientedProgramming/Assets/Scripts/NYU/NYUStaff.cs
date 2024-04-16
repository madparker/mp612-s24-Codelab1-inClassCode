using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUStaff : NYUPerson
{
    public float salary;

    public NYUStaff()
    {
        type = "NYU Staff";
    }

    public NYUStaff(string name, string netId, float salary) : base(name, netId)
    {
        type = "NYU Staff";
        this.salary = salary;
    }

    public override string ShowRecord()
    {
        return base.ShowRecord() + "salary: " + salary + "\n";
    }
}
