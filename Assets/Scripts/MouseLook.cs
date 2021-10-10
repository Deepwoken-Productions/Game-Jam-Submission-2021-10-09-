using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        AudioSource.PlayClipAtPoint((AudioClip)Resources.Load("Audio/Voice"), playerBody.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotates the player to face the correct direction that they are looking... not needed considering context of game
        transform.localRotation = Quaternion.Euler(xRotation, 0 ,0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
