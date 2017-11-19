using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public Vector3 offset = new Vector3(0f, 0.5f, 0f);
    public BuildNode _selected;

    public GameObject basicTurretPrefab;

    private GameObject turretToBuild;

    void Awake()
    {
        if (instance != null)
            return;
        instance = this;
        turretToBuild = basicTurretPrefab;
    }
    
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }


	//This function is the build function, should recalculate the path once building a new
    public void BuildStandardTurret()
    {
        MoneyManager.M.AddMoney(-500);
        turretToBuild = Instantiate(turretToBuild, _selected.transform.position + offset, _selected.transform.rotation);
        _selected.turret = turretToBuild;
        MenuManager.instance.HideBuild();


		Vector3 newBuild = _selected.transform.position;
		Debug.Log (newBuild);

		int newy = (int)newBuild.x / 5;
		int newx = (int)newBuild.z / (-5);

		Pathfinding.record [newx] [newy] = false;
		Pathfinding.renew ();
    }

    public void SellTurret()
    {
        Destroy(_selected.turret);
        turretToBuild = basicTurretPrefab;
        MoneyManager.M.AddMoney(450);
        MenuManager.instance.HideUpgradeSell();


		Vector3 newSell = _selected.transform.position;
		Debug.Log (newSell);

		int newy = (int)newSell.x / 5;
		int newx = (int)newSell.z / (-5);

		Pathfinding.record [newx] [newy] = true;
		Pathfinding.renew ();
    }
    
}
