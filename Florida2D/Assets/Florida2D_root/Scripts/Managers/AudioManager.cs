using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] music;


    AudioSource audioManager;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectMusic(int indice)
    {


        audioManager.PlayOneShot(music[indice]);
        

    }


}
