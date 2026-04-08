using MVPTools.Runtime;
using UnityEngine;

public partial class PlayerView
{
    //Viewの表示部分を実装
    public void Move(Vector2 dir)
    {
        dir.y = _rb2d.linearVelocityY;
        _rb2d.linearVelocity = dir;
    }

    public void Jump(Vector2 jump)
    {
        _rb2d.AddForce(jump, ForceMode2D.Impulse);
    }
}