using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    private Vector3 offset=new Vector3(0,1,-5);
    private void FixedUpdate()
    {
       
        transform.position = player.position + offset;
    }
}
