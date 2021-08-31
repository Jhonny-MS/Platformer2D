using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletable : MonoBehaviour
{
    private int Score = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Score++;
        }

        Debug.Log("Score: " + Score);
    }
}
