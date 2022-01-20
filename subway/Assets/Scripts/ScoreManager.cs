using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text _money;

    public Text _score;
    private float scoreTimer;

    public Text _board;

    //슬라이더
    public GameObject bslider;
    Slider slTimer;

    void Start()
    {
        _money.text = " : " + UIScript._money;

        _score.text = "Score : " + UIScript._curscore;
        scoreTimer = 0;

        _board.text = "X " + UIScript._countBoard;

        slTimer = bslider.GetComponent<Slider>();
        bslider.SetActive(false);
    }

    void Update()
    {

        _money.text = " : " + UIScript._money;

        if (PlayerMove.isBoarding)
        {
            bslider.SetActive(true);
            _board.text = "<color=green>X " + UIScript._countBoard + "</color>"; 
            slTimer.value -= Time.deltaTime;
         
        }
        else
        {
            _board.text = "X " + UIScript._countBoard;
            bslider.SetActive(false);
            slTimer.value = 30.0f;

        }

        if (PlayerMove.isStar)
        {
            _score.text = "<color=yellow>Score X2 : " + UIScript._curscore + "</color>";
        }
        else
        {
            _score.text = "Score : " + UIScript._curscore;
        }

        if (!PlayerMove.dead)
        {
            scoreTimer += Time.deltaTime;
            if (scoreTimer > 2)
            {
                scoreTimer = 0;
                if (PlayerMove.isStar)
                {
                    UIScript._curscore += 100;
                }
                else
                {
                    UIScript._curscore += 50;
                }

                if (UIScript._curscore > UIScript._bestscore)
                {
                    PlayerPrefs.SetInt(UIScript._txtBestscore, UIScript._curscore);
                }
            }
        }

    }
}
    
   
