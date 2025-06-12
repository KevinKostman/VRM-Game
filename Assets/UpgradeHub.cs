using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHub : MonoBehaviour
{
    public GameObject playerObj;
    private Status playerStatus;
    public float dmg;


    public enum UpgradeType
    {
        FireRate,
        Damage,
        ShootToCollect // Logic upgrade
    }

    [System.Serializable]
    public class Upgrade
    {
        public string name;
        public string description;
        public float value; // Optional
        public UpgradeType type;
    }

    public List<Upgrade> availableUpgrades = new List<Upgrade>();

    [SerializeField] private UpgradeButton button1;
    [SerializeField] private UpgradeButton button2;

    private void Start()
    {
        dmg = 10f;
        
        playerStatus = playerObj.GetComponent<Status>();
        availableUpgrades.Add(new Upgrade
        {
            name = "Shoot to Collect",
            description = "Loot can be picked up by shooting it",
            type = UpgradeType.ShootToCollect
        });

        availableUpgrades.Add(new Upgrade
        {
            name = "Gain Damage",
            description = "Increase damage by 5",
            value = 5,
            type = UpgradeType.Damage
        });

        button1.AssignUpgrade(availableUpgrades[0], this);
        button2.AssignUpgrade(availableUpgrades[1], this);
        
    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        switch (upgrade.type)
        {
            case UpgradeType.Damage:
                dmg += upgrade.value;
                Debug.Log($"Damage increased by {upgrade.value}. New damage: {dmg}");
                break;

            case UpgradeType.ShootToCollect:
                if (playerStatus != null)
                {
                    playerStatus.ShtUp = true;
                    Debug.Log("Shoot-to-collect");
                }
                break;
        }
        playerStatus.canvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


}
