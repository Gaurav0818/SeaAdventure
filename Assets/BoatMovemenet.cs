using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class BoatMovemenet : MonoBehaviour
{

    public ARRaycastManager raycastManager;
    public GameObject arCamera;
    public Transform Ship;
    InputControls control;
    CharacterController characterController;

    public float speed = 1;
    int horizontal;
    int vertical;
    bool movePressed;
    Vector2 moveValue;
    Vector2 moveDir;
    float angle;
    int dirMulti = 1;
    Vector2 screenPoint;
    bool forwardFound = false;

    Vector3 FrontDir;

    #region - Awake / OnEnable / OnDisable - 

    private void Awake()
    {
        control = new InputControls();

        control.Gameplay.Move.performed += ctx => //print(ctx.ReadValue<Vector2>());
        {
            moveValue = ctx.ReadValue<Vector2>();
            movePressed = true;
                
        };
        control.Gameplay.Move.canceled += ctx => movePressed = false;

        raycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
        arCamera = GameObject.Find("AR Camera");

    }

    private void OnEnable()
    {
        control.Gameplay.Enable();
    }    
    
    private void OnDisable()
    {
        control.Gameplay.Disable();
    }


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        FrontDir = transform.forward;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!movePressed) moveValue = Vector2.zero;
        else
        {
            if(!forwardFound)
                getForwordDir();

            move();
        }
        print(moveValue);
    }

    void getForwordDir()
    {
        screenPoint = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPoint, hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            FrontDir = hits[0].pose.position;
            forwardFound = true;

        }
        FrontDir *= 1000; 
    }

    void move()
    {
        //if (Vector3.Dot(FrontDir, transform.forward) >= 0)
        //            dirMulti = -1;
        //        else
        //            dirMulti = 1;
        //        
        //angle = Vector3.Angle(FrontDir, transform.forward) * dirMulti;
//
        //moveDir.x = moveValue.x * Mathf.Cos(angle / 180 * Mathf.PI) - moveValue.y * Mathf.Sin(angle / 180 * Mathf.PI);
        //moveDir.y = moveValue.x * Mathf.Sin(angle / 180 * Mathf.PI) + moveValue.y * Mathf.Cos(angle / 180 * Mathf.PI);
        //moveDir.Normalize();
        //transform.LookAt(transform.position + new Vector3(moveDir.x, 0, moveDir.y));
        //transform.position = transform.position + new Vector3(moveDir.x, 0, moveDir.y) * Time.deltaTime * speed;
        transform.LookAt(FrontDir);
        Ship.LookAt(transform.localPosition + new Vector3(moveValue.x, 0, moveValue.y));
        transform.localPosition = transform.localPosition + new Vector3(moveValue.x, 0, moveValue.y) * Time.deltaTime * speed;
    }

}
