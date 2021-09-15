using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMove : MonoBehaviour
{
    public Vector2 enemyDirection;
    public bool isRight = false;
    private float timeForTurn;
    public Rigidbody2D myRigidbody2D;
    public float enemySwipeDuration = .2f;

    public void Update()
    {
        MoveEnemy();
        Turn();
        timeForTurn++;
        if (timeForTurn > 500)
        {
            timeForTurn = 0;
        }
    }
    public void MoveEnemy() 
    {
        if (!isRight)
        {
            transform.Translate(enemyDirection * Time.deltaTime);
            myRigidbody2D.transform.DOScaleX(-1, enemySwipeDuration);

        }
        else
        {
            transform.Translate(-enemyDirection * Time.deltaTime);
            myRigidbody2D.transform.DOScaleX(1, enemySwipeDuration);

        }
    }
    public void Turn()
    {
        if(timeForTurn < 250)
        {
            isRight = true;            
        }
        else
        {
            isRight = false;
        }
    }
}
