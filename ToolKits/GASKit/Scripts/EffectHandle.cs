namespace LostFrameWork.GAS
{
    public struct EffectHandle
    {
        public AbilitySystemComponent owner;
        public AbilitySystemComponent target;
        public EffectBase effect;

        public void Remove()
        {
            owner.RemoveEffect(this);
        }
    }
}