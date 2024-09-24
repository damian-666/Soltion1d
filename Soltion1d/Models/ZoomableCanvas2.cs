public class ZoomableCanvas : Canvas
{
    private Matrix _transform = Matrix.Identity;

    public ZoomableCanvas()
    {
        this.PointerWheelChanged += OnPointerWheelChanged;
        this.ManipulationDelta += OnManipulationDelta;
    }

    private void OnPointerWheelChanged(object sender, PointerWheelEventArgs e)
    {
        double scaleFactor = e.Delta.Y > 0 ? 1.1 : 0.9;
        _transform = Matrix.CreateScale(scaleFactor, scaleFactor) * _transform;
        this.RenderTransform = new MatrixTransform(_transform);
    }

    private void OnManipulationDelta(object sender, Avalonia.Input.ManipulationDeltaEventArgs e)
    {
        _transform = Matrix.CreateScale(e.Delta.Scale, e.Delta.Scale) * _transform;
        this.RenderTransform = new MatrixTransform(_transform);
    }
}
