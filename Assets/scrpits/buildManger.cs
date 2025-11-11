using UnityEngine;

public class buildManger : MonoBehaviour
{
    public GameObject turretToBuild;

    public static buildManger instance;

    public GameObject standardTurretPrefab;

    public GameObject SecondTowerPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one build maganer in scene");
            return;
        }

        instance = this;
    }
   
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }
    

}
