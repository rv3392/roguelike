using Godot;
using System;

public class PlayerMove : Node2D
{
    private Sprite _player;
    public override void _Ready()
    {
        
    }

    public override void _UnhandledInput(InputEvent inputEvent) {
        var position = Coord.VecToArray(_player.Position);
        
        if (inputEvent.IsActionPressed(InputName.MOVE_LEFT)) {
            position[0] -= 1;
        } else if (inputEvent.IsActionPressed(InputName.MOVE_DOWN)) {
            position[1] += 1;
        } else if (inputEvent.IsActionPressed(InputName.MOVE_UP)) {
            position[1] -= 1;
        } else if (inputEvent.IsActionPressed(InputName.MOVE_RIGHT)) {
            position[0] += 1;
        }

        _player.Position = Coord.IndexToVec(position[0], position[1], 0, 0);
    }

    public void _SpriteCreatedCallback(Sprite newSprite) {
        if (newSprite.IsInGroup(GroupNames.Player)) {
            _player = newSprite;
        }
    }
}
