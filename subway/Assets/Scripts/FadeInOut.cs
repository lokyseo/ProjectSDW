using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public GameObject _panel;
    Image _image;

    void Start()
    {
        _image = _panel.GetComponent<Image>();
    }

    void Update()
    {
        Color color = _image.color;
        color.a -= 0.02f;
        _image.color = color;
    }
}
