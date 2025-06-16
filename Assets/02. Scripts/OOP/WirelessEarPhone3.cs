using UnityEngine;

public class WirelessEarPhone3 : WirelessEarPhone2
{
    public enum NoiseCancelType {Off, On, Around}
    public NoiseCancelType noiseCancelType;

    private void Start()
    {
        name = "AirPod3";
        price = 100f;
        releaseYear = 2007;
        batterySize = 70f;
    }
    public void SetNoisCancelType(NoiseCancelType type)
    {
        noiseCancelType = type;
    }

    public override void NoiseCancelling()
    {
        SetNoisCancelType(noiseCancelType);
        
        base.NoiseCancelling();
    }
}