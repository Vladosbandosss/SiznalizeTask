using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefCheck : MonoBehaviour
{
    private AudioSource _alarmSound;
    private Coroutine musicPaly;

    private float _minVolume = 1f;
    private float _changeVolumeSize = 0.2f;
 
    private void Start()
    {
        _alarmSound = GetComponent<AudioSource>();
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
        
            _alarmSound.volume = voll;
            _alarmSound.Play();

            if (voll >= _minVolume)
            {
                voll = 0f;
            }

            if (voll < _minVolume)
            {
                voll += _changeVolumeSize;
            }

            yield return new WaitForSeconds(1f);

    }

}
