using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    private Health2 h2; // Tham chiếu đến Health1
    public Image myImage2; // Kéo thả thanh máu vào đây từ Inspector
    public RectTransform rectTransform; // Kéo thả RectTransform vào đây từ Inspector
     float width;
     float posX;
     float posY;

    void Start()
    {
        h2 = FindObjectOfType<Health2>(); // Tìm Health1
        // Lấy chiều rộng
        width = rectTransform.rect.width;

        // Lấy vị trí X
        posX = rectTransform.anchoredPosition.x;
        posY = rectTransform.anchoredPosition.y;

    }
    void Update(){
        int currentHealth = h2.health;
        float newPosX = posX +((700-(currentHealth*7))/2);
        Vector2 newVT = new Vector2 (currentHealth*7,50);
        rectTransform.sizeDelta = newVT;// sát thương là 5%
        rectTransform.anchoredPosition = new Vector2(newPosX, posY); // giảm thanh máu từ bên phải, posx = posx-(độ dài giảm/2)

    }
    
}