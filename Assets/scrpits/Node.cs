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
        BuildManger = buildManger.instance;
    }

    private void OnMouseDown()
    {
        if(!BuildManger.CanBuild)
        {
            return;
        }


        if (turret != null)
        {
            Debug.Log("cant build here");
            return;
        }

        BuildManger.BuildTurretOn(this);
        
        
    }

    
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor; 
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }


}
