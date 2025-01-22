using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlightController : MonoBehaviour
{
   private Rigidbody rb;
   private Collider collider;
   
   public float leftGas = 100;
   public TextMeshProUGUI leftGastext;

   
   [SerializeField] private float direction;

   void Start()
   {
      rb = GetComponent<Rigidbody>();
      collider = GetComponent<Collider>();
      //gasController = GetComponent<GasController>();

   }

   public void Move(Vector2 moveInput)
   {
      if (moveInput.x != 0 || moveInput.y != 0)
      {
         rb.velocity = new Vector2(moveInput.x * direction, moveInput.y * direction);
         
      }
      else
      {
         rb.velocity = new Vector2(0, 0);
      }
   }

   public void RestrictFlight()
   {
      float clampedY= Mathf.Clamp(rb.transform.position.y, -15, 15);
      rb.transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
   }

   void OnCollisionEnter(Collision collision)
   {
      

      if (collision.gameObject.layer == LayerMask.NameToLayer("obstacle"))
      {
         UIManager.Instance.GameOverPanel();
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer("Gas"))
      {
         leftGas += 30;
         Destroy(other.gameObject);
      }
   }

   public void GasUpdate()
   {
      leftGastext.text = leftGas.ToString();
      leftGas -= 9* Time.deltaTime;
      leftGas = Mathf.Clamp(leftGas, 0, 200);
      if (leftGas <= 0)
      {
         GameManager.Instance.iswork = false;
         UIManager.Instance.GameOverPanel();
         leftGas = 100;
      }

   }
}