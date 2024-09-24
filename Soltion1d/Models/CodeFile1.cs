/// <summary>
/// Runs the simulation with a time step of 0.01 seconds.
/// </summary>
private void Run()
{
    double dt = 0.01;
    foreach (var wave in Waves)
    {
        wave.Update(dt);
    }
}

