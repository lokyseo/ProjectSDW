using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObjects : MonoBehaviour
{
    private float moveSpeed;
    private float addSpeed;
    private float speedTimer;


    void Start ()
    {
		moveSpeed = 10.0f;
		addSpeed = 0.5f;
		speedTimer = 0;

    }

    void Update ()
    {
		if (!PlayerMove.dead)
        {
			speedTimer += Time.deltaTime;
			if (speedTimer > 10)
			{
				speedTimer = 0;
				moveSpeed += addSpeed;
				Debug.Log("increased");
                
            }
			transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
		}
       
	}
}
