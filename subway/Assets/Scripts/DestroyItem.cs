using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{

    void Update()
    {
        if(this.transform.position.z < -100)
        {
            Destroy(this.gameObject);
        }
    }
}
