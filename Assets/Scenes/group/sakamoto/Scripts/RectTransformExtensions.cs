using UnityEngine;

public static class RectTransformExtensions
{
    public static bool IsOverLapping(this RectTransform rect1, RectTransform rect2)
    {
        var rect1Corners = new Vector3[4];
        var rect2Corners = new Vector3[4];
        Vector3 rect1Rotation = rect1.eulerAngles;
        Vector3 rect2Rotation = rect2.eulerAngles;

        rect1.GetWorldCorners(rect1Corners);
        rect2.GetWorldCorners(rect2Corners);

        //角度差が一定以内であれば判定処理
        if (rect1Rotation.z >= 180.0f)
        {
            rect1Rotation.z = 360.0f - rect1Rotation.z; 
        }
        if(rect2Rotation.z >= 180.0f)
        {
            rect2Rotation.z = 360.0f - rect2Rotation.z;
        }

        float angleDifference = rect2Rotation.z - rect1Rotation.z;

        Debug.Log("角度" + angleDifference);

        if (angleDifference <= 30.0f ||
            angleDifference >= 150.0f)
        {
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
