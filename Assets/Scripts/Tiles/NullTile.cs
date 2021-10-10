using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NullTile : ITile
{
    public GameObject tile { get; set; }

    public NullTile(bool DontNeedInput)
    {
        tile = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tile.transform.localScale = new Vector3(8f, 0.125f, 8f);
        tile.SetActive(false);
    }

    public void OnStep()
    {
        //AudioSource.PlayClipAtPoint((AudioClip)Resources.Load("Audio/click"), trans.position);
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
    }
}
