using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGAme : MonoBehaviour
{

    public static ManageGAme Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public int count = 0;
    
    
    void Update()
    {
        
        if(count>8)
        {
            SceneManager.LoadScene(1);
        }
        
    }
    
    
}
