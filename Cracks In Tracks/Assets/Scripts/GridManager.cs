using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Grid grid;
    public Transform origin;
    public bool enableDebug = false;

    private void Awake()
    {
        grid = new Grid(10,10, 1, origin.position);
        enableDebug = true;
    }

    private void OnDrawGizmos()
    {
        if(enableDebug)
        {
            Gizmos.color = Color.red;

            Gizmos.DrawRay(origin.position, new Vector3(0f, 0f, 10));
            Gizmos.DrawRay(origin.position, new Vector3(10f, 0f, 0f));

            for (int i = 0; i < grid.width; i++)
            {
                Gizmos.DrawRay(origin.position + new Vector3(0f, 0f, i * grid.cellsize), Vector3.right * grid.width);
            }
            for (int j = 0; j < grid.height; j++)
            {
                Gizmos.DrawRay(origin.position + new Vector3(j * grid.cellsize, 0f, 0f), Vector3.forward * grid.height);
            }
        }
    }
   
}
