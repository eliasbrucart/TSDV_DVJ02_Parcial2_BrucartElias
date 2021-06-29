using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    private Vector3 initialPosition;
    void Start()
    {
        Player.PlayerCamZoom += FollowPlayer;
        Player.PlayerCamZoomOut += ZoomOut;
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        offset = new Vector3(0,0,-5.0f);
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, 0.5f);
    }

    private void ZoomOut()
    {
        transform.position = Vector3.Lerp(transform.position, initialPosition, 0.5f);
    }

    private void OnDisable()
    {
        Player.PlayerCamZoom -= FollowPlayer;
        Player.PlayerCamZoomOut -= ZoomOut;
    }
}
