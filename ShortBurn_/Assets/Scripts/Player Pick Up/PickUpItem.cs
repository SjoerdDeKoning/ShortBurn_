using System;
using UnityEngine;

namespace Player_Pick_Up
{
   [RequireComponent(typeof(Rigidbody))]
   public class PickUpItem : MonoBehaviour
   {
      public Rigidbody GetRigidbody { get; private set; }
      private void Awake()
      {
         GetRigidbody = GetComponent<Rigidbody>();
      }
   }
}
