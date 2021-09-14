using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;   
    public string keyToCheck = "floor";
    public HealthBase healthBase;
    private float _currentSpeed;
    public Animator animator;
    public bool isPaused = false;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    [Header("Jump Collision Check")]
    public Collider2D myCollider2D;
    public float distToGround;
    public float spaceToGround = .1f;
    public ParticleSystem jumpVFX;
    

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
        if(myCollider2D != null)
        {
            distToGround = myCollider2D.bounds.extents.y;
        }
    }
    private bool isGrouded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.red, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }
    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(soPlayerSetup.triggerDeath);
        if (audioSource != null) audioSource.Play();
    }
    private void Update()
    {
        isGrouded();
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(soPlayerSetup.run))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            animator.speed = 1;
        }

        if (Input.GetKey(soPlayerSetup.moveLeft) && !isPaused)
        {
            //myRigidbody2D.MovePosition(myRigidbody2D.position - velocity * Time.deltaTime);
            myRigidbody2D.velocity = new Vector2(-_currentSpeed, myRigidbody2D.velocity.y);
            if(myRigidbody2D.transform.localScale.x != -1)
            {
                myRigidbody2D.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }
            animator.SetBool(soPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(soPlayerSetup.moveRight) && !isPaused)
        {
            //myRigidbody2D.MovePosition(myRigidbody2D.position + velocity * Time.deltaTime);
            myRigidbody2D.velocity = new Vector2(_currentSpeed, myRigidbody2D.velocity.y);
            if (myRigidbody2D.transform.localScale.x != 1)
            {
                myRigidbody2D.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
            animator.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            animator.SetBool(soPlayerSetup.boolRun, false);

        }

        if (myRigidbody2D.velocity.x < 0)
        {
            myRigidbody2D.velocity += soPlayerSetup.friction;
        }
        else if (myRigidbody2D.velocity.x > 0)
        {
            myRigidbody2D.velocity -= soPlayerSetup.friction;
        }
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(soPlayerSetup.jump) && isGrouded() && !isPaused)
        {
            myRigidbody2D.velocity = Vector2.up * soPlayerSetup.forceJump;
            animator.SetTrigger(soPlayerSetup.triggerJump);
            PlayJumpVFX();           
            //ResetAnimation();
            //HandleScaleJump();
        }
    }   
    private void PlayJumpVFX()
    {
        if (jumpVFX != null) jumpVFX.Play();
    }
    /*private void ResetAnimation()
    {
        myRigidbody2D.transform.localScale = Vector2.one;
        DOTween.Kill(myRigidbody2D.transform);
    } */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == keyToCheck)
        {
            animator.SetBool(soPlayerSetup.triggerJump, false);
            //HandleScaleFall();           
            //ResetAnimation();
        }
    }
    /* 
     
    private void HandleScaleJump()
    {
        myRigidbody2D.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody2D.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }
    private void HandleScaleFall()
    {
        myRigidbody2D.transform.DOScaleY(soPlayerSetup.fallScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody2D.transform.DOScaleX(soPlayerSetup.fallScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }   */
    public void DestroyMe()
    {
        Destroy(gameObject, soPlayerSetup.timeToDeath);
    }    
}
