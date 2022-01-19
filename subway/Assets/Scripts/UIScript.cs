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

    // 상점
    public static int _countBoard;
    public static int _upgradeSuperJump;
    public static int _upgradeStar;

    public Text txtcountBoard;
    public Text uicountBoard;

    public Text txtupSuperJump;
    public Text txtupStar;

    public Text txtTimeSuperJump;
    public Text txtTimeStar;

    public Text priceSuperjump;
    public Text priceStar;


    void Start()
    {
		_money = PlayerPrefs.GetInt(_txtMoney, 0);
		_textMoney.text = $" : {_money.ToString()}";

		_bestscore = PlayerPrefs.GetInt(_txtBestscore, 0);
		_textBest.text = $"Best Score : {_bestscore.ToString()}";

        priceSuperjump.text = "1000";
        priceStar.text = "1200";
        txtcountBoard.text = " X " + _countBoard;

        _curscore = 0;

        _canvasShop.SetActive(false);
        _countBoard = 0;
        _upgradeSuperJump = 0;
        _upgradeStar = 0;
        
    }

    void Update()
    {
        _textMoney.text = $" : {_money.ToString()}";
        PlayerPrefs.SetInt(_txtMoney, _money);

        uicountBoard.text = " X " + _countBoard;
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

    public void Purchase_Board()
    {
        _countBoard++;
        _money -= 1000;

        txtcountBoard.text = " X " + _countBoard;
    }

    public void Upgrade_SuperJump()
    {
        int upgradeCount = 6;
        if (upgradeCount <= _upgradeSuperJump) return;
        _money -= 1000 + (500 * _upgradeSuperJump);
        _upgradeSuperJump++;
        int price = 1000 + (500 * _upgradeSuperJump);
        //txt
        priceSuperjump.text = "" + price;
        txtTimeSuperJump.text = (10 + _upgradeSuperJump * 2) + "/s";
        txtupSuperJump.text = _upgradeSuperJump + " / 6";
    }

    public void Upgrade_Star()
    {
        int upgradeCount = 6;
        if (upgradeCount <= _upgradeStar) return;
        _money -= 1200 + 600 * _upgradeStar;
        _upgradeStar++;
        int price = 1200 + 600 * _upgradeStar;

        priceStar.text = "" + price;
        txtTimeStar.text = (10 + _upgradeStar * 2) + "/s";
        txtupStar.text = _upgradeStar + " / 6";
    }

    public void Purchase_Mystery()
    {

    }
}
