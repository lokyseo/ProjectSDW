using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generate : MonoBehaviour {

	public Vector3 startingPt;
	public Transform[] premades;
	public Transform background;
	public List<Transform> currentPremades;
	int rand;
    int co;


	void Start()
    {
		currentPremades = new List<Transform>();
		for (int iz = 0; iz < 10; iz++)
        {
			rand = Random.Range(0, premades.Length);
            currentPremades.Add((Transform)Instantiate
                (premades[rand], new Vector3(startingPt.x, startingPt.y, startingPt.z+140*iz+40), Quaternion.identity) as Transform);
            Instantiate(premades[rand], new Vector3(startingPt.x, startingPt.y, startingPt.z+140*iz+40), Quaternion.identity);
            Instantiate(background, new Vector3(startingPt.x, startingPt.y, startingPt.z+140*iz-10), Quaternion.identity);
		}
        co = 0;
	}
	
	void Update ()
    {
		if (currentPremades[co].position.z < -120)
        {
			Destroy((currentPremades[co] as Transform).gameObject);
			currentPremades.RemoveAt(0);
			rand = Random.Range (0, premades.Length);
			Debug.Log(premades.Length);
			Debug.Log(currentPremades.Capacity-1);
			//currentPremades.Add((Transform)Instantiate
            //    (premades [rand], new Vector3(startingPt.x, startingPt.y, currentPremades[currentPremades.Capacity - 1].position.z+140), Quaternion.identity) as Transform);
			//Instantiate(background, new Vector3(startingPt.x, startingPt.y, currentPremades[currentPremades.Capacity - 1].position.z+140), Quaternion.identity);
		}
	}
}
