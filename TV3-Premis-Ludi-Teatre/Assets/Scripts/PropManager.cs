using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PropManager : MonoBehaviour
{
    //public string selectedProp = "";
    [SerializeField] private GameObject prefabProp = null;

    // Define boundaries using Vector2 for better clarity
    [SerializeField] private Vector2 boundaryMin = new Vector2(-5f, -3f); // Bottom-left corner
    [SerializeField] private Vector2 boundaryMax = new Vector2(5f, 3f);    // Top-right corner

    [SerializeField] private bool showBoundaries = false;

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

            if (IsWithinBounds(clickPosition))
            {
                SpawnProp(clickPosition);
            }
        }

        if (showBoundaries)
        {
            DrawBoundary();
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

    #region Boundaries
    // Method to check if the position is within the defined boundaries
    bool IsWithinBounds(Vector3 position)
    {
        return position.x >= boundaryMin.x && position.x <= boundaryMax.x &&
               position.y >= boundaryMin.y && position.y <= boundaryMax.y;
    }

    void DrawBoundary()
    {
        // Set the duration for how long the lines will be visible
        float duration = 0.1f;

        // Draw the rectangle boundary
        Debug.DrawLine(new Vector3(boundaryMin.x, boundaryMin.y, 0), 
            new Vector3(boundaryMax.x, boundaryMin.y, 0), Color.green, duration);

        Debug.DrawLine(new Vector3(boundaryMax.x, boundaryMin.y, 0), 
            new Vector3(boundaryMax.x, boundaryMax.y, 0), Color.green, duration);

        Debug.DrawLine(new Vector3(boundaryMax.x, boundaryMax.y, 0), 
            new Vector3(boundaryMin.x, boundaryMax.y, 0), Color.green, duration);

        Debug.DrawLine(new Vector3(boundaryMin.x, boundaryMax.y, 0), 
            new Vector3(boundaryMin.x, boundaryMin.y, 0), Color.green, duration);
    }
    #endregion // Boundaries
}
