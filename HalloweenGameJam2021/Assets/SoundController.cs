using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public FMODUnity.EventReference CheckpointRef;
    private FMOD.Studio.EventInstance CheckpointInst;

    //public FMODUnity.EventReference DashRef;
    //private FMOD.Studio.EventInstance DashInst;

    public FMODUnity.EventReference DeathRef;
    private FMOD.Studio.EventInstance DeathInst;

    public FMODUnity.EventReference PickupCardRef;
    private FMOD.Studio.EventInstance PickupCardInst;

    public FMODUnity.EventReference ReviveRef;
    private FMOD.Studio.EventInstance ReviveInst;

    public FMODUnity.EventReference PauseAudioRef;
    private FMOD.Studio.EventInstance PauseAudioInst;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChekpointAudio()
    {
        CheckpointInst = FMODUnity.RuntimeManager.CreateInstance(CheckpointRef);
        CheckpointInst.start();
        CheckpointInst.release();
    }
    //public void DashAudio()
    //{
        //DashInst = FMODUnity.RuntimeManager.CreateInstance(DashRef);
       // DashInst.start();
       // DashInst.release();

    //}
    public void DeathAudio()
    {
        DeathInst = FMODUnity.RuntimeManager.CreateInstance(DeathRef);
        DeathInst.start();
        DeathInst.release();
    }
    public void CardCollectAudio()
    {
        PickupCardInst = FMODUnity.RuntimeManager.CreateInstance(PickupCardRef);
        PickupCardInst.start();
        PickupCardInst.release();

    }
    public void ReviveAudio()
    {
        ReviveInst = FMODUnity.RuntimeManager.CreateInstance(ReviveRef);
        ReviveInst.start();
        ReviveInst.release();
    }
    public void PauseAudio()
    {
        PauseAudioInst = FMODUnity.RuntimeManager.CreateInstance(PauseAudioRef);
        PauseAudioInst.start();
    }
    public void PauseAudioStop()
    {
        PauseAudioInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
