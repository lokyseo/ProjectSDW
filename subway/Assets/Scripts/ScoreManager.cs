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

		_score.text = "Score : " + PlayerMove.score;
		scoreTimer = 0;
	}

	void Update()
	{
		_score.text = "Score : " + PlayerMove.score;
		_money.text = " : " + UIScript._money;

		if (!PlayerMove.dead)
		{
			scoreTimer += Time.deltaTime;
			if (scoreTimer > 2)
			{
				scoreTimer = 0;
				PlayerMove.score += 50;
			}
		}

	}
	
}
