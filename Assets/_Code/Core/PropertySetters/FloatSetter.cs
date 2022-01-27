namespace TutanDev.Core
{
    public class FloatSetter 
    {
        FloatReference reference;

        public FloatSetter(FloatReference reference)
        {
            this.reference = reference;
        }

        public void SetValue(FloatReference floatRef)
        {
            reference.Value = floatRef.Value;
        }

        public void SetValue(float floatVal)
        {
            reference.Value = floatVal;
        }
    }
}