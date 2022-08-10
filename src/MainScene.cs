using Godot;
using System;

public class MainScene : Node2D
{
    Node2D initWorld;
    Node2D playerMove;

    public override void _Ready()
    {
        initWorld = (Node2D) GetNode("InitWorld");
        playerMove = (Node2D) GetNode("PlayerMove");
        
        initWorld.Connect("SpriteCreated", playerMove, "_SpriteCreatedCallback");
    }
}
