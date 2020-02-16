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

  public void SoundButtonTrigger()
  {
        
            FMODUnity.RuntimeManager.PlayOneShot("event:/Menue/Cracking2", GetComponent<Transform>().position);
        
  }
public void SoundButtonClic()
{

    FMODUnity.RuntimeManager.PlayOneShot("event:/Menue/WooshClic", GetComponent<Transform>().position);

}
public void StrixWalking()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/Strix/StrixWalking", GetComponent<Transform>().position);

    }
 public void StrixDig()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/Strix/StrixGratte", GetComponent<Transform>().position);

    }
public void StrixSniff()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/Strix/StrixSnif", GetComponent<Transform>().position);

    }
public void StrixJump()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/Strix/StrixJump", GetComponent<Transform>().position);

    }
    public void DotsWalking()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/Dots/DotsWalking", GetComponent<Transform>().position);

    }
    public void DotsJump()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/Dots/Dots jump", GetComponent<Transform>().position);

    }
    public void DotsBec()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/Dots/DotsBec", GetComponent<Transform>().position);

    }
    public void DotsSing()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/Dots/DotsSing", GetComponent<Transform>().position);

    }
    public void FallingTree()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/FallingTree", GetComponent<Transform>().position);

    }
    public void BoomingTree()
    {

        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/BoomingTree", GetComponent<Transform>().position);

    }
}
