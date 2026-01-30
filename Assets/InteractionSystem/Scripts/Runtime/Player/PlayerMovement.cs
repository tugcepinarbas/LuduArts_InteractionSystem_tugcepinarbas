using UnityEngine; 

public class PlayerMovement : MonoBehaviour
{
    // Karakterin hareketini saðlayan Unity bileþeni.
    public CharacterController controller;

    public float speed = 5f;       // Yürüme hýzý.
    public float gravity = -9.81f; // Dünyadaki gerçek yerçekimi deðeri.

    Vector3 velocity; // Karakterin dikeydeki (düþme) hýzýný tutan deðiþken.

    void Update()
    {
        // 1. GÝRDÝLERÝ AL (WASD veya Ok Tuþlarý)
        // Horizontal: A/D tuþlarý (-1 ile 1 arasý)
        // Vertical: W/S tuþlarý (-1 ile 1 arasý)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 2. HAREKET YÖNÜNÜ HESAPLA
        // transform.right: Karakterin saðýna bak.
        // transform.forward: Karakterin önüne bak.
        // Bu sayede karakter kafasýný nereye çevirirse "W" tuþu o yöne doðru götürür.
        Vector3 move = transform.right * x + transform.forward * z;

        // 3. KARAKTERÝ HAREKET ETTÝR
        // move: Yön, speed: Hýz, Time.deltaTime: Bilgisayar hýzýný eþitleme.
        controller.Move(move * speed * Time.deltaTime);

        // 4. YERÇEKÝMÝ HESAPLAMA
        // Her karede karakteri biraz daha aþaðý çekeriz.
        velocity.y += gravity * Time.deltaTime;

        // 5. YERÇEKÝMÝNÝ UYGULA
        // Karakterin boþlukta süzülmesini deðil, yere basmasýný saðlar.
        controller.Move(velocity * Time.deltaTime);
    }
}