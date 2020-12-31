using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset = new Vector3 (4f,9.9f, 6.5f);


    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
