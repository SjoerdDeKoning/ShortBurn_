using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace Control_and_Input
{
    public class Sensitivity : MonoBehaviour
    {
        private CinemachinePOV _cinemachinePov;
        private void Awake()
        {
            _cinemachinePov = FindObjectOfType<CinemachinePOV>();
            if (_cinemachinePov == null)
            {
                Debug.LogWarning("Sensitivity has not found cinemachinePOV");
            }
        }

        public void UpdateSensitivityFromSlider(Slider slider)
        {
            SaveSensitivity(slider.value);
            ApplySensitivity();
        }
        private void Start()
        {
                ApplySensitivity();
        }
        
        public void SaveSensitivity(float sensitivity)
        {
            PlayerPrefs.SetFloat("sensitivity", sensitivity);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// gets the last save sensitivity 
        /// </summary>
        /// <returns> sensitivity</returns>
        public float GetSavedSensitivity()
        {
            return PlayerPrefs.GetFloat("sensitivity",1);
        }

        /// <summary>
        ///  Apply's the last saved sensitivity 
        /// </summary>
        public void ApplySensitivity()
        {
            var sens = GetSavedSensitivity();
            _cinemachinePov.m_VerticalAxis.m_MaxSpeed = sens;
            _cinemachinePov.m_HorizontalAxis.m_MaxSpeed = sens;
        }
    }
}
