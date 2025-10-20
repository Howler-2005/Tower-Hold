using UnityEngine;

public class waypoints : MonoBehaviour
{

    public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int I = 0; I < points.Length; I++)
        {
            points[I] = transform.GetChild(I);
        }
    }





}
