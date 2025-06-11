using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private IEnumerator destroyProjectile;
    private float time = 5f;
    private Status playerstatus;

    private void Start() {
        destroyProjectile = _destroyProjectile(time);
        StartCoroutine(destroyProjectile);
        
    }
    
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
            
            Destroy(gameObject);
        }
    }

    private IEnumerator _destroyProjectile(float timeToDestroy){
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}