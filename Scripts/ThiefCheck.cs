using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefCheck : MonoBehaviour
{
    AudioSource _alarmSound;

    private Coroutine musicPaly;

    private float _voll;
    private int lowAlarmSteps = 4;
    private float _maxVolume = 1f;
    private float _changeVolumeSize = 0.2f;
 
    private void Start()
    {
        _voll = 0f;
        _alarmSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("ишгнрок вошел");
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

    private IEnumerator CallingRing()
    {
           
        for (int i = 0; i < int.MaxValue; i++)
        {
            _alarmSound.volume = _voll;
            _alarmSound.Play();
            Debug.Log("работаю");

            yield return new WaitForSeconds(1f);

            _voll += _changeVolumeSize;

            if (_voll >= _maxVolume)
            {
                for (int j = 0; j < lowAlarmSteps; j++)
                {
                    LowerAlarm();

                    yield return new WaitForSeconds(1f);
                }
            }
        }
            
         

    }

    private void LowerAlarm()
    {
        _voll -= _changeVolumeSize;
        _alarmSound.volume = _voll;
        _alarmSound.Play();
    }
}
