using UnityEngine;

namespace InteractionSystem.Runtime.Core
{
    public interface IInteractable
    {
        void OnInteract();
        void OnInteractionStart();
        void OnInteractionEnd();
        string GetInteractionPrompt();
        bool CanInteract();
    }
}
