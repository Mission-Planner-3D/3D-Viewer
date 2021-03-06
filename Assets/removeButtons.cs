﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class removeButtons : MonoBehaviour
{
    public Button delete, move, up, down, altitude, command;
    public InputField altInput;
    public Renderer sphereRender;
    private Waypoints waypoints;
    public Command rcommand;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = (Waypoints)FindObjectOfType(typeof(Waypoints));
        rcommand = (Command)FindObjectOfType(typeof(Command));
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0) && !CheckUIHover.BlockedByUI)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (!spawnUI.onSphere)
        //    {
        //        add.transform.position = new Vector3(-1000, 0, 0);
        //        move.transform.position = new Vector3(-1000, 0, 0);
        //        up.transform.position = new Vector3(-1000, 0, 0);
        //        down.transform.position = new Vector3(-1000, 0, 0);
        //        if (spawnUI.selectedSphere != null)
        //        {
        //            sphereRender = spawnUI.selectedSphere.GetComponent(typeof(Renderer)) as Renderer;
        //            sphereRender.material.color = Color.white;
        //        }
        //    }
        //}
    }

    public void removeUI()
    {
        Debug.Log("remove called");
        delete.transform.position = new Vector3(-1000, 0, 0);
        command.transform.position = new Vector3(-1000, 0, 0);
        move.transform.position = new Vector3(-1000, 0, 0);
        up.transform.position = new Vector3(-1000, 0, 0);
        down.transform.position = new Vector3(-1000, 0, 0);
        altitude.transform.position = new Vector3(-1000, 0, 0);
        altInput.transform.position = new Vector3(-1000, 0, 0);
        rcommand.cleanUpCommandUI();
    }

    public void resetSphereStatus()
    {
        if (spawnUI.selectedWaypoint != null)
        {
            sphereRender = spawnUI.selectedWaypoint.getGameObject().GetComponent(typeof(Renderer)) as Renderer;
            sphereRender.material.color = Color.white;
            spawnUI.selectedWaypoint = null;
            spawnUI.selectedSphere = null;
            Waypoints.moveFlag = false;
            Waypoints.addFlag = true;
            Waypoints.insertFlag = false;
        }
    }
}
