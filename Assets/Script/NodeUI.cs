using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Text SellAmount;

    public Button upgradeButton;
    private ButtonNode target;
    public void SetTarget(ButtonNode _target)
    {
        target = _target;

        // Lay vi tri hien tai cua UI
        transform.position = target.GetBuildPosition();

        // Target chua duoc upgrade
        if (!target.isUpgrade)
        {
            upgradeCost.text = "$" + target.turretPrint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {

            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        SellAmount.text = "$" + target.turretPrint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuiltManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuiltManager.instance.DeselectNode();
    }
    
}
