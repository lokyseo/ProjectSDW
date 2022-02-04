using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObjects : MonoBehaviour
{

    

    void Start ()
    {
		Generate._createMap = false;

    }

    void Update ()
    {
		if (!PlayerMove.dead)
        {
			transform.Translate(0, 0, -Generate._mapSpeed * Time.deltaTime);
		}
       
       if(this.transform.position.z < -250)
       {
           if(this.transform.tag == "background")
           {
                Generate._createMap = true;
                Destroy(this.gameObject);
           }
       }
	}
}
