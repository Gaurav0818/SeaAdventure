using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMovement : MonoBehaviour
{
    public Transform transform;
    public Vector3 defaultPosition;
    public float speed;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        defaultPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;
        speed = Mathf.Sin(time)*35;
        transform.localPosition = defaultPosition + new Vector3( speed, 0, 0) ;
    }
}
