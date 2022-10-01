using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD51
{
    public class GameUI : MonoBehaviour
    {
        public Image progressImage;

        public void SetProgress(float value)
        {
            progressImage.fillAmount = value;
        }
    }
}
