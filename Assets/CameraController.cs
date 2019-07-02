using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    public float dampTime = 0.15f;
    Vector3 zero = Vector3.zero;
    Vector3 GetVector3;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        GetVector3 = player.transform.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, GetVector3, ref zero, dampTime);
    }
}
