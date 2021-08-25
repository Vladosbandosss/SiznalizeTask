using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefCheck : MonoBehaviour
{
    AudioSource _alarmSound;

    private Coroutine _musicPlay;

    private float _musicVolume;
    private int _lowAlarmSteps = 4;
    private float _maxVolume = 1f;
    private float _changeVolumeSize = 0.2f;
 
    private void Start()
    {
        _musicVolume = 0f;
        _alarmSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("ишгнрок вошел");
           _musicPlay =  StartCoroutine(CallingRing());
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("игрок вышел");
            StopCoroutine(_musicPlay);
        }
    }

    private IEnumerator CallingRing()
    {
           
        for (int i = 0; i < int.MaxValue; i++)
        {
            _alarmSound.volume = _musicVolume;
            _alarmSound.Play();
            Debug.Log("работаю");

            yield return new WaitForSeconds(1f);

            _musicVolume += _changeVolumeSize;

            if (_musicVolume >= _maxVolume)
            {
                for (int j = 0; j < _lowAlarmSteps; j++)
                {
                    LowerAlarm();

                    yield return new WaitForSeconds(1f);
                }
            }
        }
            
         

    }

    private void LowerAlarm()
    {
        _musicVolume -= _changeVolumeSize;
        _alarmSound.volume = _musicVolume;
        _alarmSound.Play();
    }
}
