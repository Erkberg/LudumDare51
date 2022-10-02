using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Attuned
{
    public class Note : MonoBehaviour
    {
        public Id id;
        public AudioSource audioSource;
        public CanvasGroup canvasGroup;
        [Space]
        public Image buttonImage;
        public Button button;
        public Color baseColor;
        public Color neutralColor;
        public Color correctColor;
        public Color wrongColor;
        [Space]
        public Slider slider;
        public int deviation;
        public int sliderDeviation;

        private float clipLoudness;
        private float[] clipSampleData;
        
        private const string PitchParameterPrefix = "Pitch";
        private const float BasePitch = 1f;
        private const float PitchDeviationStep = 0.1f;
        private const int MaxDeviationSteps = 1;
        private const int SampleDataLength = 1024;
        private const float LoudnessMultiplier = 24f;
        private const float CorrectVolumeValue = 0.67f;

        private void Awake()
        {
            clipSampleData = new float[SampleDataLength];
        }

        private void Update()
        {
            if(audioSource.isPlaying)
            {
                AdjustImage();
                AdjustVolume();
            }            
        }

        public void SetActive(bool active)
        {
            if(active)
            {
                audioSource.Play();
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
            }
            else
            {
                audioSource.Stop();
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
            }
        }

        public void SetClip(AudioClip clip)
        {
            audioSource.clip = clip;
        }

        public void SetSliderActive(bool active)
        {
            slider.gameObject.SetActive(active);
        }

        private void AdjustImage()
        {
            Color targetColor = neutralColor;
            if(Game.inst.settings.wrongNotesColorEnabled)
            {
                targetColor = IsWrong() ? wrongColor : correctColor;
            }
            float loudness = GetAudioLoudness() * LoudnessMultiplier;
            Color color = Color.Lerp(baseColor, targetColor, loudness);
            buttonImage.color = color;
        }

        private void AdjustVolume()
        {
            audioSource.volume = IsWrong() ? 1f : CorrectVolumeValue;
        }

        private float GetAudioLoudness()
        {
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= SampleDataLength;
            return clipLoudness;
        }

        public void RandomizeDeviation()
        {
            int previousDeviation = deviation;
            deviation = Random.Range(1, MaxDeviationSteps);
            if(Random.value < 0.5f)
            {
                deviation *= -1;
            }
            if(deviation == previousDeviation)
            {
                deviation *= -1;
            }
            UpdatePitch();
        }

        public void SetDeviationTuned()
        {
            deviation = -sliderDeviation;
            UpdatePitch();
        }

        public void OnSliderChanged(float value)
        {
            sliderDeviation = (int)value;
            UpdatePitch();
        }

        public void OnClicked()
        {
            if (Game.inst.levels.IsListening())
                return;

            if(deviation == 0)
            {
                RandomizeDeviation();
            }
            else
            {
                deviation = 0;
            }

            UpdatePitch();
        }

        private void UpdatePitch()
        {
            int finalDeviation = deviation + sliderDeviation;
            SetPitch(BasePitch + finalDeviation * PitchDeviationStep);
        }

        private float GetPitch()
        {
            audioSource.outputAudioMixerGroup.audioMixer.GetFloat(PitchParameterPrefix + id, out float value);
            return value;
        }

        private void SetPitch(float value)
        {
            audioSource.outputAudioMixerGroup.audioMixer.SetFloat(PitchParameterPrefix + id, value);
        }

        public bool IsWrong()
        {
            return deviation + sliderDeviation != 0;
        }

        public void SetAsPitch(float value)
        {
            audioSource.pitch = value;
        }

        public enum Id
        {
            None,
            MidG,
            MidA,
            MidB,
            MidD,
            MidE,
            LowG,
            LowA,
            LowB,
            LowD,
            LowE,
            HighG,
            HighA,
            HighB,
            HighD,
            HighE
        }
    }
}
