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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
    }
}
