   using UnityEngine;


public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    public Vector3 positionOffSet;

    public GameObject turret;
    
    buildManger BuildManger;


    private Renderer rend;
    

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (BuildManger.GetTurretToBuild() == null)
        {
            return;
        }


        if (turret != null)
        {
            Debug.Log("cant build here");
            return;
        }

        GameObject turretToBuild = BuildManger.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffSet, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (BuildManger.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor; 
    }

}
