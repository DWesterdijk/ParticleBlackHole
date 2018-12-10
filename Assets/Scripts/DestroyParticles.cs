using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour {

    [SerializeField]
    private ParticleSystem _pSys;
    ParticleSystem.Particle[] _pArray;
    private int livingParticles;

	// Use this for initialization
	void Start () {
        Init();
	}

    private void Update()
    {
        livingParticles = _pSys.GetParticles(_pArray);
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < livingParticles; i++)
        if (other.Equals(_pArray[i]))
        {
            _pArray[i].remainingLifetime = 0;
        }
    }

    private void Init()
    {
        if (_pSys == null)
        {
            _pSys = GetComponent<ParticleSystem>();
        }
        if (_pArray == null || _pArray.Length < _pSys.main.maxParticles)
        {
            _pArray = new ParticleSystem.Particle[_pSys.main.maxParticles];
        }
    }
}
