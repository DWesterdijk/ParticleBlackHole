using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnParticleDeath : MonoBehaviour {

    public GameObject gameObjectBlock;

    public ParticleSystem.Particle[] particles;

    public ParticleSystem particleSys;

	void Update () {
        int aliveParticles = particleSys.GetParticles(particles);
        float aliveTime = 5f;

            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].position = new Vector3(particles[i].position.x, particles[i].position.y, particles[i].position.z);
                Debug.Log("test" + i);
                
            }
        Instantiate(gameObjectBlock);
        particleSys.SetParticles(particles, aliveParticles);
	}
}
