using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour, ITile
{
    public GameObject tile;

    private void OnTriggerEnter(Collider other)
    {
        OnStep();
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
        AudioSource.PlayClipAtPoint((AudioClip)Resources.Load("Audio/click"), tile.transform.position);
    }
}
