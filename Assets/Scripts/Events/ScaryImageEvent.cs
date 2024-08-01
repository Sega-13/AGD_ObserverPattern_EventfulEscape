using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScaryImageEvent : MonoBehaviour
{
    [SerializeField] private ScaryImageView view;
    [SerializeField] private SoundType soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerView player))
        {
            onPlayerNear();
        }
    }

    private async void onPlayerNear()
    {
        view.Show();
        view.Play();
        GetComponent<Collider>().enabled = false;

        await Task.Delay(2000);
        EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
        EventService.Instance.OnScaryImage.InvokeEvent();
        GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
    }
}
