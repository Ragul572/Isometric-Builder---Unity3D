using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> trackUIList;
    private GameObject currentTrack;
    private void Start()
    {
        currentTrack = trackUIList[0];
    }
    public void RemoveTrack(int index)
    {
        trackUIList.RemoveAt(index);
    }
    public void DisableCurrentItem(int index)
    {
        currentTrack.SetActive(false);
    }
    public void GetRandomUI()
    {

    }
}
