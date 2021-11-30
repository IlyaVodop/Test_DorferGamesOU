using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip CristalSound;
    [SerializeField] private AudioClip ClickSound;
    [SerializeField] private AudioClip SoundFood;

    [SerializeField] private float _currentTime;

   
    public void SoundCristal()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(CristalSound);
    }
    public void SoundClick()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(ClickSound);
    }
    public void FoodSound()
    {
      
        if (_currentTime + 1 < Time.time)
        {   
            _currentTime = Time.time;
            gameObject.GetComponent<AudioSource>().PlayOneShot(SoundFood);
        }
    }
}
