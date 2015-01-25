#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class AkMusicSettings : IDisposable {
  private IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkMusicSettings(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static IntPtr getCPtr(AkMusicSettings obj) {
    return (obj == null) ? IntPtr.Zero : obj.swigCPtr;
  }

  ~AkMusicSettings() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkMusicSettings(swigCPtr);
        }
        swigCPtr = IntPtr.Zero;
      }
      GC.SuppressFinalize(this);
    }
  }

  public float fStreamingLookAheadRatio {
    set {
      AkSoundEnginePINVOKE.CSharp_AkMusicSettings_fStreamingLookAheadRatio_set(swigCPtr, value);

    } 
    get {
      float ret = AkSoundEnginePINVOKE.CSharp_AkMusicSettings_fStreamingLookAheadRatio_get(swigCPtr);

      return ret;
    } 
  }

  public AkMusicSettings() : this(AkSoundEnginePINVOKE.CSharp_new_AkMusicSettings(), true) {

  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
