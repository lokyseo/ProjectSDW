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

    public static int _countBoard;
    public static int _upgradeSuperJump;
    public static int _upgradeStar;

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
    public Text txtcountBoard;
    public Text uicountBoard;

    public Text txtupSuperJump;
    public Text txtupStar;

    public Text txtTimeSuperJump;
    public Text txtTimeStar;

    public Text priceSuperjump;
    public Text priceStar;
    int superPrice;
    int starPrice;

    //사운드
    public AudioSource s_purchase;
    public AudioSource s_shopBgm;
    public AudioSource s_startBgm;
    public AudioSource s_hitSound;

    void Start()
    {
		_money = PlayerPrefs.GetInt(_txtMoney, 0);
		_textMoney.text = $" : {_money.ToString()}";

		_bestscore = PlayerPrefs.GetInt(_txtBestscore, 0);
		_textBest.text = $"Best Score : {_bestscore.ToString()}";

        superPrice = 1000 + (500 * _upgradeSuperJump);
        priceSuperjump.text = "" + superPrice;
        txtTimeSuperJump.text = (10 + _upgradeSuperJump * 2) + "/s";
        txtupSuperJump.text = _upgradeSuperJump + " / 6";

        starPrice = 1200 + 600 * _upgradeStar;
        priceStar.text = "" + starPrice;
        txtcountBoard.text = " X " + _countBoard;
        txtTimeStar.text = (10 + _upgradeStar * 2) + "/s";
        txtupStar.text = _upgradeStar + " / 6";
        _curscore = 0;

        _canvasShop.SetActive(false);
        _money += 10000;

        s_shopBgm.playOnAwake = false;
        s_startBgm.playOnAwake = true;
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
        s_startBgm.Stop();
        s_shopBgm.Play();
        s_hitSound.mute = true;
    }

    public void OnClick_CloseShop()
    {
        _canvasStart.SetActive(true);
        _canvasShop.SetActive(false);
        s_startBgm.Play();
        s_shopBgm.Stop();
        s_hitSound.mute = false;
    }

    public void Purchase_Board()
    {
        s_purchase.Play();

        _countBoard++;
        _money -= 1000;

        txtcountBoard.text = " X " + _countBoard;
    }

    public void Upgrade_SuperJump()
    {
        s_purchase.Play();

        int upgradeCount = 6;
        if (upgradeCount <= _upgradeSuperJump) return;
        _money -= 1000 + (500 * _upgradeSuperJump);
        _upgradeSuperJump++;
        superPrice = 1000 + (500 * _upgradeSuperJump);
        //txt
        priceSuperjump.text = "" + superPrice;
        txtTimeSuperJump.text = (10 + _upgradeSuperJump * 2) + "/s";
        txtupSuperJump.text = _upgradeSuperJump + " / 6";
    }

    public void Upgrade_Star()
    {
        s_purchase.Play();

        int upgradeCount = 6;
        if (upgradeCount <= _upgradeStar) return;
        _money -= 1200 + 600 * _upgradeStar;
        _upgradeStar++;
        starPrice = 1200 + 600 * _upgradeStar;

        priceStar.text = "" + starPrice;
        txtTimeStar.text = (10 + _upgradeStar * 2) + "/s";
        txtupStar.text = _upgradeStar + " / 6";
    }

    public void Purchase_Mystery()
    {
        s_purchase.Play();

        int rand = Random.Range(0, 5);

        _money -= 500;

        if(rand == 0)
        {

        }
        else if(rand == 1)
        {
            _money += 500;
        }
        else if (rand == 2)
        {
            _money += 1000;
        }
        else if (rand == 3)
        {
            _countBoard++;

        }
        else if (rand == 4)
        {
            _countBoard += 2;
        }
    }
}
