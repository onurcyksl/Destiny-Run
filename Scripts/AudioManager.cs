using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    
    public AudioSource AudioMan;
    [SerializeField] Toggle audioToggle;

    // Start is called before the first frame update
    void Start()
    {
        if(AudioListener.volume == 0)
        {
            audioToggle.isOn = false;
        }
   
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void ChangeAudiMan(AudioClip music)
    {
        AudioMan.Stop();
        AudioMan.clip = music;
        AudioMan.Play();
    }
}
