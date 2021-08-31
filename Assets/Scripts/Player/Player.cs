using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public Vector2 friction = new Vector2(.1f,0);
    public string keyToCheck = "floor";

    [Header("Jump")]
    public float forceJump = 2;

    [Header("Movement Speed")]
    public float speedRun;
    private float _currentSpeed;
    public float speed;

    [Header("Animation Setup")]
    public float animationDuration = .3f;
    public float jumpScaleY = 1f;
    public float jumpScaleX = 0.5f;
    public Ease ease = Ease.OutBack;
    public float fallScaleY = -0.7f;
    public float fallScaleX = -0.5f;

    [Header("Controls")]
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode jump;
    public KeyCode run;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(run))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(moveLeft))
        {
            //myRigidbody2D.MovePosition(myRigidbody2D.position - velocity * Time.deltaTime);
            myRigidbody2D.velocity = new Vector2(-_currentSpeed, myRigidbody2D.velocity.y);
        }
        else if (Input.GetKey(moveRight))
        {
            //myRigidbody2D.MovePosition(myRigidbody2D.position + velocity * Time.deltaTime);
            myRigidbody2D.velocity = new Vector2(_currentSpeed, myRigidbody2D.velocity.y);
        }

        if(myRigidbody2D.velocity.x < 0)
        {
            myRigidbody2D.velocity += friction;
        }
        else if (myRigidbody2D.velocity.x > 0)
        {
            myRigidbody2D.velocity -= friction;
        }
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(jump))
        {
            myRigidbody2D.velocity = Vector2.up * forceJump;
            ResetAnimation();
            HandleScaleJump();
        }
    }
    private void ResetAnimation()
    {
        myRigidbody2D.transform.localScale = Vector2.one;
        DOTween.Kill(myRigidbody2D.transform);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == keyToCheck)
        {
            HandleScaleFall();           
            //ResetAnimation();
        }
    }
    private void HandleScaleJump()
    {
        myRigidbody2D.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody2D.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
    private void HandleScaleFall()
    {
        myRigidbody2D.transform.DOScaleY(fallScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody2D.transform.DOScaleX(fallScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }   
}
