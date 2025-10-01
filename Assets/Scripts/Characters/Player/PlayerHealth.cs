using UnityEngine;

public class PlayerHealth: Health
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (health <= 0)
        {
            Debug.Log("fuck");
            UiBehavior.Instance.GameOverPanelEnable();
        }
    }
}
