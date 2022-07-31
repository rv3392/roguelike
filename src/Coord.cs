using Godot;
using System;

public static class Coord {
    public const int START_X = 50;
    public const int START_Y = 54;
    public const int STEP_X = 26;
    public const int STEP_Y = 34;


    public static int[] VecToArray(Vector2 coord) {
        return new int[]{
            (int) ((coord.x - START_X) / STEP_X),
            (int) ((coord.y - START_Y) / STEP_Y)
        };
    }

    public static Vector2 IndexToVec(int x, int y, int x_offset, int y_offset) {
        return new Vector2(
            START_X + STEP_X * x + x_offset,
            START_Y + STEP_Y * y + y_offset
        );
    }
}