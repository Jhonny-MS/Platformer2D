using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Movement Speed")]
    public float speedRun;   
    public float speed;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("Jump")]
    public float forceJump = 2;

    [Header("Animation Setup")]
    public float animationDuration = .3f;
    public float jumpScaleY = 1f;
    public float jumpScaleX = 0.5f; 
    public Ease ease = Ease.OutBack;
    public float fallScaleY = -0.7f;
    public float fallScaleX = -0.5f;

    [Header("Animation Player")]
    public string boolRun = "isRun";
    public string boolJump = "isJump";
    public string triggerDeath = "isDead";
    public float playerSwipeDuration = 0.5f;
    public float timeToDeath = 1f;

    [Header("Controls")]
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode jump;
    public KeyCode run;
}
