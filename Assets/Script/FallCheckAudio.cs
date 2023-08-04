using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheckAudio : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    private float fallTime=0f;
    public float FallTimePlay = 5;
    public string MusicName;

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            fallTime += Time.deltaTime;
            if (fallTime > FallTimePlay)
            {
                AudioManger.Instance.PlaySFX(MusicName);
                fallTime = 0f;
            }
        }
        else
        {
            fallTime = 0;
        }
    }
}
