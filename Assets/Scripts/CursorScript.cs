using UnityEngine;

public class CursorScript2 : MonoBehaviour
{
    [SerializeField] Texture2D cursor;

    void Start()
    {
        Cursor.SetCursor(Resize(cursor, 50, 50), Vector3.zero, CursorMode.ForceSoftware);
    }

    Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
    {
        RenderTexture rt = new RenderTexture(targetX, targetY, 24);
        RenderTexture.active = rt;
        Graphics.Blit(texture2D, rt);
        Texture2D result = new Texture2D(targetX, targetY);
        result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
        result.Apply();
        return result;
    }

}
