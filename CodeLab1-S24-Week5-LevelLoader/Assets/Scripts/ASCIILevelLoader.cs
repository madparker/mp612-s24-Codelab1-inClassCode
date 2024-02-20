using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    int currentLevel = 0;

    string FILE_PATH;
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        //Get the lines from the file
        string[] lines = File.ReadAllLines(
            FILE_PATH.Replace("Num", currentLevel + ""));

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

                GameObject newObject = null;

                switch (c)
                {
                    case 'W': //if the character is a 'W'
                        newObject = //Add a wall to our scene
                            Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
                        break;
                    case 'P': //if the character is a 'P'
                        newObject = //Add a player to our scene
                            Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                        //align the camera with the player
                        Camera.main.transform.parent = newObject.transform;
                        Camera.main.transform.position = new Vector3(0, 0, -10);
                        break;
                    case 'S':
                        newObject = //If the character is an 'S'
                            Instantiate(Resources.Load<GameObject>("Prefabs/Spike"));
                        break;
                    default:
                        break;
                }

                if (newObject != null)
                {
                    //Give it a position based on where it was in the ASCII file
                    newObject.transform.position = new Vector2(xLevelPos, -yLevelPos);
                }
            }
        }
    }
}
