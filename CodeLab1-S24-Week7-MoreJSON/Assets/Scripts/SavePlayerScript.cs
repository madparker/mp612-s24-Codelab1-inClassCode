using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class SavePlayerScript : MonoBehaviour
{
    [TextArea (5, 20)] public string json ;
    // DEMO ( Array of Objects ) 
    /* 
       [
          { "name":"Matt", "age":25 },
          { "name":"Wylie", "age":7 },
          { "name":"Tuna", "age":4 }
       ]
    */
    
    [TextArea (5, 20)] public string simpleObjectJson ;
    // DEMO ( Simple Objects ) 
    /*
        {
            "pos":
            {
                "x":1,
                "y":2,
                "z":3,
            },
            "rot":
            {
                "x":90,
                "y":45,
                "z":0
            }
        }
    */
    
    // Start is called before the first frame update
    void Start()
    {
        SimpleObjectParsing();
        ArrayOfObjectsParsing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void ArrayOfObjectsParsing () {
        JSONNode node = JSON.Parse (json) ;
      
        JSONArray allPersons = node.AsArray ;

        foreach (JSONObject person in allPersons) {
            Debug.Log ("-------------------------") ;  
            Debug.Log (person [ "name" ].Value) ;  
            Debug.Log (person [ "age" ].AsInt) ;  
        }
        
        Debug.Log(allPersons.ToString());
    }

    public void SimpleObjectParsing()
    {
        //Turn the JSON into a node (transform)
        JSONNode transformNode = JSON.Parse(simpleObjectJson);

        //Get the "pos" node from the the parent node (transform)
        JSONNode postionNode = transformNode["pos"];
        
        //Turn the positionNode into a JSON Obj, so we can get values
        JSONObject positionObject = postionNode.AsObject;

        Vector3 jsonPos = new Vector3();

        //Get the x, y, and z values out of the JSONObject position
        jsonPos.x = positionObject["x"].AsInt;
        jsonPos.y = positionObject["y"].AsInt;
        jsonPos.z = positionObject["z"].AsInt;

        transform.position = jsonPos;

        Debug.Log(positionObject.ToString());
    }
}
