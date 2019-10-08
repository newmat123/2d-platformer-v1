﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class cameraFollower : MonoBehaviour
{

    public List<Transform> targets; //holder alle spillere

    public Vector3 offset; //hvor langt tilbage kameraet skal være
    public float smotheTime = .5f;//den hastighed kameraet rykker sig med

    public float minzoom = 10f; // max og min kameraet skal kunne zoome
    public float maxzoom = 5f;
    public float ZoomLimiter = 50f;


    private Vector3 velocity;

    private Camera cam; //holder selve kameraet


    private void Start()
    {
        cam = GetComponent<Camera>();//finder kameraet
    }

    public void LateUpdate()
    {

        if(targets.Count == 0)
        {
            //hvis der ikke er nogle spillere, stopper den her
            return;
        }
        //ellers kører den de følgende funktioner
        move();
        zoom();

    }

    public void zoom()
    {

        //cheker hvad der har den største værdi højden eller længden mellem spillerne
        if(GetGreatestDis() < GetGreatestHight())
        {

            //newzoomH defineres her 
            float newZoomH = Mathf.Lerp(maxzoom, minzoom, GetGreatestHight() / ZoomLimiter);
            //her bliver kameraets størelse sat(fra , til og hvor hurtigt)
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoomH, Time.deltaTime);

        }
        else
        {

            //newzoom defineres her
            float newZoom = Mathf.Lerp(maxzoom, minzoom, GetGreatestDis() / ZoomLimiter);
            //her bliver kameraets størelse sat(fra , til og hvor hurtigt)
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);

        }

    }

    public void move()
    {
        //finder ud af hvor kameraets center skal være
        Vector3 centerpoint = GetCenterPoint();

        //lægger offsetet til kameraet ikke er i samme lag som spilerene
        Vector3 newpos = centerpoint + offset;

        //flytter kameraet til det nye punkt
        transform.position = Vector3.SmoothDamp(transform.position, newpos, ref velocity, smotheTime);

    }

    //floaten GetGreatestDis bliver defineret her
    float GetGreatestDis()
    {

        //her laver vi en bunke af alle de spillere der er, hvor den første har position 0
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for(int i = 0; i < targets.Count; i++)
        {
            //her adder vi alle spilerenes positioner til bunken
            bounds.Encapsulate(targets[i].position);

        }

        //returner distancen mellem de spillere der er længst fra hinanden.
        return bounds.size.x;

    }

    float GetGreatestHight()
    {

        //her laver vi en bunke af alle de spillere der er, hvor den første har position 0
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            //her adder vi alle spilerenes positioner til bunken
            bounds.Encapsulate(targets[i].position);

        }

        //returner distancen mellem de spillere der er længst fra hinanden.
        return bounds.size.y * 3;

    }

    //vectoren GetCenterPoint bliver defineret her
    Vector3 GetCenterPoint()
    {
        //chekker om der er flere en bare en spiller
        if(targets.Count == 1)
        {
            //hvis ja, bliver den ene spilers position retuneret
            return targets[0].position;

        }

        //ellers laver vi en bunke, hvor den første har en vector 0
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for(int i = 0; i < targets.Count; i++)
        {
            //her adder vi alle spilerenes positioner til bunken
            bounds.Encapsulate(targets[i].position);
        }

        //retunere centrum af alle spilere.
        return bounds.center;

    }

}