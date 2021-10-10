using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip beat;
    void Start()
    {
        AudioSource.PlayClipAtPoint(beat, transform.position);
    }
    void Update()
    {
        
    }
}
