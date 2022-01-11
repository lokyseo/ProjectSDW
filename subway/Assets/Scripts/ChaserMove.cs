using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMove : MonoBehaviour
{
    public GameObject _player;
    private float chaseTime;
    public bool ischase;

    void Start()
    {
        chaseTime = 5.0f;
        ischase = true;
    }

    void Update()
    {
        if(ischase)
        {
            chaseTime -= Time.deltaTime;
            if(chaseTime <= 0.0f)
            {
                ischase = false;
                chaseTime = 5.0f;
            }
        }
        else
        {
            Vector3 target = _player.transform.position + new Vector3(0, 0, -5);

            this.transform.position =
               Vector3.MoveTowards(this.transform.position, target, Time.deltaTime);
        }
    }
}
