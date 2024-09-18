namespace LostFramework
{
    public class AiDetermine
    {
        public AiBrain aiBrain;
        public string TrueTag { get; set; }
        public string FalseTag { get; set; }

        public virtual void Init()
        {
            
        }
        public virtual bool Update()
        {
            return true;
        }

        public virtual void Enter()
        {
            
        }

        public virtual void Leave()
        {
            
        }
    }
}