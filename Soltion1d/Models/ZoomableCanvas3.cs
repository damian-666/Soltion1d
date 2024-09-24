public class ZoomableCanvas : Canvas
{
    private Matrix _transform = Matrix.Identity;

    public ZoomableCanvas()
    {
        this.PointerWheelChanged+=OnPointerWheelChanged;
        this.ManipulationDelta+=OnManipulationDelta;
    }

    private void OnPointerWheelChanged(object sender, PointerWheelEventArgs e)
    {
        double scaleFactor = e.Delta.Y>0 ? 1.1 : 0.9;
        _transform=Matrix.CreateScale(scaleFactor, scaleFactor)*_transform;
        this.RenderTransform=new MatrixTransform(_transform);
    }

    private void OnManipulationDelta(object sender, Avalonia.Input.ManipulationDeltaEventArgs e)
    {
        _transform=Matrix.CreateScale(e.Delta.Scale, e.Delta.Scale)*_transform;
        this.RenderTransform=new MatrixTransform(_transform);


    private Matrix _transform = Matrix.Identity;
    private Point? _lastPoint;

    public PannableCanvas()
    {
        this.PointerPressed+=OnPointerPressed;
        this.PointerMoved+=OnPointerMoved;
        this.PointerReleased+=OnPointerReleased;
    }

    private void OnPointerPressed(object sender, PointerPressedEventArgs e)
    {
        _lastPoint=e.GetPosition(this);
    }

    private void OnPointerMoved(object sender, PointerEventArgs e)
    {
        if (_lastPoint.HasValue)
        {
            var point = e.GetPosition(this);
            var delta = point-_lastPoint.Value;
            _transform=Matrix.CreateTranslation(delta.X, delta.Y)*_transform;
            this.RenderTransform=new MatrixTransform(_transform);
            _lastPoint=point;
        }
    }

    private void OnPointerReleased(object sender, PointerReleasedEventArgs e)
    {
        _lastPoint=null;
    }
    public class ZoomablePannableCanvas : Canvas
    {
        private Matrix _transform = Matrix.Identity;
        private Point? _lastPoint;

        public ZoomablePannableCanvas()
        {
            this.PointerWheelChanged+=OnPointerWheelChanged;
            this.PointerPressed+=OnPointerPressed;
            this.PointerMoved+=OnPointerMoved;
            this.PointerReleased+=OnPointerReleased;
            this.ManipulationDelta+=OnManipulationDelta;
        }

        private void OnPointerWheelChanged(object sender, PointerWheelEventArgs e)
        {
            double scaleFactor = e.Delta.Y>0 ? 1.1 : 0.9;

            // Calculate the new scale
            double newScale = _transform.M11*scaleFactor;

            // Limit the zoom level to a range of 0.1 to 10
            if (newScale<0.1)
            {
                scaleFactor=0.1/_transform.M11;
            }
            else if (newScale>10)
            {
                scaleFactor=10/_transform.M11;
            }

            _transform=Matrix.CreateScale(scaleFactor, scaleFactor)*_transform;
            this.RenderTransform=new MatrixTransform(_transform);
        }

        private void OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            _lastPoint=e.GetPosition(this);
        }

        private void OnPointerMoved(object sender, PointerEventArgs e)
        {
            if (_lastPoint.HasValue)
            {
                var point = e.GetPosition(this);
                var delta = point-_lastPoint.Value;
                _transform=Matrix.CreateTranslation(delta.X, delta.Y)*_transform;
                this.RenderTransform=new MatrixTransform(_transform);
                _lastPoint=point;
            }
        }

        private void OnPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            _lastPoint=null;
        }

        private void OnManipulationDelta(object sender, Avalonia.Input.ManipulationDeltaEventArgs e)
        {
            var delta = e.Delta.Translation;
            _transform=Matrix.CreateTranslation(delta.X, delta.Y)*_transform;
            this.RenderTransform=new MatrixTransform(_transform);
        }
    } }
}
