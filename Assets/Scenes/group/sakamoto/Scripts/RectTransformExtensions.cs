using UnityEngine;

public static class RectTransformExtensions
{
    public static bool IsOverLapping(this RectTransform rect1, RectTransform rect2)
    {
        var rect1Corners = new Vector3[4];
        var rect2Corners = new Vector3[4];

        rect1.GetWorldCorners(rect1Corners);
        rect2.GetWorldCorners(rect2Corners);

        for (var i = 0; i < 4; i++)
        {
            if (IsPointInsideRect(rect1Corners[i], rect2Corners))
            {
                return true;
            }
            if (IsPointInsideRect(rect2Corners[i], rect1Corners))
            {
                return true;
            }
        }

        //重なってない
        return false;
    }

    //指定座標が矩形の内部にあるか
    private static bool IsPointInsideRect(Vector3 point, Vector3[] rectCorners)
    {
        var inside = false;

        //rectCornersの各頂点に対して、pointがrect内にあるかを確認
        for (int i = 0, j = 3; i < 4; j = i++)
        {
            if (((rectCorners[i].y > point.y) != (rectCorners[j].y > point.y)) &&
                (point.x < (rectCorners[j].x - rectCorners[i].x) * (point.y - rectCorners[i].y) / (rectCorners[j].y - rectCorners[i].y) + rectCorners[i].x))
            {
                inside = !inside;
            }
        }

        return inside;
    }
}
