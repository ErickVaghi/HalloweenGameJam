using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public FMODUnity.EventReference MusicRef;
    private FMOD.Studio.EventInstance MusicInst;
    FMOD.Studio.PLAYBACK_STATE pbState;

    void Start()
    {
        MusicInst = FMODUnity.RuntimeManager.CreateInstance(MusicRef);
        DontDestroyOnLoad(this.gameObject);
        MusicInst.getPlaybackState(out pbState);
        if (pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            playMusic();
            Debug.Log("startMusic");
        }
        else
        {

        }

    }

    // Update is called once per frame
    void Update()
    {

        //MusicInst.getPlaybackState(out pbState);
        //if (pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        // {

        // MusicInst.start();
        // }
        // else
        // {


        // }
    }

    public void changeMusicProgress(int _val)
    {

     // MusicInst.setParameterByName("MusicProgress", _val);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicProgress", _val); //Changed to global parameters in fmod

    }
    public void playMusic()
    {
        MusicInst.start();

    }

}
