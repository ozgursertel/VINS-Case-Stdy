using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        if(GameManager.Instance.isGameFinished)
        {
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        transform.Translate(movement, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Nogger")
        {
            Debug.Log("Contact with Nogger");
            other.gameObject.SetActive(false);
            GameManager.Instance.addScore(1);
        }
    }
}