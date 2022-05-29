using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionInnerPart : MonoBehaviour
{
    private TimeAndScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<TimeAndScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LowScoreArea"))
        {
            if (other.GetComponent<ThrowStuff>().canIncreasePoints_Inner == true)
            {
                other.GetComponent<ThrowStuff>().canIncreasePoints_Inner = false;
                if (_scoreManager != null)
                    _scoreManager.IncreaseScore(4);
            }
        }
    }
}
