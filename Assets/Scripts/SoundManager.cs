using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    
    private GameObject[] soundSource_gm;
    public Sound[] sounds;
    

    private void Awake() 
    {
        #region Singleton
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
                DontDestroyOnLoad(Instance);
            } 
        

        #endregion
        
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        }
        
    }


    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && sounds[1].source.mute)
        {
            sounds[1].source.mute=false;
            Debug.Log("muted");
        }

    }


    public void s1()
    {
        playSound("1");
    }
    public void s2()
    {
        playSound("2");
    }
    public void s3()
    {
        playSound("3");
    }
    
    
    
    public void playSound(string _sound)
    { 
            Sound s = Array.Find(sounds, sound => _sound == sound.soundname);
            switch (_sound)
            {
                case "coin":
                    s.source.time = 0.5f;
                    s.source.Play();
                    s.source.SetScheduledEndTime(AudioSettings.dspTime + (1.3f - 0.5f));
                    break;

                case "1":
                    s.source.Play();
                    break;
                case "2":
                    s.source.Play();
                    break;
                case "3":
                    s.source.Play();
                    break;
                case "dream":
                    s.source.Play();
                    s.source.loop = true;
                    break;
                case "ilkay":
                    s.source.Play();
                    break;
                case "yaren":
                    s.source.Play();
                    break;
            }
            
    }

    public void muteAll()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.mute=true;
        }
    }
    
    

}
