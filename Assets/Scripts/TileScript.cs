using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour, ITile
{
    public GameObject tile;
    public AudioClip click;
    public bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if(triggered == false)
        {
            OnStep();
            triggered = true;
        }
    }

    public GameObject GetTile()
    {
        return null;
    }

    public void Push()
    {

    }

    public void OnStep()
    {
        AudioSource.PlayClipAtPoint(click, tile.transform.position);
    }
}
