using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InTune
{
    public class Note : MonoBehaviour
    {
        public Id id;
        public AudioSource audioSource;
        public Image image;
        public Slider slider;
        public int deviation;
        public int sliderDeviation;

        private float clipLoudness;
        private float[] clipSampleData;
        
        private const string PitchParameterPrefix = "Pitch";
        private const float BasePitch = 1f;
        private const float PitchDeviationStep = 0.033f;
        private const int MaxDeviationSteps = 2;
        private const float MinPitchDeviation = 0.01f;
        private const float MaxPitchDeviation = 0.033f;
        private const int SampleDataLength = 1024;

        private void Awake()
        {
            clipSampleData = new float[SampleDataLength];
        }

        private void Update()
        {
            AdjustImage();
        }

        private void AdjustImage()
        {
            float value = 0.33f + GetAudioLoudness();
            Color color = Color.white;
            color.a = 0.33f + GetAudioLoudness() * 8;
            image.color = color;
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

        public void OnSliderChanged(float value)
        {
            sliderDeviation = (int)value;
            UpdatePitch();
        }

        public void OnClicked()
        {
            if(GetPitch() == BasePitch)
            {
                float deviation = Random.Range(MinPitchDeviation, MaxPitchDeviation);
                if (Random.value < 0.5f)
                    deviation *= -1;
                SetPitch(BasePitch + deviation);
            }
            else
            {
                SetPitch(BasePitch);
            }
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

        public enum Id
        {
            None,
            MidG,
            MidA,
            MidB,
            MidD,
            MidE
        }
    }
}
