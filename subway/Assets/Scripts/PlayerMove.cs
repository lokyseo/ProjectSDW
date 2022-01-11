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
    public static int score;
    private Rigidbody myRigid;
    public Animator anim;
    private BoxCollider mycoll;    
    private float moveSpeed = 5.0f;
    private int ptXchar;
    private Vector3 target;
    private bool isLeft;
    private bool isRight;
    private bool isJumping;
    private bool isRolling;

    private void Start()
    {
        dead = false;
        myRigid = this.transform.GetComponent<Rigidbody>();
        anim = this.GetComponentInChildren<Animator>();
        mycoll = this.GetComponent<BoxCollider>();
        isJumping = false;
        isLeft = false;
        isRight = false;
        isRolling = false;
        ptXchar = 0;
    }

    private void Update()
    {
        myRigid.AddForce(Vector3.down * 0.3f, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isLeft == false || isRolling == false)
            {
                if (ptXchar == 0 || ptXchar == 1)
                {
                    target = this.transform.position + new Vector3(-3.5f, 0, 0);
                    anim.CrossFade("shortJump", 0.1f);
                    isLeft = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isRight == false || isRolling == false)
            {

                if (ptXchar == 0 || ptXchar == -1)
                {
                    target = this.transform.position + new Vector3(3.5f, 0, 0);
                    anim.CrossFade("shortJump", 0.1f);
                    isRight = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isJumping == false)
            {
                isJumping = true;
                myRigid.AddForce(Vector3.up * 16.0f, ForceMode.Impulse);
                anim.CrossFade("Jumping", 0.1f);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isRolling = true;
            mycoll.size = new Vector3(0.5f, 1.0f, 1.0f);
            mycoll.center = new Vector3(0, 0.5f, 0);
            myRigid.AddForce(Vector3.down * 15.0f, ForceMode.Impulse);
            anim.CrossFade("Rolling", 0.1f);
        }

        if (isLeft)
        {
            if (ptXchar == 0)
            {
                this.transform.position =
                    Vector3.Lerp(this.transform.position, target, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(new Vector3(target.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) <= 0.5f)
                {
                    ptXchar--;
                    isLeft = false;
                    Debug.Log("asdasdad");

                }
            }
            else if (ptXchar == 1)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(new Vector3(target.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) <= 0.5f)
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
                if (Vector3.Distance(new Vector3(target.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) <= 0.5f)
                {
                    ptXchar++;
                    isRight = false;
                    Debug.Log("asdasdad");
                }

            }
            else if (ptXchar == -1)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(new Vector3(target.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) <= 0.5f)
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

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Rolling") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            isRolling = false;
            mycoll.size = new Vector3(0.5f, 2.2f, 1.0f);
            mycoll.center = new Vector3(0, 1.1f, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isJumping = false;
        }

        if(collision.gameObject.layer == 12)
        {
            anim.CrossFade("BackDeath", 0.1f);
            dead = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            score += 10;
            Destroy(other.gameObject);
        }
    }


}
