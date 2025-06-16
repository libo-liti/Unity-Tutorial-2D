using UnityEngine;

public class WirelessEarPhone2 : WirelessEarPhone
{
    public bool isNoiseCancelling;
    
    private void Start()
    {
        name = "AirPod2";
        price = 100f;
        releaseYear = 2007;
        batterySize = 70f;
    }
    
    public virtual void NoiseCancelling()
    {
        isNoiseCancelling = !isNoiseCancelling;

        string msg = isNoiseCancelling ? "노이즈 캔슬링 On" : "노이즈 캔슬링 off";
        Debug.Log(msg);
    }
}