using System;
using System.Collections;
using UnityEngine;

public class InterationEvent : MonoBehaviour
{
    public enum InterationType {Sign, Door, NPC}
    public InterationType type;

    public SoundController soundController;

    public FadePanel fade;

    public GameObject popup;
    public GameObject map;
    public GameObject house;

    public Vector3 inDoorPos;
    public Vector3 outDoorPos;
    public bool isHouse;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Interation(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            popup.SetActive(false);
        }
    }

    private void Interation(Transform player)
    {
        switch (type)
        {
            case InterationType.Sign :
                popup.SetActive(true);
                break;
            case InterationType.Door :
                StartCoroutine(DoorRoutine(player));
                break;
            case InterationType.NPC :
                popup.SetActive(true);
                break;
        }
    }

    private IEnumerator DoorRoutine(Transform player)
    {
        soundController.EventSoundPlay("Open Door");
        soundController.BgmSoundPlay("House In");
        yield return StartCoroutine(fade.Fade(3f, Color.black, true));

        map.SetActive(isHouse);
        house.SetActive(!isHouse);

        var pos = isHouse ? outDoorPos : inDoorPos;
        player.transform.position = pos;

        isHouse = !isHouse;

        yield return new WaitForSeconds(1f);
        soundController.EventSoundPlay("Close Door");
        yield return StartCoroutine(fade.Fade(3f, Color.black, false));
    }
}
