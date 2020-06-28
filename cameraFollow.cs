using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 offset;
    //public Camera camera;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    private void Update()
    {

    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
