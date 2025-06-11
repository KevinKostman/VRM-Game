using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject itemPrefab;
    public string itemName;
    public string type;
    public int dropChance;

    public Loot(string itemName, GameObject itemPrefab, int dropChance, string type)
    {
        this.itemName = itemName;
        this.dropChance = dropChance;
        this.type = type;
    }
}
