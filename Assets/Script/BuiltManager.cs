using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltManager : MonoBehaviour
{
    public static BuiltManager instance;
   
    void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this; 
    } 
    private TurretPrint turretToBuild;
    private ButtonNode selectedNode;

    public NodeUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStarts.Money >= turretToBuild.cost; } }

    
    public void SelectNode(ButtonNode node)
    {
        
        if(selectedNode == node) // Neu UI dang duoc hien thi
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretPrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    
    public TurretPrint GetTurretToBuild()
    {
        return turretToBuild;
    }
    
}
