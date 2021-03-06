using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DefaultTile : ITile
{
    public GameObject tile;

    bool triggered { get; set; }

    public GameObject GetTile()
    {
        return tile;
    }

    public DefaultTile(bool isTriggered)
    {
        tile = TileManager.instance.tilePrefabs[1];
        triggered = false;
    }

    public void OnStep()
    {
        AudioSource.PlayClipAtPoint((AudioClip)Resources.Load("Audio/click"), tile.transform.position);
    }

    public void Push()
    {

    }
}
