using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager;
    public GameObject placementIndicator;
    public GameObject placeButton;
    public GameObject objectToBePlaced;
    
    private Pose PlacementPose;
    private bool placementPoseIsValid = false;
    private GameObject _spawnedObject;


    private void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits,TrackableType.Planes);
        if (hits.Count > 0)
        {
            placementIndicator.transform.position = hits[0].pose.position;
            placementIndicator.transform.rotation = hits[0].pose.rotation;
            placeButton.SetActive(true);
        }
        else
        {
            placeButton.SetActive(false);
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    void UpdatePlacementIndicator()
    {
        if (_spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
            PlacementPose = hits[0].pose;
    
    }

    private void PlaceObject()
    {
        _spawnedObject = Instantiate(objectToBePlaced, PlacementPose.position, PlacementPose.rotation );
    }
}
