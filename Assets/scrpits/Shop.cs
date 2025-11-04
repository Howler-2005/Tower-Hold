using UnityEngine;

public class Shop : MonoBehaviour
{
    buildManger BuildManger;

    private void Start()
    {
        BuildManger = buildManger.instance;
    }

    public void PurchaseArrowTurret()
    {
        Debug.Log("Arrow Tower purchase");
        BuildManger.SetTurretToBuild(BuildManger.standardTurretPrefab);
    }

    public void PurchaseCannonTurret()
    {
        Debug.Log("Cannon Tower purchase");
    }

    public void PurchaseMagicTurret()
    {
        Debug.Log("Magic Tower purchase");
    }

}
