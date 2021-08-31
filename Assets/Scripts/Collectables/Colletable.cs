using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletable : MonoBehaviour
{
    private int Points = 0;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Score();
        }
       
        Debug.Log("Coins: " + Points);
        
    }
    private void Score()
    {
        Points++;       
    }
}
