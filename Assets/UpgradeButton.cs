using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    private UpgradeHub.Upgrade assignedUpgrade;
    private UpgradeHub manager;

    [SerializeField] private TMP_Text buttonText;
    
    public void AssignUpgrade(UpgradeHub.Upgrade upgrade, UpgradeHub mgr)
    {
        assignedUpgrade = upgrade;
        manager = mgr;

        if (buttonText != null)
            buttonText.text = upgrade.name;
    }

    public void OnClick()
    {
        Debug.Log("Button");
        if (assignedUpgrade != null && manager != null)
        {
            Debug.Log($"upgrade: {assignedUpgrade.name}");
            manager.ApplyUpgrade(assignedUpgrade);
        }
    }
}
