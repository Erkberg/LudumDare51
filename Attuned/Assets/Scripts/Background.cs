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
        public Color tuningBackgroundColorBad;
        public Color tuningBackgroundColorVeryBad;

        private Color targetTuningColor;

        private void Update()
        {
            CheckBackgroundColor();
        }

        private void CheckBackgroundColor()
        {
            if(Game.inst.IsIngame())
            {
                if(Game.inst.levels.IsListening())
                {
                    mainCam.backgroundColor = listeningBackgroundColor;
                }
                else
                {
                    float percentage = Game.inst.levels.GetUntunedPercentage();
                    if(percentage > 1f)
                    {
                        targetTuningColor = Color.Lerp(tuningBackgroundColorBad, tuningBackgroundColorVeryBad, percentage - 1f);
                    }
                    else
                    {
                        targetTuningColor = Color.Lerp(tuningBackgroundColor, tuningBackgroundColorBad, percentage);
                    }
                    
                    mainCam.backgroundColor = Color.Lerp(mainCam.backgroundColor, targetTuningColor, 0.00133f);
                }
            }            
        }
    }
}
