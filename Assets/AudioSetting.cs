using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{
  FMOD.Studio.EventInstance SFXVolumeTestEvent;
  FMOD.Studio.Bus Master;
  float MasterVolume = 1f;

  void Awake () 
  {
      Master = FMODUnity.RuntimeManager.GetBus ( "bus:/Master");
  }

  void Update () 
  {
      Master.setVolume (MasterVolume);
  }

  public void MasterVolumeLevel (float newMasterVolume)
  {
      MasterVolume = newMasterVolume; 
  }
  
}
