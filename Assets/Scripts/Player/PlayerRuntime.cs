using MVPTools.Runtime;

public class PlayerRuntime : IRuntime
{
    float _walkSpeed;
    float _runSpeed;
    float _jumpPower;
    bool _isRunnig;
    bool _isGround;
    bool _isFalling;

    public float JumpPower => _jumpPower;
    public bool IsGround => _isGround;
    public bool IsFalling => _isFalling;

    public PlayerRuntime(PlayerModel model)
    {
        _walkSpeed = model.WalkSpeed;
        _runSpeed = model.RunSpeed;
        _jumpPower = model.JumpPower;
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {

    }

    public void Run(bool isRunning)
    {
        if (_isGround) _isRunnig = isRunning;
    }

    public float GetMoveSpeed()
    {
        return _isRunnig ? _runSpeed : _walkSpeed;
    }

    public void Ground(bool isGround)
    {
        _isGround = isGround;
    }

    public void Down(bool isFalling)
    {
        if (_isGround) _isFalling = isFalling;
    }
}