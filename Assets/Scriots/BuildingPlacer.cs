using babu;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public GameObject buildingPrefab;

    private GameObject previewObj;

    private Building buildingData;

    private BuildingPreview previewScript;

    public void StarBuilding(int buildingSize)
    {
        previewObj = Instantiate(buildingPrefab);
        buildingData = previewObj.GetComponent<Building>();
        buildingData.SetBuildingSize(buildingSize);
        previewScript = previewObj.AddComponent<BuildingPreview>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StarBuilding(1);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StarBuilding(2);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StarBuilding(3);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StarBuilding(4);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }




        if (GameManager.Instance.isBuilding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("floor")))
            {
                Vector3 hitPoint = hit.point;
                Vector2Int gridPos = new Vector2Int(Mathf.FloorToInt(hitPoint.x), Mathf.FloorToInt(hitPoint.z));
                Vector3 displayPos = new Vector3(gridPos.x + buildingData.size.x /2f, 1, gridPos.y + buildingData.size.y / 2f);
                previewObj.transform.position = displayPos;

                bool canPlace = GameManager.Instance.IsAreaFree(gridPos, buildingData.size);
                previewScript.SetColor(canPlace ? Color.green : Color.red);
                //true = green    false = red

                if (Input.GetMouseButtonDown(0) && canPlace)
                {
                    PlaceBuilding(gridPos);
                }
            }
        }



        void PlaceBuilding(Vector2Int gridPos)
        {
            Vector3 spawnPos = new Vector3(gridPos.x + buildingData.size.x /2f, 1, gridPos.y + buildingData.size.y /2f);
            GameObject createBuilding = Instantiate(buildingPrefab, spawnPos, Quaternion.identity);
            createBuilding.transform.name = "CreateBuilding";
            createBuilding.GetComponent<Building>().SetBuildingSize(buildingData.size.x);
            GameManager.Instance.OccupyArea(gridPos, buildingData.size);
        }

    }
}
