using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldMover : MonoBehaviour
{
    private GameController gameController;
    private ParticleSystem ps;
    private float hSliderValue = 1.0F;

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
        ps = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;

        if (gameController.score >= 100)
        {
            hSliderValue = 50;
        }

    }
}