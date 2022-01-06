using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance()
    {
        return instance;
    }
    private static PlayerMove instance = null;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public static bool dead;
    //public static int score;
    private Rigidbody myRigid;
    public Animator anim;
    private bool isJumping;
    private float moveSpeed = 5.0f;
    private int ptXchar;
    private Vector3 target;
    private bool isLeft;
    private bool isRight;

    private void Start()
    {
        myRigid = this.transform.GetComponent<Rigidbody>();
        anim = this.GetComponentInChildren<Animator>();
        isJumping = false;
        isLeft = false;
        isRight = false;
        ptXchar = 0;
    }

    private void Update()
    {
        myRigid.AddForce(Vector3.down * 0.5f, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isLeft == false)
            {
                if (ptXchar == 0 || ptXchar == 1)
                {
                    target = this.transform.position + new Vector3(-3.5f, 0, 0);
                    isLeft = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isRight == false)
            {

                if (ptXchar == 0 || ptXchar == -1)
                {
                    target = this.transform.position + new Vector3(3.5f, 0, 0);
                    isRight = true;
                }
            }
        }      
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isJumping == false)
            {
                isJumping = true;
                myRigid.AddForce(Vector3.up * 14.0f, ForceMode.Impulse);
                anim.CrossFade("Jumping", 0.1f);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigid.AddForce(Vector3.down * 10.0f, ForceMode.Impulse);
            anim.CrossFade("Rolling", 0.1f);
        }

        if (isLeft)
        {
            if (ptXchar == 0)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(target, this.transform.position) <= 0.5f)
                {
                    ptXchar--;
                    isLeft = false;
                    Debug.Log("asdasdad");

                }
            }
            else if (ptXchar == 1)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(target, transform.position) <= 0.5f)
                {
                    ptXchar--;
                    isLeft = false;
                    Debug.Log("asdasdad");

                }
            }
            else
            {
                isLeft = false;

            }

        }
        else if (isRight)
        {
            if (ptXchar == 0)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(target, this.transform.position) <= 0.5f)
                {
                    ptXchar++;
                    isRight = false;
                    Debug.Log("asdasdad");
                }

            }
            else if (ptXchar == -1)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(target, this.transform.position) <= 0.5f)
                {
                    ptXchar++;
                    isRight = false;
                    Debug.Log("asdasdad");

                }

            }
            else
            {
                isRight = false;

            }


        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isJumping = false;
            
        }
    }
}
