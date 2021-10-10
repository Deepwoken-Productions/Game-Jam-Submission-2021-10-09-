using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NullTile : ITile
{
    public GameObject tile;

    bool triggered { get; set; }

    public GameObject GetTile()
    {
        return tile;
    }

    public NullTile(bool isTriggered)
    {
        tile = TileManager.instance.tilePrefabs[1];
        triggered = false;
    }

    public void OnStep()
    {
        
    }

    public void Push()
    {

    }
}
