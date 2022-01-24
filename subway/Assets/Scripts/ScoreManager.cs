using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text _money;

    public Text _score;
    private float scoreTimer;

    public Text _board;

    //슬라이더
    public GameObject bslider;
    Slider slTimer;

    public GameObject SuperSlider;
    Slider superTime;
    public GameObject ItemUI;

    //사망 후
    public GameObject died;
    public Text bestS;
    public Text curS;

    void Start()
    {
        _money.text = " : " + UIScript._money;

        _score.text = "Score : " + UIScript._curscore;
        scoreTimer = 0;

        _board.text = "X " + UIScript._countBoard;

        slTimer = bslider.GetComponent<Slider>();
        superTime = SuperSlider.GetComponent<Slider>();
        superTime.value = 10 + UIScript._upgradeSuperJump * 2;
        ItemUI.SetActive(false);
        bslider.SetActive(false);
        died.SetActive(false);
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

        if(PlayerMove.isSuper)
        {
            ItemUI.SetActive(true);
            superTime.value -= Time.deltaTime;
        }
        else
        {
            ItemUI.SetActive(false);
            superTime.value = 10 + UIScript._upgradeSuperJump * 2;

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
                    UIScript._bestscore = UIScript._curscore;
                }
            }
        }
        else
        {
            Invoke("callDieCanvas", 2.0f);
            bestS.text = "Best : " + UIScript._bestscore;
            curS.text = "Score : " + UIScript._curscore;
        }

    }

    void callDieCanvas()
    {
        died.SetActive(true);
    }

    public void OnClick_Retry()
    {
        SceneManager.LoadScene("SampleScene");
        UIScript._curscore = 0;
    }

    public void OnClick_Title()
    {
        SceneManager.LoadScene("Start");
    }
}
