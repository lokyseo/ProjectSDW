using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TabToStart : MonoBehaviour
{
    

    public GameObject _text;
    public Animator playeranim;
    public GameObject _player;
    public GameObject _chaser;
    private float rotateSpeed = 5.0f;
    private float moveSpeed = 6.0f;
    private bool IsRotate;
    private bool IsClicked;
    public GameObject buttonImage;
    Image _imageColor;

    public GameObject shopBtn;

    void Start()
    {
        _imageColor = buttonImage.GetComponent<Image>();
        IsRotate = false;
        IsClicked = false;
        _text.SetActive(false);
        playeranim = playeranim.GetComponent<Animator>();
        StartCoroutine(BlinkText());
    }

    void Update()
    {
        if (playeranim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Reacting") &&
           playeranim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            IsRotate = true;
        }
        if (IsRotate)
        {
            _player.transform.rotation =
                Quaternion.Slerp(_player.transform.rotation, Quaternion.identity, rotateSpeed * Time.deltaTime);
            _player.transform.position =
                Vector3.MoveTowards(_player.transform.position, new Vector3(0, 0, 50), moveSpeed * Time.deltaTime);
            _chaser.transform.position =
                Vector3.MoveTowards(_chaser.transform.position, new Vector3(0, 0, 50), moveSpeed * Time.deltaTime);
        }

        if (_chaser.transform.position.z >= 37.0f)
        {
            Debug.Log("anfaiogap");
            Color color = _imageColor.color;
            color.a += 0.02f;
            _imageColor.color = color;
            if(color.a >= 0.9f)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public IEnumerator BlinkText() 
    {
        while (IsClicked == false)
        {
            _text.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _text.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnClick_TabStart()
    {
        IsClicked = true;
        _text.SetActive(false);
        playeranim.CrossFade("Reacting", 0.1f);

        shopBtn.SetActive(false);
    }

    
}
