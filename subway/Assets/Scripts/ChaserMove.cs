using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMove : MonoBehaviour
{
    public GameObject _player;
    private float chaseTime;
    public bool ischase;

    public Animator anim;

    private bool moveStop;

    void Start()
    {
        chaseTime = 5.0f;
        ischase = true;
        anim = this.GetComponentInChildren<Animator>();
        moveStop = false;

    }

    void Update()
    {
        if (moveStop) return;

        if(PlayerMove.againcollision)
        {
            PlayerMove._ischasing = true;
        }

        if(PlayerMove._ischasing)
        {
            Vector3 target = _player.transform.position + new Vector3(0, 0, -2);

            this.transform.position =
               Vector3.MoveTowards(this.transform.position, target, 2 * Time.deltaTime);

            chaseTime -= Time.deltaTime;

            if(PlayerMove._isleftDead)
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y, -4);
                anim.CrossFade("Attack", 0);
                moveStop = true;
            }

            if(chaseTime <= 0.0f)
            {
                PlayerMove._ischasing = false;
                PlayerMove.againcollision = false;
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
