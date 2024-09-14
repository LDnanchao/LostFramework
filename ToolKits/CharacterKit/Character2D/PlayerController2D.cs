using System;
using UnityEngine;

namespace LostFramework
{
    [RequireComponent(typeof(CharacterController2D))]
    public class PlayerController2D: MonoBehaviour
    {
        private Vector3 inputAxis;
        private CharacterController2D controller;

        private void Awake()
        {
            controller = GetComponent<CharacterController2D>();
        }

        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            inputAxis = new Vector3(x, y);
        }

        private void FixedUpdate()
        {
            if (inputAxis != Vector3.zero)
            {
                controller.Move(inputAxis);
            }
        }
    }
}