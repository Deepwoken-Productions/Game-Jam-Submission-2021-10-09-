using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ending.instance.EndLevel(true);
    }
}
