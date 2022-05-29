using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStepManager : MonoBehaviour
{

    public GameObject Step1_Panel;
    public GameObject Step2_Panel;

    public SpawnObject spawnObject;
    public ThrowObjectManager throwObjectManager;


    // Start is called before the first frame update
    void Awake()
    {
        StartStepOne();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartStepOne()
    {
        //Step1_Panel.SetActive(true);      in SpawnObject Script
        spawnObject.InstantiateReticle();
        spawnObject.canSpawn = true;
    }

    public void EndStepOne()
    {
        Step1_Panel.SetActive(false);
        StartStepTwo();
    }

    public void StartStepTwo()
    {
        Step2_Panel.SetActive(true);

    }

    public void EndStepTwo()
    {

    }
}
