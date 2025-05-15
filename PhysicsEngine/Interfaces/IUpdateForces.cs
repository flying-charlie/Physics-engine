interface IUpdateForces
{
    /// <summary>
    /// Update run every frame before calculating movement. Use if a force is applied this frame.
    /// </summary>
    /// <param name="deltaTime">time in seconds since last frame</param>
    void UpdateForce(float deltaTime);
}