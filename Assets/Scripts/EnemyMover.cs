using UnityEngine;
using System.Collections;



public class EnemyMover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
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
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        if (gameController.hardmode == true)
        {
            rb.velocity = transform.forward * speed * 2;
        }
    }
}