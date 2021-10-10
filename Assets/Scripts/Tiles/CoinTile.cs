using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct CoinTile : ITile
{
    public GameObject tile;

    bool triggered { get; set; }

    public GameObject GetTile()
    {
        return tile;
    }

    public CoinTile(bool isTriggered)
    {
        tile = TileManager.instance.tilePrefabs[0];
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
