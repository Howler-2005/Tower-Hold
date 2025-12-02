   using UnityEngine;


public class Node : MonoBehaviour
{
    public Color notEnoughMoney;
    public Color hoverColor;
    private Color startColor;
    public Vector3 positionOffSet;
    public Color placed;
    public GameObject turret;
    
    buildManger BuildManger;


    private Renderer rend;

    private void Update()
    {
        if (turret != null)
        {
            rend.material.color = placed;
        }
    }

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
        if (!BuildManger.CanBuild)
        {
            return;
        }
        if (BuildManger.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoney;
        }
       
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
