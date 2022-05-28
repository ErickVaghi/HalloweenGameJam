using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAudio : MonoBehaviour
{
    public FMODUnity.EventReference TrapRef;
    private FMOD.Studio.EventInstance TrapInst;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TrapInst.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        TrapInst = FMODUnity.RuntimeManager.CreateInstance(TrapRef);
        TrapInst.start();
        Debug.Log("StartTrapSound");

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        //TrapInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //TrapInst.release();
        Debug.Log("StopTrapSound");
    }
}
