using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Range(-1.0f, 1.0f)] [SerializeField] float xDirection = 0.0f;
    [Range(-1.0f, 1.0f)] [SerializeField] float yDirection = 0.0f;
    [Range(-1.0f, 1.0f)] [SerializeField] float zDirection = 0.0f;
    [SerializeField] float multiplayer=1;

    private void Update()
    {
        transform.Rotate(new Vector3(xDirection, yDirection, zDirection) * multiplayer,Space.Self);
    }
}
