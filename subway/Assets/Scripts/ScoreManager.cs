using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public Text _money;

	public Text _score;
	private float scoreTimer;
	
	void Start()
	{
		_money.text = " : " + UIScript._money;

		_score.text = "Score : " + UIScript._curscore;
		scoreTimer = 0;
	}

	void Update()
	{
		_score.text = "Score : " + UIScript._curscore;
		_money.text = " : " + UIScript._money;

		if (!PlayerMove.dead)
		{
			scoreTimer += Time.deltaTime;
			if (scoreTimer > 2)
			{
				scoreTimer = 0;
                if(PlayerMove.isStar)
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
