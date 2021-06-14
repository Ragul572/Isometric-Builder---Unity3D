using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int width;
    public int height;
    public int cellsize;
    public Vector3 origin;
    private GameObject[,] grid;
   
    public Grid() { }
    public Grid(int width, int height,int cellsize,Vector3 origin)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;
        this.origin = origin;
        grid = new GameObject[width, height];
    }
    public void GetGridXZ(Vector3 worldPos,out int x,out int z)
    { 
       x = Mathf.FloorToInt((worldPos - origin).x / cellsize);
       z = Mathf.FloorToInt((worldPos - origin).z / cellsize);
    }
    
    public void AddToGrid(GameObject track)
    {
        int x;
        int z;
        GetGridXZ(track.transform.position, out x, out z);
        grid[x, z] = track;
        
    }
    public bool CanPlace(Vector3 position)
    {
        int x;
        int z;
        GetGridXZ(position, out x, out z);
        return grid[x, z] == null;
    }

    public Vector3 GetGridCellPosition(int x,int z)
    {
        float xPosInGrid = x * cellsize;
        float zPosInGrid = z * cellsize;
        return origin + new Vector3(xPosInGrid, 0.0f, zPosInGrid);
    }
  






}
