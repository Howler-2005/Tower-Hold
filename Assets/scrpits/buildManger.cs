using UnityEngine;

public class buildManger : MonoBehaviour
{
    private GameObject turretToBuild;

    public static buildManger instance;

    public GameObject standardTurretPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one build maganer in scene");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }


    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }


}
