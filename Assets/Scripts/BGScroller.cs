using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollspeed;
    public float tileSizeZ;
    private Vector3 startPosition;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        startPosition = transform.position;
    }

    void Update()
    {
        float NewPosition = Mathf.Repeat(Time.time * scrollspeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * NewPosition;
        if (gameController.score >= 100)
        {
            NewPosition = Mathf.Repeat(Time.time * scrollspeed * 200, tileSizeZ);
            transform.position = startPosition + Vector3.forward * NewPosition;
        }
    }
}