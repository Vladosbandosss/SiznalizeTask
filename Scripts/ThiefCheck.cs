using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefCheck : MonoBehaviour
{
     AudioSource myfx;
    Coroutine musicPaly;
    private float _minVolume = 1f;
    private float _changeVolumeSize = 0.2f;
 
    private void Start()
    {
        myfx = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
           musicPaly =  StartCoroutine(CallingRing());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("игрок вышел");
            StopCoroutine(musicPaly);
        }
    }
    IEnumerator CallingRing()
    {
        float voll = 0f;
        for (int i = 0; i < int.MaxValue; i++)
        {
            myfx.volume = voll;
            myfx.Play();
            
            yield return new WaitForSeconds(1f);

            if (voll >= _minVolume)
            {
                voll = 0f;
            }

            if (voll< _minVolume)
            {
                voll += _changeVolumeSize;
            }
            
        }

    }

}
