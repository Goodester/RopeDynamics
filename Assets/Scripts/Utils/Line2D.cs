using UnityEngine;

namespace Utils
{
    public class Line2D
    {
        public Line2D(Vector2 point1, Vector2 point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public Vector2 Point1
        {
            get;
            set;
        }

        public Vector2 Point2
        {
            get;
            set;
        }
        
        public float CalculateY(float x)
        {
            return Slope * x - Slope * Point1.x + Point1.y;
        }

        public float Slope => (Point1.y - Point2.y) / (Point1.x - Point2.x);
    }
}
