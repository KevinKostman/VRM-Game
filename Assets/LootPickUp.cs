using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickUp : MonoBehaviour
{
    public GameObject playerObj;
    private Status player;
    public float hpup = 0f;
    public float expup;
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

    void OnTriggerEnter(Collider other)
    {
        if (ShtUp != true)
        {
            if (other.tag == "Player")
            {
                Collect();
            }

        }
        else
        {
            Debug.Log("Cringe");
            if (other.tag == "Player" || other.tag == "Bullet")
            {
                Collect();
            }

        }
    }
    void Collect()
    {
        if (gameObject.tag == "HP")
        {
            gameObject.tag = "PickedUp";
            hpup = 20f;
            expup = 0f;
        }
        else
        {
            expup = 20f;
            hpup = 0f;
        }
        StartCoroutine(DelayedDestroy());
    }

    IEnumerator DelayedDestroy()
    {
        yield return null; // wait 1 frame
        Destroy(gameObject);
    }

}
