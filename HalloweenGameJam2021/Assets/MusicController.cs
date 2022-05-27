using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public FMODUnity.EventReference MusicRef;
    private FMOD.Studio.EventInstance MusicInst;

    void Start()
    {
        playMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playMusic()
    {
        MusicInst = FMODUnity.RuntimeManager.CreateInstance(MusicRef);
        MusicInst.start();

    }
}
