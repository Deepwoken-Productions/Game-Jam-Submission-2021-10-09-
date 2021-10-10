using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct CoinTile : ITile
{
    public GameObject tile { get; set; }

    bool triggered { get; set; }

    public CoinTile(Material Mat)
    {
        tile = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tile.GetComponent<MeshRenderer>().material = Mat;
        tile.transform.localScale = new Vector3(8f, 0.125f, 8f);
        triggered = false;
    }

    public void OnStep()
    {
        AudioSource.PlayClipAtPoint((AudioClip)Resources.Load("Audio/click"), tile.transform.position);
    }

    public void Push()
    {

    }

    public void Create(Vector3 Location)
    {
        tile.transform.position = Location;
        if (tile) 
        {
            Debug.Log("Pog" + tile.transform.position);
        }
        //Does nothing?
        tile = GameObject.Instantiate(tile, Location, Quaternion.identity);
    }
}
