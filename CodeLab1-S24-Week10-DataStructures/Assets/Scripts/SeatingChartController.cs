using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeatingChartController : MonoBehaviour
{
    private int numRows = 5;
    private int numCols = 8;

    private string[,] seatingChart;

    public Text display;
    
    void Start()
    {
        seatingChart = new string[numCols, numRows];

        for (int x = 0; x < seatingChart.GetLength(0); x++)
        {
            for (int y = 0; y < seatingChart.GetLength(1); y++)
            {
                seatingChart[x, y] = "";
            }
        }

        seatingChart[0, 0] = "ST";
        seatingChart[0, 1] = "DH";
        seatingChart[0, 2] = "AZ";
        seatingChart[0, 3] = "AT";
        seatingChart[0, 4] = "MF";
        seatingChart[1, 0] = "AG";
        seatingChart[1, 1] = "YL";
        seatingChart[1, 2] = "VC";
        seatingChart[1, 3] = "SP";
        seatingChart[0, 3] = "YB";
        seatingChart[1, 3] = "AX";
        seatingChart[2, 3] = "HW";
        seatingChart[4, 3] = "JD";
        seatingChart[5, 3] = "LY";
        seatingChart[6, 3] = "EC";
        seatingChart[7, 3] = "TW";
        
        

        PrintWhereSeated();
    }

    public void PrintWhereSeated()
    {
        string toPrint = "~~~~ FRONT ~~~~\n";
        for (int y = 0; y < seatingChart.GetLength(1); y++)
        {
            for (int x = 0; x < seatingChart.GetLength(0); x++)
            {
                if (seatingChart[x, y] != "")
                {
                    toPrint += seatingChart[x, y] + "_";
                }
                else
                {
                    toPrint += " _ ";
                }
            }

            toPrint += "\n";
        }

        toPrint += "~~~~ BACK ~~~~";

        display.text = toPrint;
    }

}
