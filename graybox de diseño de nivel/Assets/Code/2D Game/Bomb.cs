using UnityEngine.Events;
using UnityEngine;

public class Bomb : MonoBehaviour, IUsable
{
   [SerializeField] private booleanVariable isBomb;
   public UnityEvent OnUse;
   public bool CanInteract
   {
      get {return canInteract;} set {canInteract = value; }}

   bool canInteract;
   public void Use()
   {
      if (OnUse != null)
      {
         OnUse.Invoke();
      }
   }
}
