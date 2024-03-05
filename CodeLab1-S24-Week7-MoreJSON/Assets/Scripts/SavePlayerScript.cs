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
            "x":1,
            "y":2,
            "z":3,
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
        JSONNode node = JSON.Parse(simpleObjectJson) ;
        JSONObject position = node.AsObject ;

        Vector3 jsonPos = new Vector3();

        jsonPos.x = position["x"].AsInt;
        jsonPos.y = position["y"].AsInt;
        jsonPos.z = position["z"].AsInt;

        transform.position = jsonPos;

        Debug.Log(position.ToString());
    }
}
