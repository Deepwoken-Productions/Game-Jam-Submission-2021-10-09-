using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager: MonoBehaviour
{
    public static FadeManager instance { get; private set; }

    public float speed;
    public Transform tilesDirectory;
    public Transform door;
    public Transform tv;

    public Material transparentMaterial;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void FadeAll()
    {
        AudioSource.PlayClipAtPoint((AudioClip)Resources.Load("Audio/DoorOpen"), door.transform.position);
        tv.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;

        for (int i = 0; i < tilesDirectory.childCount; i++)
        {
            tilesDirectory.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = transparentMaterial;
        }

        GameObject.Destroy(door.gameObject);
    }
}
