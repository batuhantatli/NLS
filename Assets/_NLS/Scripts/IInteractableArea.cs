using _NLS.Scripts.Player;

namespace _NLS.Scripts
{
    public interface IInteractableArea
    {
        public bool IsReadyForInteract();
        public void Interact(PlayerInteractor  playerInteractor);
        public void ExitInteractArea();
    }
}