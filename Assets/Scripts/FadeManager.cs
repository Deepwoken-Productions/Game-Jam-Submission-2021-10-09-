using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public float speed;

    public void FadeAll()
    {
        Color unitySilly = new Color(0, 0, 0, 0);
        Transform tv = transform.GetChild(0);
        Transform parentMap = transform.GetChild(1);
        Transform barricade = transform.GetChild(2);

        tv.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;

        for (int i = 0; i < parentMap.childCount; i++)
        {
            parentMap.gameObject.GetComponent<MeshRenderer>().material.color = unitySilly;
        }
        Destroy(barricade.gameObject);
    }
}
