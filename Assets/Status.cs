using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
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
    private int prevlvl = 0;
    private GameObject upgradeHub;
    private UpgradeHub upgradeHubScript;
    private LootPickUp lootPickUp;
    private GameObject loot;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerstatus = player.GetComponent<Status>();
        upgradeHub = GameObject.FindWithTag("Upgrades");
        if (upgradeHub != null)
        {
            upgradeHubScript = upgradeHub.GetComponent<UpgradeHub>();
        }
        else
        {
            UnityEngine.Debug.LogWarning("UpgradeHub not found in the scene.");
        }


        maxHealth = 100f;
        exp = 0f;
        currHealth = maxHealth;
        lvl = 0;
        dmg = 10f; // Default damage for enemies
        if (this.tag != "Enemy")
        {
            canvas.SetActive(false);
        }
    }

    void Update()
    {
        
        if (this.tag == "Enemy")
        {

            if (currHealth <= 0)
            {
                playerstatus.exp += 50f;
                GetComponent<LootBag>().InstantiateLoot(transform.position);
                Destroy(gameObject);
            }

        }
        if (this.tag != "Enemy")
        {
            if (GameObject.FindWithTag("PickedUp") != null)
            {
                Debug.Log("Loot found");
                loot = GameObject.FindWithTag("PickedUp");
                lootPickUp = loot.GetComponent<LootPickUp>();
                currHealth += lootPickUp.hpup;
            }

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

    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Bullet" && this.tag == "Enemy")
        {

            // currHealth -= dmg;
            currHealth -= upgradeHubScript.dmg;
        }
    }
    private float damageCooldown = 1f; // seconds between damage ticks
    private float lastDamageTime = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && CompareTag("Player"))
        {
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                currHealth -= 10;
                lastDamageTime = Time.time;
            }
        }
    }
}
