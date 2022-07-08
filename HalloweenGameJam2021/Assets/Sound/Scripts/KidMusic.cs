using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMusic : MonoBehaviour
{
    public FMODUnity.EventReference KidMusicRef;
    private FMOD.Studio.EventInstance KidMusicInst;
    FMOD.Studio.PLAYBACK_STATE pbState;
    void Start()
    {
        KidMusicInst = FMODUnity.RuntimeManager.CreateInstance(KidMusicRef);
        KidMusicInst.getPlaybackState(out pbState);
        if (pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            KidMusicInst.start();
        }


    }

    // Update is called once per frame
    void Update()
    {
        KidMusicInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }
}
