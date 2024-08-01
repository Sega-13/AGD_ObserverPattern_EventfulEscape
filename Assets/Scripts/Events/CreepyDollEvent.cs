using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyDollEvent : MonoBehaviour
{
    [SerializeField] private int keysRequiredToTrigger;
    [SerializeField] private DollView doll;
    [SerializeField] private SoundType soundToPlay;
    [SerializeField] private Transform target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null && GameService.Instance.GetPlayerController().KeysEquipped == keysRequiredToTrigger)
        {
            doll.SetPose(new Pose(target.position, target.rotation));
            doll.Show();
            EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
            EventService.Instance.OnDollAppear.InvokeEvent();
            GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
            GetComponent<Collider>().enabled = false;
        }
    }
}
