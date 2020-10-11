using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class ObstacleOnTrigger : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource=transform.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(!audioSource.isPlaying){
        audioSource.time = 3f; 
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime+(0.5f));   
        }
    }
}
