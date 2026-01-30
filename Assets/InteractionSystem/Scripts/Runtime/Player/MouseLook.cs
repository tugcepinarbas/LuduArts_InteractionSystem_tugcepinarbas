using UnityEngine; 

public class MouseLook : MonoBehaviour
{
    // Fare hareketinin ne kadar hýzlý olacaðýný belirler.
    public float mouseSensitivity = 100f;

    // Kamerayý saða sola çevirdiðimizde tüm vücudun (P_Player) dönmesi için gövdenin referansý.
    public Transform playerBody;

    // Yukarý-aþaðý bakýþ açýsýný takip etmek için kullandýðýmýz deðiþken.
    float xRotation = 0f;

    void Start()
    {
        // Oyuna týklandýðýnda fare imlecini ekranýn ortasýna sabitler ve görünmez yapar.
        // Böylece fare oyun ekranýndan dýþarý kaçmaz.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Farenin yatay (X) ve dikey (Y) hareketini alýr.
        // Time.deltaTime: Bilgisayar hýzýndan baðýmsýz, her FPS'de ayný hýzda dönmeyi saðlar.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Y eksenindeki hareketle dikey bakýþ açýsýný hesaplar.
        // Unity'de yukarý bakmak için açýyý azaltmak, aþaðý bakmak için artýrmak gerekir (-= kullanýmý bu yüzden).
        xRotation -= mouseY;

        // Mathf.Clamp: Bakýþ açýsýný sýnýrlar. 
        // Kafanýn arkaya takla atmasýný veya boynun kýrýlmasýný engeller (-90 ile 90 derece arasý).
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Sadece KAMERAYI (bu scriptin takýlý olduðu nesne) yukarý-aþaðý döndürür.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Tüm OYUNCU GÖVDESÝNÝ (playerBody) saða-sola döndürür.
        // Saða sola döndüðümüzde ýþýn (Raycast) ve gövde de beraber döner.
        playerBody.Rotate(Vector3.up * mouseX);
    }
}