namespace LostFramework
{
    public abstract class AiAction
    {
        /// <summary>
        /// 大脑
        /// </summary>
        public AiBrain aiBrain;
        public virtual void Start(){}

        public virtual void Update(){}

        public virtual void FixedUpdate(){}

        public virtual void End(){}

        public void Enter()
        {
            
        }

        public void Init()
        {
            
        }

        public void Leave()
        {
            
        }
    }
}