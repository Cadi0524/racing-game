using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
   private PlayerInput playerInput;
   private Vector2 moveInput;
   private FlightController _flightController;



   void Awake()
   {
      playerInput = GetComponent<PlayerInput>();
      _flightController = GetComponent<FlightController>();
      
   }

   void Update()
   {
       moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
      _flightController.Move(moveInput);
      _flightController.GasUpdate();
      _flightController.RestrictFlight();
   }
   
   
}
