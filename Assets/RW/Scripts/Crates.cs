
using UnityEngine;

public class Crates : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        LeanTween.alpha(gameObject, 0.2f, 0.6f);
        LeanTween.rotateAround(gameObject, collision.GetContact(0).normal, 250.0f, 0.6f).setDestroyOnComplete(true);
        GameManager.Instance.IncreaseScore(1);
    }
}
