using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SimpleCameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed = 1f;

        [SerializeField]
        private float movementSpeed = 5f;

        private Vector3 desiredRotation;
        private Vector3 desiredVelocity;

        private void Start()
        {
            desiredRotation = transform.eulerAngles;
        }

        private void Update()
        {
            SetDesiredRotation();
            SetDesiredVelocity();
        }

        private void SetDesiredVelocity()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var movement = ((transform.forward * vertical) + (transform.right * horizontal)).normalized * movementSpeed;

            desiredVelocity = movement;
        }

        private void SetDesiredRotation()
        {
            if (!Input.GetMouseButton(2))
            {
                return;
            }

            var deltaX = Input.GetAxisRaw("Mouse X");
            var deltaY = Input.GetAxisRaw("Mouse Y");

            var rotationAngleY = deltaX * rotationSpeed;
            var rotationAngleX = -1 * deltaY * rotationSpeed;

            desiredRotation = new Vector3(desiredRotation.x + rotationAngleX, desiredRotation.y + rotationAngleY, desiredRotation.z);
        }

        private void FixedUpdate()
        {
            var desiredRotQ = Quaternion.Euler(desiredRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * 5);

            transform.position = Vector3.Lerp(transform.position, transform.position + desiredVelocity, Time.deltaTime * 3);
        }
    }
}
