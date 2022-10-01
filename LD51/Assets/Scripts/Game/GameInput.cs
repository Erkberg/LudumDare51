using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class GameInput : MonoBehaviour
    {
        private Controls controls;

        private void Awake()
        {
            controls = new Controls();
            controls.Enable();
        }

        public Vector2 GetMovement()
        {
            return controls.Player.Move.ReadValue<Vector2>();
        }

        public bool GetDashDown()
        {
            return controls.Player.Dash.WasPressedThisFrame();
        }

        public bool GetCheat()
        {
            return controls.Player.Cheat.IsPressed();
        }
    }
}
