using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class TimescaleCheat : MonoBehaviour
    {
        void Update()
        {
            if(Game.inst.input.GetCheat())
            {
                Time.timeScale = 8f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
