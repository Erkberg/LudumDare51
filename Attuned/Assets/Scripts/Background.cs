using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attuned
{
    public class Background : MonoBehaviour
    {
        public Camera mainCam;

        public Color listeningBackgroundColor;
        public Color tuningBackgroundColor;

        private void Update()
        {
            CheckBackgroundColor();
        }

        private void CheckBackgroundColor()
        {
            if(Game.inst.IsIngame())
            {
                mainCam.backgroundColor = Game.inst.levels.IsListening() ? listeningBackgroundColor : tuningBackgroundColor;
            }            
        }
    }
}
