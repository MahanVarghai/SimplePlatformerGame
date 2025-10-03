using UnityEngine;

public class PlayerHealth: MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    private AnimationHandler playerAnimationHandler;
    private void Start()
    {
        playerAnimationHandler = GetComponent<PlayerAnimationHandler>();
    }
    public void TakeDamage(int damage)
    {

        health -= damage;
        if (health <= 0)
        {
            playerAnimationHandler.Dead = true;
            transform.Find("Target For Enemeis").
                GetComponent<Transform>().
                position = new Vector3(1000, 1000, 0);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            playerAnimationHandler.TakeDamage = true;
        }
        
    }
    public void PlayerDeath()
    {
        UiBehavior.Instance.GameOverPanelEnable();
    }
}
