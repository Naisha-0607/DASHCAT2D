using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSource;

    private void Start ()
    {
        anim = GetComponent<Animator>();
        

    audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        anim.SetTrigger ("Touched");
        audioSource.Play();
    }
}