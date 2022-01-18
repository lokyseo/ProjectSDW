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

	public static int _money;
	public static string _txtMoney = "Money";

	public static int _bestscore;
	public static int _curscore;
	public static string _txtBestscore = "Best";

	private void Awake()
	{
		if (instance)
		{
			Destroy(gameObject);
			return;
		}
		instance = this;
	}

	public Text _textMoney;
	public Text _textBest;

    public GameObject _canvasStart;
    public GameObject _canvasShop;

	void Start()
    {
		_money = PlayerPrefs.GetInt(_txtMoney, 0);
		_textMoney.text = $" : {_money.ToString()}";

		_bestscore = PlayerPrefs.GetInt(_txtBestscore, 0);
		_textBest.text = $"Best Score : {_bestscore.ToString()}";

		_curscore = 0;

        _canvasShop.SetActive(false);
	}

    public void OnClick_Shop()
    {
        _canvasStart.SetActive(false);
        _canvasShop.SetActive(true);
    }

    public void OnClick_CloseShop()
    {
        _canvasStart.SetActive(true);
        _canvasShop.SetActive(false);
    }
}
