using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD51
{
    public class GameUI : MonoBehaviour
    {
        public Image progressImage;
        public List<Image> healthImages;

        public void SetProgress(float value)
        {
            progressImage.fillAmount = value;
        }

        public void SetHealth(int value)
        {
            for (int i = 0; i < healthImages.Count; i++)
            {
                healthImages[i].enabled = i < value;
            }
        }
    }
}
