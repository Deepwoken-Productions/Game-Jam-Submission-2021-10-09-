using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Vector3 playerSpawnPosition;
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        player.gameObject.GetComponent<CharacterController>().enabled = false;
        player.gameObject.transform.SetPositionAndRotation(playerSpawnPosition, Quaternion.identity);
        player.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
