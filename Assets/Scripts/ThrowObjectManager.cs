using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjectManager : MonoBehaviour
{
    public GameObject objectToSpawn_1;
    public GameObject objectToSpawn_2;
    private GameObject throwAbleObject;
    public GameObject ArCamera;

    private TimeAndScoreManager _scoreManager;

    public bool canThrow = false;

    // Update is called once per frame
    void Update()
    {
        // if(canThrow)
        _scoreManager = GetComponent<TimeAndScoreManager>();

    }

    public void InstantiateTrash()
    {
        float randomNum = Random.Range(0, 10);
        if (randomNum > 3)
            throwAbleObject = Instantiate(objectToSpawn_2, ArCamera.transform);
        else
            throwAbleObject = Instantiate(objectToSpawn_1, ArCamera.transform);

        throwAbleObject.transform.position = ArCamera.transform.position + new Vector3(0, -0.75f, 0.5f);
        if (_scoreManager != null)
            _scoreManager.StartTime();
    }
}
