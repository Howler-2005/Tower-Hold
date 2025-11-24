using UnityEngine;

public class Shop : MonoBehaviour
{

    public turretBlueprint arrowTower;
    public turretBlueprint Cannon;


    buildManger BuildManger;

    private void Start()
    {
        BuildManger = buildManger.instance;
    }

    public void SelectarrowTower()
    {
        Debug.Log("Arrow Tower selected");
        BuildManger.SelectTurretToBuild(arrowTower);
    }

    public void SelectCannonTower()
    {
        Debug.Log("Cannon Tower selected");
        BuildManger.SelectTurretToBuild(Cannon);
    }

   

}
