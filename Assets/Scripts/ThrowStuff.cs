using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStuff : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 startPoint;
    Vector3 endPoint;

    Vector3 forceDir;
    private Transform parent;
    private bool canAddForce= true;

    public float time;
    public float timeEnd;
    public float forceValue;
    public float forceMin = 4;
    public bool canIncreasePoints = true;
    public bool canIncreasePoints_Inner = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Input.touchCount >= 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startPoint = Input.mousePosition;
                time = 0;
            }

            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                if(gameObject.transform.parent != null)
                    throwItem();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Input.mousePosition;
            time = 0;
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            throwItem();
        }
    }

    void throwItem()
    {
        timeEnd = time;
        endPoint = Input.mousePosition;
        forceDir = endPoint - startPoint;
        forceDir = forceDir.normalized;
        forceDir.z = forceDir.y * 0.75f;
        forceDir.y += Mathf.Clamp(timeEnd, 0, 0.5f);

        forceValue = forceMin * timeEnd;
        
        forceValue = Mathf.Clamp(forceValue, 0, 3);
        if(canAddForce)
            rb.AddForce(forceDir * forceValue, ForceMode.Impulse);
        canAddForce = false; 
        rb.useGravity = true;
        parent = gameObject.transform.parent;
        gameObject.transform.parent = null;
        Destroy(gameObject,3f);
    }
}
