using UnityEngine;

public class PotionView : MonoBehaviour, IInteractable
{
    [SerializeField] SoundType soundType;
    private int potionEffect = 20;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerView>() != null)
        {
            EventService.Instance.OnPotionDrink.InvokeEvent(potionEffect);
        }
    }
    public void Interact()
    {
        GameService.Instance.GetInstructionView().HideInstruction();
        GameService.Instance.GetSoundView().PlaySoundEffects(soundType);
        gameObject.SetActive(false);
    }
}
