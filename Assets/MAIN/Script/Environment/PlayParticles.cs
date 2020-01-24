using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticles : MonoBehaviour {
    public ParticleSystem[] ParticleList;

    private void OnTriggerEnter(Collider other) {
        foreach (ParticleSystem particleSystem in ParticleList) {
            particleSystem.Play();
        }
    }
}
