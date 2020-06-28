using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float startDistance = 15f;
    [SerializeField] float finishDistance = 2.5f;
    [SerializeField] float cameraZoomSpeed = 3f;
    public new Camera camera;


    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
        camera.orthographicSize = startDistance;
    }
    private void Update()
    {
        if (camera.orthographicSize > finishDistance)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, finishDistance, Time.deltaTime * cameraZoomSpeed);
        }
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
