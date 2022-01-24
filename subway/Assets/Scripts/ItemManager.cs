using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject _star;
    public GameObject _superJump;
    public Transform[] _itempoint;
    GameObject item;
    int randpt;
    int spawnPercent;

    void Start()
    {
        spawnPercent = Random.Range(0, 4);
        if (spawnPercent == 0 || spawnPercent == 1)
        {
        }
        else if (spawnPercent == 2)
        {
            randpt = Random.Range(0, _itempoint.Length);
            item = Instantiate(_star, _itempoint[randpt].position, Quaternion.identity);
        }
        else if (spawnPercent == 3)
        {
            randpt = Random.Range(0, _itempoint.Length);
            item = Instantiate(_superJump, _itempoint[randpt].position, Quaternion.identity);
        }

    }

    void Update()
    {
        if (spawnPercent == 0 || spawnPercent == 1)
        {
        }
        else if (spawnPercent == 2)
        {
            item.transform.position = _itempoint[randpt].position;
            item.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
        else if (spawnPercent == 3)
        {
            item.transform.position = _itempoint[randpt].position;
            item.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }

    }
}
