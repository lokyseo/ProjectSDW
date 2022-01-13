using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{    
	public static UIScript Instance()
	{
		return instance;
	}
	private static UIScript instance = null;

	private void Awake()
	{
		if (instance)
		{
			Destroy(gameObject);
			return;
		}
		instance = this;
	}

	public static int _money;

	public Text _textMoney;
	void Start()
    {
		_money = 100;
		_textMoney.text = "" + _money;
	}

    void Update()
    {
		_textMoney.text = "" + _money;

	}
}
