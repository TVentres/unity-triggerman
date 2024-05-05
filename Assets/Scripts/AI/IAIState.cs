public interface IAIState
{
    void Enter();
    void Execute();
    void Exit(); // Ensure this is implemented even if it's empty, for consistency.
}
