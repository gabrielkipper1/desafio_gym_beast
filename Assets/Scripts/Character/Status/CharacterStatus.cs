using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CharacterStatus", menuName = "Character/CharacterStatus", order = 1)]
public class CharacterStatus : ScriptableObject
{
   CharacterStatus(){
      stackedAmount = 0;
   }

   public void RegisterEvents(CharacterController characterController){
      //STACK EVENTS
      characterController.OnStackIncreased.AddListener(IncreaseStack);
      characterController.OnStackDecreased.AddListener(DecreaseStack);
      characterController.OnMaxStrackIncreased.AddListener(IncreaseMaxStack);

      //STAR EVENTS
      characterController.OnStarsAdded.AddListener(AddStars);
      characterController.OnStarsRemoved.AddListener(AddStars);
   }

   public void UnregisterEvents(CharacterController characterController){
      //STACK EVENTS
      characterController.OnStackIncreased.RemoveListener(IncreaseStack);
      characterController.OnMaxStrackIncreased.RemoveListener(IncreaseMaxStack);
      characterController.OnStackDecreased.RemoveListener(DecreaseStack);

      //STAR EVENTS
      characterController.OnStarsAdded.RemoveListener(AddStars);
      characterController.OnStarsRemoved.RemoveListener(AddStars);
   }

   [field: SerializeField]
   public int stackedAmount { get; private set;}

   [field: SerializeField]
   public int maxStack { get; private set;}

   [field: SerializeField]
   public int stars { get; private set;}


   public void IncreaseStack(StackableObject stackableObject)
   {
      Debug.Log("Updating stack amount on status");
      stackedAmount += 1;
   }

   public void DecreaseStack(int amount){
      stackedAmount -= amount;
   }

   public void AddStars(int amount)
   {
      stars += amount;
   }

   public void IncreaseMaxStack(int amount)
   {
      maxStack += amount;
   }
}
