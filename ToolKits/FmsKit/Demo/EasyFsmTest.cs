namespace LostFramework.Demo
{
    public enum ZZZ
    {
        Move,Attack
    }
    public class EasyFsmTest:EasyFsm<ZZZ>
    {
        public override void StartFsm()
        {
            currentState = ZZZ.Attack;
        }

        public override void FixedUpdate()
        {
            switch (currentState)
            {
                case ZZZ.Attack:
                    SwitchState(ZZZ.Attack);
                    break;
                case ZZZ.Move:
                    SwitchState(ZZZ.Move);
                    break;
            }
        }

        public override void Update()
        {
            switch (currentState)
            {
                case ZZZ.Attack:
                    break;
                case ZZZ.Move:
                    break;
            }
        }
    }
}