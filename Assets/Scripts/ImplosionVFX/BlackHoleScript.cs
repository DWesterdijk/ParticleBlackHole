using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// -=============================================================-
/// -===This script is made by Duncan/Athena======================-
/// -===Feel free to use this and adjust/tweek stuff==============-
/// -===But please give credits to me for laying down the base====-
/// -=======================Thank you=============================-
/// -=============================================================-
/// 
/// This script will let an object function as a Particle magnet.
/// I will use this to create an implosion.
/// 
/// In order to make an implosion all the particles would have to be attracted and "sucked" inside of one point.
/// Increasing it's virtual mass while it remains in one size, thus the magnet becomes a black hole.
/// Once it's energy goes over it's capacity, it has to release all the energy into an explosion.
/// 
/// In order to make that happen in code I would need a few variables.
/// Mass, Capacity and Energy.
/// All three variables are a float.
/// 
/// I would also need to grab the Particle system it has to attract, 
/// I can place this in an particle system array if I want to attract different particles.
/// I would need a boolean(Named: Magnetic) that becomes true when the activate button is pressed.
/// Once activated the "black-hole" object becomes magnetic and starts the process of the black hole.
/// 
/// Further I would need a function, Attract, this functino will handle the magnet effect.
/// And I need a function, Explode, to cause the explosion once the energy exceeds the capacity.
/// 
/// -=============================================================-
/// -===Attatch this script to the================================-
/// -===blackHole/magnet object===================================-
/// -===and add the Particle system to it=========================-
/// -=============================================================-
/// </summary>
public class BlackHoleScript : MonoBehaviour {
    [Header("particle")]
    [SerializeField]
    private ParticleSystem _particleSys;
    private ParticleSystem.Particle[] _particles;

    private Vector3 _blackHolePos;
    
    private bool _magnetic;

    [Header("floats")]
    [SerializeField]
    private float _mass;
    [SerializeField]
    private float _capacity;
    [SerializeField]
    private float _energy;

    private int _livingParticles;

    private void Awake()
    {
        Init();
        _blackHolePos = new Vector3(this.transform.position.x, -this.transform.position.z, this.transform.position.y);
        _particleSys.GetParticles(_particles);

        _magnetic = false;
        _mass = 0;
        _capacity = 100;
        _energy = 0;
    }

	void Update ()
    {
        _livingParticles = _particleSys.GetParticles(_particles);
        _blackHolePos = new Vector3(this.transform.position.x, -this.transform.position.z, this.transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {        
            _magnetic = true;
            Debug.Log(_magnetic);
            _energy = 0f;
        }

        if (_energy >= _capacity)
        {
            Explode(_livingParticles);
            _magnetic = false;
        }

        Attract(_livingParticles);
	}

    private void Attract(int particleAmount)
    {
        if (_magnetic)
        {
            _energy += 0.1f;
            _mass += 0.00025f;
            for (int i = 0; i < particleAmount; i++)
            {
                _particles[i].position = Vector3.Lerp(_particles[i].position, _blackHolePos, _mass);
            }
            _particleSys.SetParticles(_particles, particleAmount);
        }
    }

    private void Explode(int particleAmount)
    {
        for (int i = 0; i < particleAmount; i++)
        {
            _particles[i].velocity *= 1.05f;
            if (_particles[i].velocity.magnitude >= 2000f)
            {
                _particles[i].velocity = new Vector3(0, 0, 0);
                break;
            }
        }
        _particleSys.SetParticles(_particles, particleAmount);
    }

    private void Init()
    {
        if (_particleSys == null)
        {
            _particleSys = GetComponent<ParticleSystem>();
        }
        if (_particles == null || _particles.Length < _particleSys.main.maxParticles)
        {
            _particles = new ParticleSystem.Particle[_particleSys.main.maxParticles];
        }
    }
}
