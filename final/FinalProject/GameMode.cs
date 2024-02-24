using System;

public abstract class GameMode
{
    public abstract void Start();

    protected abstract void ValidateInput();

    protected abstract double CalculateWPM(double timeTaken, int wordCount);
}
