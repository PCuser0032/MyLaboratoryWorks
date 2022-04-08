namespace VectorAlgebra
{
    public class VectorCoord
    {
        public float X = 0.0F;
        public float Y = 0.0F;
        public VectorCoord(float X = 0.0F, float Y = 0.0F)
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

        public static double GetVectorLengthV(VectorCoord Vector)
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

        public static VectorCoord GetVectorCoordinatesV(PointF StartingPoint, PointF EndPoint)
        {
            VectorCoord VectorCoordinates = new VectorCoord()
            {
                X = EndPoint.X - StartingPoint.X,
                Y = EndPoint.Y - StartingPoint.Y
            };

            return VectorCoordinates;
        }

        public static VectorCoord GetVectorCoordinates(VectorCoord Vector)
        {
            VectorCoord VectorCoordinates = new VectorCoord()
            {
                X = Vector.X,
                Y = Vector.Y
            };

            return VectorCoordinates;
        }

        public static double ScalarProduct(PointF VectorA, PointF VectorB)
        {
            return (double)(VectorA.X * VectorB.X + VectorA.Y * VectorB.Y);
        }

        public static double ScalarProductV(VectorCoord VectorA, VectorCoord VectorB)
        {
            return (double)(VectorA.X * VectorB.X + VectorA.Y * VectorB.Y);
        }

        public static double GetAngleV(VectorCoord VectorA, VectorCoord VectorB)
        {
            return Math.Acos(ScalarProductV(VectorA, VectorB) / (GetVectorLengthV(VectorA) * GetVectorLengthV(VectorB)));
        }
    }
}
