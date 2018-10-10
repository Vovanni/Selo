using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private float drunk = 0;
        public static float h, v;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        void FixedUpdate()
        {
            // pass the input to the car!
            h = CrossPlatformInputManager.GetAxis("Horizontal");
            v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            //Пьянь наносит ответный удар
            drunk = Counter.drunk;
            if (drunk != 0)
            {
                h += UnityEngine.Random.Range(-0.1f * drunk, 0.1f * drunk);
                if (h > 1f) h = 1f;
                if (h < -1f) h = -1f;
            }
            

            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
