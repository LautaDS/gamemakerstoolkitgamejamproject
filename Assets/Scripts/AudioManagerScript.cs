using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip boton,encontra,mover,winwin,grunt,agarrar,agarrar2,slimejump;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        boton = Resources.Load<AudioClip> ("boton");
        encontra = Resources.Load<AudioClip> ("encontra");
        mover = Resources.Load<AudioClip> ("mover");
        winwin= Resources.Load<AudioClip> ("Ganaste rey");
        grunt = Resources.Load<AudioClip> ("Grunt 2");
        agarrar = Resources.Load<AudioClip> ("Pluck 1");
        agarrar2 = Resources.Load<AudioClip> ("Pluck 2");
        slimejump = Resources.Load<AudioClip> ("Salto slime");

      audioSrc= GetComponent<AudioSource>();

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
        case "boton":
            audioSrc.PlayOneShot(boton);
            break;
        case "encontra":
            audioSrc.PlayOneShot(encontra);
            break;
        case "mover":
            audioSrc.PlayOneShot(mover);
            break;
        case "winwin":
            audioSrc.PlayOneShot(winwin);
            break;
         case "grunt":
            audioSrc.PlayOneShot(grunt);
            break;
        case "agarrar":
            audioSrc.PlayOneShot(agarrar);
            break;
        case "agarrar2":
            audioSrc.PlayOneShot(agarrar2);
            break;
        case "slimejump":
            audioSrc.PlayOneShot(slimejump);
            break;
        }
    }


}
