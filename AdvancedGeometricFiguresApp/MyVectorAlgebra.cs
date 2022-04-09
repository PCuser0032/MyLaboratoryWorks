namespace VectorAlgebra
{
    public class Vector
    {
        public float X = 0.0F;
        public float Y = 0.0F;
        public Vector(float X = 0.0F, float Y = 0.0F)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    public class MyVectorAlgebra
    {
        public static double GetVectorLength(PointF StartingPoint, PointF EndPoint)
        {
            return Math.Sqrt(Math.Pow((double)(EndPoint.X - StartingPoint.X), 2.0) + Math.Pow((double)(EndPoint.Y - StartingPoint.Y), 2.0));
        }

        public static double GetVectorLengthV(Vector Vector)
        {
            return Math.Sqrt(Math.Pow((double)Vector.X, 2.0) + Math.Pow((double)Vector.Y, 2.0));
        }

        public static PointF GetVectorCoordinates(PointF StartingPoint, PointF EndPoint)
        {
            PointF VectorCoordinates = new PointF()
            {
                X = EndPoint.X - StartingPoint.X,
                Y = EndPoint.Y - StartingPoint.Y
            };

            return VectorCoordinates;
        }

        public static Vector GetVectorCoordinatesV(PointF StartingPoint, PointF EndPoint)
        {
            Vector VectorCoordinates = new Vector()
            {
                X = EndPoint.X - StartingPoint.X,
                Y = EndPoint.Y - StartingPoint.Y
            };

            return VectorCoordinates;
        }

        /*public static Vector GetVectorCoordinates(Vector Vector)
        {
            Vector VectorCoordinates = new Vector()
            {
                X = Vector.X,
                Y = Vector.Y
            };

            return VectorCoordinates;
        }*/

        public static double ScalarProduct(PointF VectorA, PointF VectorB)
        {
            return (double)(VectorA.X * VectorB.X + VectorA.Y * VectorB.Y);
        }

        public static double ScalarProductV(Vector VectorA, Vector VectorB)
        {
            return (double)(VectorA.X * VectorB.X + VectorA.Y * VectorB.Y);
        }

        public static double GetAngleV(Vector VectorA, Vector VectorB)
        {
            return Math.Acos(ScalarProductV(VectorA, VectorB) / (GetVectorLengthV(VectorA) * GetVectorLengthV(VectorB)));
        }
    }
}
