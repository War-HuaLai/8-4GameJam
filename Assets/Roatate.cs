using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roatate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;
    private Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-transform.forward,Time.deltaTime*rotateSpeed);
    }
}
