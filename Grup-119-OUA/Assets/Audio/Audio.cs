using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource walkSound;

    public void PlayWalkSound()
    {
        walkSound.Play();
    }
}
