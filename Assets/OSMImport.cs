using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;

public class OSMImport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test start?");
        string target = "https://api.openstreetmap.org/api/0.6/map?bbox=-117.172,46.728,-117.166,46.732";
        string fileName = "pullman.osm";
        GetFileViaHttp(target, fileName);
        Debug.Log("Test complete?");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetFileViaHttp(string url, string fileName)
    {
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(url, fileName);
        }
    }
}
