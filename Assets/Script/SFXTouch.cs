using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTouch : MonoBehaviour
{
    public string SfxName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManger.Instance.PlaySFX(SfxName);
    }
}
