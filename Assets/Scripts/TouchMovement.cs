using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    Transform transform;
    Vector3 move = Vector3.zero;
    SpawnObject spawnObject;
    bool transformAssigned = false ; 
    // Start is called before the first frame update
    void Start()
    {
        spawnObject = GetComponent<SpawnObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnObject.canSpawn == false)
        {
            if (!transformAssigned)
            {
                GameObject newObject = GameObject.FindGameObjectWithTag("Tank"); //..GetComponent<Transform>();
                if(newObject != null)
                {
                    transform = newObject.GetComponent<Transform>();
                    transformAssigned = true;
                }
                else
                {
                    print("cant find object");
                }
            }
            else
                transform.position += move / 100;
        }
            
        move = Vector3.zero;
    }

    public void moveRight()
    {
        move = Vector3.right;
    }

    public void moveLeft()
    {
        move = Vector3.left;
    }

    public void moveFront()
    {
        move = Vector3.forward;
    }

    public void moveBack()
    {
        move = Vector3.back;
    }
}
