using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameZone : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
      gameManager = FindObjectOfType<GameManager>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.EndGame();
        // if (collision.gameObject.CompareTag("Box"))
        // {
        //     gameManager.EndGame();
        // }
    }
}
