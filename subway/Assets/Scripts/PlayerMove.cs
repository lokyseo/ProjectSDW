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
    private Collider mycoll;
    public Animator anim;
    private bool isJumping;
    private float moveSpeed = 5.0f;
    public Transform leftpt;
    public Transform rightpt;

    private void Start()
    {
        myRigid = this.transform.GetComponent<Rigidbody>();
        anim = this.GetComponentInChildren<Animator>();
        mycoll = this.GetComponent<BoxCollider>();
        isJumping = false;

    }

    private void Update()
    {
        myRigid.AddForce(Vector3.down * 0.1f, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigid.transform.position += Vector3.MoveTowards(gameObject.transform.position, leftpt.position, 0.5f);
            //myRigid.velocity = Vector3.zero;
            //myRigid.AddForce(Vector3.left * 10.0f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigid.transform.Translate(3.5f, 0, 0);

            //myRigid.velocity = Vector3.zero;
            //myRigid.AddForce(Vector3.left * -10.0f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isJumping == false)
            {
                isJumping = true;
                myRigid.velocity = Vector3.zero;
                myRigid.AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
                anim.CrossFade("Jumping", 0.1f);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigid.velocity = Vector3.zero;
            myRigid.AddForce(Vector3.down * 12.0f, ForceMode.Impulse);
            anim.CrossFade("Rolling", 0.1f);
            
           
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
