using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayAudio : MonoBehaviour
{
    AudioSource audioSource;

    public float chance = 0.6f;

    private void Start()
    {
        TryGetComponent<AudioSource>(out audioSource);
    }

    private void Update()
    {
        if(audioSource!= null)
        {
            if (!audioSource.isPlaying)
            {
                if (Random.Range(0, 1f) < chance) audioSource.Play();
            }
        }
    }

    public void setchance(float a)
    {
        chance = a;
    }
}
