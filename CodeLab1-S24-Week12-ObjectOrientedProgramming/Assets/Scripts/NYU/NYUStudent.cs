using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUStudent : NYUPerson
{
    public float financialAid;
    public float gpa;

    public NYUStudent()
    {
        financialAid = 0;
        gpa = 0.000f;
        type = "NYU Student";
    }

    public NYUStudent(string name, string netId, float financialAid, float gpa): base(name, netId)
    {
        this.financialAid = financialAid;
        this.gpa = gpa;
        type = "NYU Student";
    }

    public override string ShowRecord()
    {
        return base.ShowRecord() + 
               "Financial Aid: $" + financialAid + "\n" + 
               "GPA: " + gpa + "\n";
    }
}
