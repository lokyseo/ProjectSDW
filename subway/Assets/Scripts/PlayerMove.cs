﻿using System.Collections;
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
    private bool isBoarding;

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
        isBoarding = false;
        ptXchar = 0;
    }

    private void Update()
    {
        if (PlayerMove.dead) return;
            myRigid.AddForce(Vector3.down * 0.3f, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isLeft == false && isRolling == false)
            {
                if (ptXchar == 0)
                {
                    target = new Vector3(-3.5f, this.transform.position.y, this.transform.position.z);
                    if(isBoarding == true)
                    {
                        anim.CrossFade("Boardshorting", 0.1f);

                    }
                    else
                    {
                        anim.CrossFade("shortJump", 0.1f);
                    }
                    isLeft = true;
                }
                else if(ptXchar == 1)
                {
                    target = new Vector3(0, this.transform.position.y, this.transform.position.z);
                    if (isBoarding == true)
                    {
                        anim.CrossFade("Boardshorting", 0.1f);


                    }
                    else
                    {
                        anim.CrossFade("shortJump", 0.1f);
                    }
                    isLeft = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isRight == false && isRolling == false && isLeft == false)
            {

                if (ptXchar == 0)
                {
                    target = new Vector3(3.5f, this.transform.position.y, this.transform.position.z);
                    if (isBoarding == true)
                    {
                        anim.CrossFade("Boardshorting", 0.1f);


                    }
                    else
                    {
                        anim.CrossFade("shortJump", 0.1f);
                    }
                    isRight = true;
                }
                else if(ptXchar == -1)
                {
                    target = new Vector3(0, this.transform.position.y, this.transform.position.z);
                    if (isBoarding == true)
                    {
                        anim.CrossFade("Boardshorting", 0.1f);

                    }
                    else
                    {
                        anim.CrossFade("shortJump", 0.1f);
                    }
                    isRight = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isJumping == false)
            {
                isJumping = true;
                isRolling = false;
                mycoll.size = new Vector3(0.5f, 2.2f, 1.0f);
                mycoll.center = new Vector3(0, 1.1f, 0);
                myRigid.AddForce(Vector3.up * 18.0f, ForceMode.Impulse);
                if (isBoarding == true)
                {
                    anim.CrossFade("BoardJumping", 0.1f);
                }
                else
                {
                    anim.CrossFade("Jumping", 0.1f);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isRolling = true;
            mycoll.size = new Vector3(0.5f, 1.0f, 1.0f);
            mycoll.center = new Vector3(0, 0.5f, 0);
            myRigid.AddForce(Vector3.down * 15.0f, ForceMode.Impulse);
            if(isBoarding == true)
            {
                anim.CrossFade("BoardRoll", 0.1f);
                
            }
            else
            {
                anim.CrossFade("Rolling", 0.1f);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.CrossFade("Boarding", 0);
            isBoarding = true;
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

                }
            }
            else if (ptXchar == 1)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(new Vector3(target.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) <= 0.5f)
                {
                    ptXchar--;
                    isLeft = false;
                    
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
                }

            }
            else if (ptXchar == -1)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, target, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(new Vector3(target.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) <= 0.5f)
                {
                    ptXchar++;
                    isRight = false;
                }
            }
            else
            {
                isRight = false;
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Rolling") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
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

        if(collision.gameObject.layer == 14)
        {
            if(isLeft)
            {
                anim.CrossFade("leftHit", 0.0f);
                isLeft = false;
                if(ptXchar == 0)
                {
                    
                    this.transform.position = 
                       Vector3.Lerp(transform.position, new Vector3(3.5f, 0, 0), moveSpeed * Time.deltaTime);
                }
                else if(ptXchar == -1)
                {
                    this.transform.position =
                       Vector3.Lerp(transform.position, new Vector3(0, 0, 0), moveSpeed * Time.deltaTime);
                }
            }
            if (isRight)
            {
                anim.CrossFade("rightHit", 0.0f);
                

                isRight = false;
                if (ptXchar == 1)
                {
                    this.transform.position =
                       Vector3.Lerp(transform.position, new Vector3(0, 0, 0), moveSpeed * Time.deltaTime);
                }
                else if (ptXchar == 0)
                {
                    this.transform.position =
                       Vector3.Lerp(transform.position, new Vector3(-3.5f, 0, 0), moveSpeed * Time.deltaTime);
                }
            }

        }

        if(collision.gameObject.layer == 12)
        {
            anim.CrossFade("BackDeath", 0.1f);
            dead = true;
        }
        else if (collision.gameObject.layer == 13)
        {
            anim.CrossFade("Fall Flat", 0.1f);
            
            dead = true;

        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            UIScript._curscore += 10;
            UIScript._money += 10;
            PlayerPrefs.SetInt(UIScript._txtMoney, UIScript._money);
            if(UIScript._curscore > UIScript._bestscore)
            {
                PlayerPrefs.SetInt(UIScript._txtBestscore, UIScript._curscore);
            }
            Destroy(other.gameObject);
        }
    }


}
