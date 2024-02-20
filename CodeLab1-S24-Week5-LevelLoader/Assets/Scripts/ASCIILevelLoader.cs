using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    int currentLevel;

    string FILE_PATH;
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + "/Levels/Level1.txt";
        
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        //Get the lines from the file
        string[] lines = File.ReadAllLines(FILE_PATH);

        for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
        {

            Debug.Log(lines[yLevelPos]);

            //Get a single line
            string line = lines[yLevelPos].ToUpper();

            //Turn line into a char array
            char[] characters = line.ToCharArray();

            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {

                //get the first character
                char c = characters[xLevelPos];

                Debug.Log(c);

                //if the character is a 'W'
                if (c == 'W')
                {
                    //Add a wall to our scene
                    GameObject newWall =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
                    newWall.transform.position = new Vector3(xLevelPos, -yLevelPos, 0);
                }
            }
        }
    }
}
