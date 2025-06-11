using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{   
    [SerializeField]
    public float currHealth;
    public float maxHealth;
    public float exp;
    public int lvl;
    private GameObject player;
    private Status playerstatus;
    // Start is called before the first frame update
    void Awake()
    {   
        player = GameObject.FindWithTag("Player");
        playerstatus = player.GetComponent<Status>();
        maxHealth = 100f;
        exp = 0f;
        currHealth = maxHealth;
        lvl = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.CompareTag("Enemy") && 
        if (currHealth <= 0)
        {
            playerstatus.exp += 50f;
            GetComponent<LootBag>().InstantiateLoot(transform.position);
            Destroy(gameObject);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && this.tag == "Enemy")
        {
            Debug.Log("He?");
            currHealth -= 10f;
        }
    }
}
