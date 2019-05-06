namespace UnityEngine.PostProcessing
{
    public sealed class PPMinAttributeAttribute : PropertyAttribute
    {
        public readonly float min;

        public PPMinAttributeAttribute(float min)
        {
            this.min = min;
        }
    }
}
