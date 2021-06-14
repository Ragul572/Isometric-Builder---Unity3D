using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    private void OnEnable()
    {
        EnabelVfx();
    }
    IEnumerator EnabelVfx()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        this.transform.GetChild(0).gameObject.SetActive(false);
    }

}
