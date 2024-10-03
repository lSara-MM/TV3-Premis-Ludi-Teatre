using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PropManager : MonoBehaviour
{
    //public string selectedProp = "";
    [SerializeField] private GameObject prefabProp = null;

    // Start is called before the first frame update
    void Start()
    {
        List<PropData> propsDataList = ReadCSV.Read<PropData>("CSV/Props");

        foreach (PropData data in propsDataList)
        {
            data.CreateProp(data.Name, data.InternalTag);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click or touch on Web
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0; // Ensure it's on the 2D plane

            SpawnProp(clickPosition);
        }
    }

    #region Getters/Setters
    public GameObject GetPrefab()
    {
        return prefabProp;
    }

    public void SetPrefab(GameObject go)
    {
        prefabProp = go;
    }
    #endregion // Getters/Setters

    void SpawnProp(Vector3 pos)
    {
        if (prefabProp != null)
        {
            // Instantiate the prop at the clicked position
            Instantiate(prefabProp, pos, Quaternion.identity);

            Debug.Log($"{prefabProp} spawned");
            prefabProp = null;
        }
        else
        {
            Debug.Log("No prop selected");
        }
    }
}
