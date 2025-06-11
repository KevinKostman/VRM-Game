using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickUp : MonoBehaviour
{
    public GameObject playerObj;
    private Status player;
    private float exp;
    private float health;
    private string type;
    public bool ShtUp;
    // Start is called before the first frame update
    void Awake()
    {
        player = playerObj.GetComponent<Status>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        ShtUp = player.ShtUp;
        
    }

    void OnTriggerEnter(Collider other){
        if(ShtUp != true)
        {
            if(other.tag == "Player")
            {
                Collect();
            }
            
        }else
        {
            Debug.Log("Cringe");
            if(other.tag == "Player" || other.tag == "Bullet") 
            {
                Collect();
            }
            
        }
    }
    void Collect()
    {
        Debug.Log("HAI");
        health = player.currHealth;
        exp = player.exp;
        if(gameObject.tag == "HP"){
            Debug.Log("HAI HP");
            if (health != player.maxHealth)
            {
                if(health + 20 > player.maxHealth)
                {
                    health += player.maxHealth - health; 
                }else{
                health += 20;
                }
            }else
            {
                Debug.Log("No overheal");
                
            }
        }else
        {
            exp += 20;
        }
        Destroy(gameObject);

    }
}
