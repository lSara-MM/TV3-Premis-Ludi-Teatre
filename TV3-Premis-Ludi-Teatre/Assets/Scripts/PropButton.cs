using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PropButton : MonoBehaviour
{
    [SerializeField] private GameObject goProp;
    [SerializeField] private PropManager csPropManager;

    private void Start()
    {
        csPropManager = GameObject.Find("PropManager").GetComponent<PropManager>();
    }

    public void SelectProp()
    {
        string csProp = goProp?.GetComponent<PropBehaviour>().gameObject.name;

        if (csPropManager != null && csProp != null)
        {
            if (csPropManager.GetPrefab() == null ||
                csPropManager.GetPrefab().name != csProp)
            {
                csPropManager.SetPrefab(goProp);
                Debug.Log($"Prop {csPropManager.GetPrefab().name}");
            }
            else if (csPropManager.GetPrefab().name == csProp)
            {
                csPropManager.SetPrefab(null);
                Debug.Log($"Prop null");
            }
        }
    }
}
