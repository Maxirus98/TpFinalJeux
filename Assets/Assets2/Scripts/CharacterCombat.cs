using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public CharacterStats Stats { set; get; }
    
    private void Start()
    {
        Stats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        Stats.cooldown.Value -= Time.deltaTime;
    }

    public void AoEAttack(CharacterStats targetStats, float damage)
    {
        targetStats.TakeDamage(damage);
    }
    public void Attack(CharacterStats targetStats)
    {
        if (Stats.cooldown.Value <= 0f)
        {
            targetStats.TakeDamage(Stats.damage.Value);
            Stats.cooldown.Value = 1f / Stats.attackSpeed.Value;
        }
    }
}
