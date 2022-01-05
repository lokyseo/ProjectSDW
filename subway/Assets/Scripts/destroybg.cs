using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybg : MonoBehaviour
{
    public GameObject bg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Destroy(this);
            Destroy(bg);
        }
    }
}
