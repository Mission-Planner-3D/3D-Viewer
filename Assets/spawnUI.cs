﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnUI : MonoBehaviour
{
    public Button deleteButton, moveButton, addButton;
    public bool deleteInScreen;
    public static Transform selectedSphere;
    public static bool movingSphere;
    
    // Start is called before the first frame update
    void Start()
    {
        deleteInScreen = false
        movingSphere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !CheckUIHover.BlockedByUI)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Sphere")
                {
                    selectedSphere = hit.transform;
                    deleteInScreen = true;
                    Debug.Log("My object is clicked by mouse");
                    deleteButton.transform.position = new Vector3(Input.mousePosition.x - 50, Input.mousePosition.y, 0);
                    moveButton.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y + 50, 0);
                    addButton.transform.position = new Vector3(Input.mousePosition.x + 50, Input.mousePosition.y, 0);
                    movingSphere = false;
                }
                else
                {
                    deleteButton.transform.position = new Vector3(-1000, 0, 0);
                    deleteInScreen = false;
                    moveButton.transform.position = new Vector3(-1000, 0, 0);
                    addButton.transform.position = new Vector3(-1000, 0, 0);
                    movingSphere = false;
                }
            }
            else
            {
                deleteButton.transform.position = new Vector3(-1000, 0, 0);
                deleteInScreen = false;
                moveButton.transform.position = new Vector3(-1000, 0, 0);
                addButton.transform.position = new Vector3(-1000, 0, 0);
                movingSphere = false;
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
        {
            movingSphere = true;
        }
    }
}