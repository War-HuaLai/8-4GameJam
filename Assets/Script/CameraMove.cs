using System.Collections;
using System.Threading;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;

    public float deltaDis = 5;

    public float cameraTransTime = 1f;

    private bool isMove=false;

    private Vector3 movement;
    float timecount = 0f;


    private void Update()
    {
        if (player.position.y > transform.position.y + deltaDis)
        {
            if (!isMove)
            {
                isMove = true;
                movement = new Vector3(0, 2*deltaDis, 0);
                //StartCoroutine(TimeCount(movement));
            }

        }
        else if (player.position.y < transform.position.y - deltaDis)
        {
            if (!isMove)
            {
                isMove = true;
                movement = new Vector3(0, -2*deltaDis, 0);
                //;StartCoroutine(TimeCount(movement));
            }

            //transform.position -= new Vector3(0, deltaDis, 0);
        }
        if(isMove) {
            if (timecount < cameraTransTime)
            {
                transform.position += Vector3.Lerp(Vector3.zero, movement, Time.deltaTime / cameraTransTime);
                timecount += Time.deltaTime;
            }
            else
            {
                isMove = false;
                timecount = 0f;

            }

        }
    }


    IEnumerator TimeCount(Vector3 moveMent)
    {
        float timecount = 0f;
        while (timecount < cameraTransTime)
        {
            transform.position += Vector3.Lerp(Vector3.zero, moveMent, Time.deltaTime/ cameraTransTime);
            timecount += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        isMove=false;
    }
}
