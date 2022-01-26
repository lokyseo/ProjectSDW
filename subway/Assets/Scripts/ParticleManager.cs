using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject _particleObject;
    ParticleSystem _particle;
    public Transform particleLocate;

    void Start()
    {
        _particle = _particleObject.GetComponent<ParticleSystem>(); 
    }
    

    void HitEffect()
    {
        Instantiate(_particle, particleLocate.position, Quaternion.identity);
    }
}
