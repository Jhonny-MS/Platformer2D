using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweenShoot = .2f;
    public Transform playerSideReferences;

    private Coroutine _currentCoroutine;
    // public PoolManager poolManager;
    


    [Header("Sounds")]
    public AudioSource audioSource;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentCoroutine = StartCoroutine(StartShoot());  
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (_currentCoroutine != null) 
                StopCoroutine(_currentCoroutine);       
        }
    }
    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);

            /*var obj = poolManager.GetPooledObject();
              obj.SetActive(true);
              obj.GetComponent<ProjectileBase>().StartProjectile();
              */

        }
    }
    public void Shoot()
    {
        if (audioSource != null) audioSource.Play();
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReferences.transform.localScale.x;

    }
}
