using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();
    Loot GetDroppedItem()
    {
        int randomValue = Random.Range(1, 101);
        List<Loot> possibleLoot = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomValue <= item.dropChance)
            {
                possibleLoot.Add(item);
            }
        }
        if (possibleLoot.Count > 0)
        {
            Loot selectedLoot = possibleLoot[Random.Range(0, possibleLoot.Count)];
            return selectedLoot;
        }
        Debug.Log("No loot dropped");

        return null;

    }
    public void InstantiateLoot(Vector3 position)
    {
        Loot droppedItem = GetDroppedItem();
        if (droppedItem != null && droppedItem.itemPrefab != null)
        {
            GameObject lootInstance = Instantiate(droppedItemPrefab, position, Quaternion.identity);
            lootInstance.tag = droppedItem.type;

            // Copy mesh
            MeshFilter targetMeshFilter = lootInstance.GetComponent<MeshFilter>();
            MeshFilter sourceMeshFilter = droppedItem.itemPrefab.GetComponent<MeshFilter>();
            if (targetMeshFilter != null && sourceMeshFilter != null)
            {
                targetMeshFilter.mesh = sourceMeshFilter.sharedMesh;
            } else {Debug.Log("Ruh-roh shaggy");}

            // Copy material
            MeshRenderer targetRenderer = lootInstance.GetComponent<MeshRenderer>();
            MeshRenderer sourceRenderer = droppedItem.itemPrefab.GetComponent<MeshRenderer>();
            if (targetRenderer != null && sourceRenderer != null)
            {
                targetRenderer.materials = sourceRenderer.sharedMaterials;
            }
        }
        else
        {
            Debug.Log("No loot to instantiate");
        }
    }
}
