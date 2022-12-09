using System.Drawing;

namespace AdventOfCode_2022.Day9;

internal class Common
{
    public static int CalculateNumberOfUniquePointsVisitedByTail(List<string> headMovements, int knotCount)
    {
        var uniquePointsVisitedByTail = new HashSet<Point>();

        var points = new Point[knotCount];
        Array.Fill(points, new Point(0, 0));

        foreach (var headMovement in headMovements)
        {
            var movementParts = headMovement.Split();

            string direction = movementParts[0];
            int steps = int.Parse(movementParts[1]);

            for (int i = 0; i < steps; i++)
            {
                points[0] = CalculateNextHeadPoint(points[0], direction);

                for (int j = 1; j < knotCount; j++)
                {
                    points[j] = CalculateNextKnotPoint(points[j - 1], points[j]);
                }

                uniquePointsVisitedByTail.Add(points[knotCount - 1]);
            }
        }

        return uniquePointsVisitedByTail.Count;
    }

    public static Point CalculateNextHeadPoint(Point head, string direction)
    {
        return direction switch
        {
            "L" => new Point(head.X - 1, head.Y),
            "R" => new Point(head.X + 1, head.Y),
            "U" => new Point(head.X, head.Y - 1),
            "D" => new Point(head.X, head.Y + 1),
            _ => throw new Exception("This should never happen"),
        };
    }

    public static Point CalculateNextKnotPoint(Point head, Point tail)
    {
        int distanceX = head.X - tail.X;
        int distanceY = head.Y - tail.Y;

        // Diagonal
        if (Math.Abs(distanceX) == 2 && Math.Abs(distanceY) == 2)
        {
            return new Point(head.X - Math.Sign(distanceX), head.Y - Math.Sign(distanceY));
        }

        // Horizontal
        if (Math.Abs(distanceX) == 2)
        {
            return new Point(head.X - Math.Sign(distanceX), head.Y);
        }

        // Vertical
        if (Math.Abs(distanceY) == 2)
        {
            return new Point(head.X, head.Y - Math.Sign(distanceY));
        }

        return tail;
    }
}
