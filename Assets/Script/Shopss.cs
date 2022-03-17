using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopss : MonoBehaviour
{
    public TurretPrint standardTurret;
    public TurretPrint missleLauncher;
    public TurretPrint laserBeamer;
    BuiltManager buildManager;
    void Start()
    {
        buildManager = BuiltManager.instance;
    }
    public void SelectStandardTurret()
    {
       
        buildManager.SelectTurretToBuild(missleLauncher);
        Debug.Log("Standard");
    }

    public void SelectTowerTurret()
    {
        Debug.Log("Another");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectLaserTower()
    {
        Debug.Log("Laser");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
    
}
