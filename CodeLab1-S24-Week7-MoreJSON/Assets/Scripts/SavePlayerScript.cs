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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JSONNode transformNode = new JSONObject();
            
            JSONObject posObj = new JSONObject();
            
            transformNode.Add("pos", posObj);
            
            posObj.Add("x", transform.position.x);
            posObj.Add("y", transform.position.y);
            posObj.Add("z", transform.position.z);
            
            //{
            //  "pos":
            //      {"x":0,
            //       "y":0,
            //       "z":0}
            // }
            Debug.Log(transformNode.ToString());
        }
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
        
        Debug.Log(allPersons[2].ToString());
    }

    public void SimpleObjectParsing()
    {
        //Turn the JSON into a node (transform)
        JSONNode transformNode = JSON.Parse(simpleObjectJson);

        //POSTION
        //Get the "pos" node from the the parent node (transform)
        JSONNode postionNode = transformNode["pos"];
        
        //Turn the positionNode into a JSON Obj, so we can get values
        JSONObject positionObject = postionNode.AsObject;

        Vector3 jsonPos = new Vector3();

        //Get the x, y, and z values out of the JSONObject position
        jsonPos.x = positionObject["x"].AsInt;
        jsonPos.y = positionObject["y"].AsInt;
        jsonPos.z = positionObject["z"].AsInt;

        //set the postion from the JSON
        transform.position = jsonPos;
        
        //ROTATION
        JSONNode rotationNode = transformNode["rot"];

        //Turn the rotationNode into a JSON Obj, so we can get values
        JSONObject rotationObject = rotationNode.AsObject;

        Vector3 jsonRot = new Vector3();

        jsonRot.x = rotationObject["x"].AsInt;
        jsonRot.y = rotationObject["y"].AsInt;
        jsonRot.z = rotationObject["z"].AsInt;
        
        //set the rotation from the JSON
        transform.Rotate(jsonRot);

        Debug.Log(positionObject.ToString());
    }
}
