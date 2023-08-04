using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roatate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;
    private Transform transform;
    private SpriteRenderer _sp;
    [SerializeField]Sprite _face;
    [SerializeField] Sprite _faceNormal;
    private void Awake()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-transform.forward,Time.deltaTime*rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _sp.sprite = _face;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _sp.sprite = _faceNormal;
        }
    }
}
