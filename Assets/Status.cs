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
    public bool ShtUp = false; // Shoot to collect upgrade
    public float dmg; // Damage dealt by the enemy
    public GameObject canvas;
    private int prevlvl=0;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerstatus = player.GetComponent<Status>();
        maxHealth = 100f;
        exp = 0f;
        currHealth = maxHealth;
        lvl = 0;
        dmg = 10f; // Default damage for enemies
        if (this.tag != "Enemy")
        {
            Debug.Log("Status Start");
            canvas.SetActive(false);
        }
    }

    void Update()
    {
        Debug.Log(dmg);
        if (this.tag != "Enemy")
        {
            Debug.Log("Status Update");
            if (prevlvl != lvl) // B)
            {
                canvas.SetActive(true);
                prevlvl = lvl;
                Time.timeScale = 0f; // Pause the game
                Cursor.lockState = CursorLockMode.None; // Unlock the cursor
                Cursor.visible = true; // Make the cursor visible
            }

        }
        //gameObject.CompareTag("Enemy") && 
        if (currHealth <= 0)
        {
            playerstatus.exp += 50f;
            GetComponent<LootBag>().InstantiateLoot(transform.position);
            Destroy(gameObject);

        }
    }
private void OnTriggerEnter(Collider other) // CZEMU TO KURWA NIE UPDATEUJE ZMIENNEJ WARTOSCI DMG?
    {
        if (other.tag == "Bullet" && this.tag == "Enemy")
        {
            Debug.Log($"Damage taken : {dmg}");
            currHealth -= dmg;
        }
    }
}
