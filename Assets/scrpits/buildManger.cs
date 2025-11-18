using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class buildManger : MonoBehaviour
{
    private turretBlueprint turretToBuild;

    public static buildManger instance;

    public GameObject arrowTowerPrefab;

    public GameObject CannonPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one build maganer in scene");
            return;
        }

        instance = this;
    }
   
    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("not enough cash");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("turret built; Money left:" + PlayerStats.Money);

    }
    public void SelectTurretToBuild(turretBlueprint turret)
    {
        turretToBuild = turret;
    }


   
}
