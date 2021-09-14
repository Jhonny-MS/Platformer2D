using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector2 direction;

    public float timeToReset = 1f;

    public float side = 1;

    public int damageAmount = 1;

   

    private void Awake()
    {
        // Destroy(gameObject, timeToDestroy);
    }
    public void StartProjectile()
    {
        Invoke(nameof(FinishUsage), timeToReset);
    }
    public void FinishUsage()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        //if (audioSource != null) audioSource.Play();

        if (enemy != null)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}
