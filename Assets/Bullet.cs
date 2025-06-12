using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private IEnumerator destroyProjectile;
    private float time = 5f;
    public float health;
    

    private void Start()
    {
        destroyProjectile = _destroyProjectile(time);
        StartCoroutine(destroyProjectile);

    }
    
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
            //other.SetComponent<Status>().currHealth = health;
            Destroy(gameObject);
        }
    }

    private IEnumerator _destroyProjectile(float timeToDestroy){
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}