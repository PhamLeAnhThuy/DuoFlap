using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private void Start()
    {
    }
    // dich chuyen char theo vector
    private void Update()
    {
        ClampCharacterWithinScreen();
    }

    // giu cho char o trong khung hinh
    void ClampCharacterWithinScreen()
    {
        Vector3 pos = transform.position;
        // gioi han vi tri cua char trong pham vi man hinh dua theo toa do tren, duoi
        pos.y = Mathf.Clamp(pos.y, ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop);
        transform.position = pos;
    }
}
