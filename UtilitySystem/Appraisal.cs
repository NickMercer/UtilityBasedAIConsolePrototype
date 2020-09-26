using System;

namespace UtilitySystem
{
    public struct Appraisal
    {
        private float value;
        public float Value 
        { 
            get { return value; }
            set { this.value = Math.Clamp(value, 0, 1); }
        }
        public bool CanContinue { get; set; }
    }
}