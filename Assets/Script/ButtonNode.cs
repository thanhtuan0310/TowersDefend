using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonNode : MonoBehaviour
{
    public Vector3 positionOffset;
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public GameObject turret;

    public AudioClip towerSell;
    public AudioClip towerUpgrade;
    public AudioSource playAudio;

    public TurretPrint turretPrint;
    public bool isUpgrade = false;

    private Renderer rend;
    private Color startColor;
    BuiltManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuiltManager.instance;
        playAudio = GetComponent<AudioSource>();
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        
        if(turret != null) // Kiem tra tru duoc xay chua
        {
            buildManager.SelectNode(this); // Neu da xay thi hien thi nodeUI
            Debug.Log("Can Built!.");
            return;
        }

        if (!buildManager.CanBuild) // Neu chua chon thap de xay thi thoat ra
        {
            return;
        }

       BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretPrint blueprint)
    {
        if (PlayerStarts.Money < blueprint.cost) // Neu khong du tien de xay thap
        {
            Debug.Log("Not Enough Money");
            return;
        }

        PlayerStarts.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretPrint = blueprint; // Gan gia tri cho tru de tranh tra ve NULL
    }

    public void UpgradeTurret()
    {
        if (PlayerStarts.Money < turretPrint.upgradeCost) // Neu khong du tien de nang cap
        {
            Debug.Log("Not Enough Money to upgrade");
            return;
        }

        PlayerStarts.Money -= turretPrint.upgradeCost;
        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretPrint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        playAudio.PlayOneShot(towerUpgrade, 1.0f);
        turret = _turret;

        isUpgrade = true;
    }

    public void SellTurret()
    {
        PlayerStarts.Money += turretPrint.GetSellAmount();
        playAudio.PlayOneShot(towerSell, 1.0f);
        Destroy(turret);
        turretPrint = null;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }


    void OnMouseExit()
    {
       
        rend.material.color = startColor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
