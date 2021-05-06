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
        Stats.cooldown.decrementValue(Time.deltaTime);
    }
    
    public void Attack(CharacterStats targetStats)
    {
        if (Stats.cooldown.getValue() <= 0f)
        {
            targetStats.TakeDamage(Stats.damage.getValue());
            Stats.cooldown.setValue(1f / Stats.attackSpeed.getValue());
        }
    }
    
    public void AoEAttack(CharacterStats targetStats, float damage)
    {
        targetStats.TakeDamage(damage);
    }
    
    public void PlayerSingleAttack(CharacterStats targetStats, float damage)
    {
        if (Stats.cooldown.getValue() <= 0f)
        {
            targetStats.TakeDamage(damage);
            Stats.cooldown.setValue(1f / Stats.attackSpeed.getValue());
        }
    }
}
