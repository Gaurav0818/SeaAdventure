using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnObject : MonoBehaviour
{
    
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public GameObject objectToSpawn;
    public GameObject moveIcon;
    public GameObject spawnButton;

    private GameObject _spawnedGameObject;
    public GameObject reticalePrefab;
    private GameObject _reticale;


    private Vector2 screenPoint;
    //private bool objectSelected = false;

    public bool canSpawn = false;
    private bool spawnButtonPressed = false;

    private void Start()
    {
        
    }


    void Update()
    {
        if (canSpawn)
        {
            screenPoint = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(screenPoint, hits, TrackableType.Planes);

            if (hits.Count > 0)
            {
                _reticale.SetActive(true);
                moveIcon.SetActive(false);
                spawnButton.SetActive(true);
                _reticale.transform.position = hits[0].pose.position;
                _reticale.transform.rotation = hits[0].pose.rotation;
            }
            else
                _reticale.SetActive(false);

            if (spawnButtonPressed && _spawnedGameObject == null)
                InstantiatePrefab();
        }
    }

    private void InstantiatePrefab()
    {
        canSpawn = false;
        _spawnedGameObject = Instantiate(objectToSpawn, _reticale.transform.position, _reticale.transform.rotation);
        _reticale.SetActive(false);

        GetComponent<GameStepManager>().StartStepTwo(); 
    }

    public void InstantiateReticle()
    {
        if(_reticale == null)   _reticale = Instantiate(reticalePrefab, transform);
        else    _reticale.SetActive(true);
    }

    public void SpawnPrefab()
    {
        spawnButtonPressed = true;
    }

    private void MovePrefab()
    {
        _spawnedGameObject.SetActive(true);
        _spawnedGameObject.transform.position = _reticale.transform.position;
        _spawnedGameObject.transform.rotation = _reticale.transform.rotation;
    }

}
