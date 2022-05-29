using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private TimeAndScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<TimeAndScoreManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LowScoreArea"))
        {
            if (collision.gameObject.GetComponent<ThrowStuff>().canIncreasePoints == true)
            {
                collision.gameObject.GetComponent<ThrowStuff>().canIncreasePoints = false;
                if (_scoreManager != null)
                    _scoreManager.IncreaseScore(1);
            }
        }
    }
}
