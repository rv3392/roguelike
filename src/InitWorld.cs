using Godot;
using System;

public class InitWorld : Node2D
{
	private const int MAX_X = 21;
	private const int MAX_Y = 15;
	private const int CENTER_X = 10;
	private const int CENTER_Y = 7;
	private const int ARROW_MARGIN = 32;

    private bool _initialized = false;

	PackedScene Player = (PackedScene) GD.Load("res://sprite/Player.tscn");
	PackedScene Floor = (PackedScene) GD.Load("res://sprite/Floor.tscn");
	PackedScene Wall = (PackedScene) GD.Load("res://sprite/Wall.tscn");
    PackedScene ArrowX = (PackedScene) GD.Load("res://sprite/ArrowX.tscn");
    PackedScene ArrowY = (PackedScene) GD.Load("res://sprite/ArrowY.tscn");
    PackedScene Dwarf = (PackedScene) GD.Load("res://sprite/Dwarf.tscn");

    [Signal]
    delegate void SpriteCreated(Sprite newSprite);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
        
	}

    public override void _Process(float delta) {
        if (!_initialized) {
            _initialized = true;
            this.FillFloor();
            this.AddCentreWalls(CENTER_X, CENTER_Y, 2);
            this.AddIndicators();
            this.CreateDwarves(new Vector2[]{
                new Vector2(5, 8),
                new Vector2(16, 2)
            });
            this.CreateSprite((Sprite) Player.Instance(), GroupNames.Player, 0, 0);
        }
    }

    private void CreateSprite(Sprite newSprite, String grp, int x, int y, int x_offset = 0, int y_offset = 0) {
		newSprite.Position = Coord.IndexToVec(x, y, x_offset, y_offset);
		newSprite.AddToGroup(grp);
		this.AddChild(newSprite);
        EmitSignal(nameof(SpriteCreated), newSprite);
	}

    private void FillFloor() {
        for (int i = 0; i < MAX_X; i++) {
			for (int j = 0; j < MAX_Y; j++) {
				this.CreateSprite((Sprite) Floor.Instance(), GroupNames.Floor, i, j);
			}
		}
    }

    private void AddCentreWalls(int centreX, int centreY, int depth) {
        for (int i = centreX - depth; i < centreX + depth; i++) {
			for (int j = centreY - depth; j < centreY + depth; j++) {
				this.CreateSprite((Sprite) Wall.Instance(), GroupNames.Wall, i, j);
			}
		}
    }

    private void AddIndicators() {
        this.CreateSprite((Sprite) ArrowX.Instance(), GroupNames.ArrowX, 0, 12, -ARROW_MARGIN, 0);
        this.CreateSprite((Sprite) ArrowY.Instance(), GroupNames.ArrowY, 5, 0, 0, -ARROW_MARGIN);
    }

    private void CreateDwarves(Vector2[] positions) {
        foreach (Vector2 pos in positions) {
            this.CreateSprite((Sprite) Dwarf.Instance(), GroupNames.Dwarf, (int) pos.x, (int) pos.y);
        }
    }
}
