using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // public GameObject prefabToPlace;   // Assign your prefab in the inspector
    public List<BoxType> boxTypes; // List of box types with weights
    public GameObject boxesParent;    // Parent object for organization
    private GameObject currentObject;  // The currently instantiated object
    private bool isPlacing = false;

    private GameManager gameManager;
    private int totalWeight;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // Calculate total weight for random selection
        foreach (var boxType in boxTypes)
        {
            totalWeight += boxType.useWeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
      // Start placing when right mouse button is pressed (optional)
        if (Input.GetMouseButtonDown(1) && !isPlacing)
        {
            StartPlacing();
        }

        if (isPlacing && currentObject != null)
        {
            FollowMouse();

            // Drop object when left mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                DropObject();
            }
        }
    }

    GameObject GetRandomBoxPrefab()
    {
        int randomValue = Random.Range(0, totalWeight);
        int cumulativeWeight = 0;

        foreach (var boxType in boxTypes)
        {
            cumulativeWeight += boxType.useWeight;
            if (randomValue < cumulativeWeight)
            {
                return boxType.prefab;
            }
        }

        return boxTypes[0].prefab; // Fallback
    }

    void StartPlacing()
    {
        currentObject = Instantiate(GetRandomBoxPrefab(), boxesParent.transform);
        // disable rigidbody while placing
        currentObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameManager.AddBox();
        isPlacing = true;
    }

    void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Keep in 2D plane
        currentObject.transform.position = mousePosition;
    }

    void DropObject()
    {
        isPlacing = false;
        // enable rigidbody when dropped
        currentObject.GetComponent<Rigidbody2D>().isKinematic = false;
        currentObject = null;
    }
}
