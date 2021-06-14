using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class TrackUI : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
   
    public Canvas canvas;
    public GameObject trackType;
    private Mesh trackMesh;
    public Material previewMat;
    private bool isPointerDown = false;
    RaycastHit spawnPoint;
    private GridManager gridManager;
   
    public void Start()
    {
      
        gridManager = FindObjectOfType<GridManager>();
        trackMesh = trackType.GetComponent<MeshFilter>().sharedMesh;
      
    }
    public void Update()
    {
        if(isPointerDown)
        {
            if(CheckForGround())
            {
                Graphics.DrawMesh(trackMesh, spawnPoint.point,trackType.transform.rotation, previewMat, 0);
            }
        }
        RotateTrack();
    }
    private bool CheckForGround()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out spawnPoint, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            return true;
        }
        return false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }
  
    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        if (CheckForGround())
        {
            int x;
            int z;
            gridManager.grid.GetGridXZ(spawnPoint.point, out x, out z);
            Vector3 spawnPos = gridManager.grid.GetGridCellPosition(x, z);
            spawnPos.y = spawnPoint.point.y;

            spawnPos.x += (gridManager.grid.cellsize / 2.0f);
            spawnPos.z += (gridManager.grid.cellsize / 2.0f);


            if(gridManager.grid.CanPlace(spawnPoint.point))
            {
                GameObject trackObj = Instantiate(trackType, spawnPos, trackType.transform.rotation);
                CarController.wayPoints.Add(trackObj.transform);
                CarController.surface.BuildNavMesh();
                gridManager.grid.AddToGrid(trackObj);
            }
           
        }
    }
    private void RotateTrack()
    {
        if(Input.GetMouseButtonDown(1))
        {
            trackType.transform.Rotate(Vector3.up, 90);
        }
          
    }
  

    
}
