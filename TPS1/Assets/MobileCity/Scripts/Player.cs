using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem confettiBlastRainbow; // Kéo và thả particle system vào đây từ tab Project
    public float particleCooldownTime = 5f;
    private float particleCooldownTimer;
    private bool canShootParticle = true;

    private void Update()
    {
        if (!canShootParticle)
        {
            particleCooldownTimer -= Time.deltaTime;
            if (particleCooldownTimer <= 0)
            {
                canShootParticle = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canShootParticle)
        {
            confettiBlastRainbow.Play();
            canShootParticle = false;
            particleCooldownTimer = particleCooldownTime;
            Debug.Log("123");
        }
    }
}
