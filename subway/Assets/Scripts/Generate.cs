using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generate : MonoBehaviour {


	public Transform[] premades;
	int rand;
    //스피드 
    public static float _mapSpeed;
    private float speedTimer;

    public static bool _createMap;

    void Start()
    {
        _mapSpeed = 10.0f;
        speedTimer = 5.0f;
		for (int iz = 0; iz < 5; iz++)
        {
			rand = Random.Range(0, premades.Length);
            Instantiate(premades[rand], new Vector3(0, 0, 0+140*iz - 20), Quaternion.identity);
		}
	}
	
	void Update ()
    {
        if (_createMap)
        {
            rand = Random.Range(0, premades.Length);
            Instantiate(premades[rand], new Vector3(0, 0, 445), Quaternion.identity);

            _createMap = false;

        }

        speedTimer -= Time.deltaTime;
        if(speedTimer < 0)
        {
            if(_mapSpeed < 25.0f)
            {
                _mapSpeed += 0.5f;
                Debug.Log(_mapSpeed);
            }
            speedTimer = 3.0f;
        }
      
    }
}
