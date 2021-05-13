using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public CharacterStats Stats { set; get; }
    private AudioSource _audioSource;
    private void Start()
    {
        Stats = GetComponent<CharacterStats>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Stats.cooldown.getValue() != 0)
        {
            Stats.cooldown.decrementValue(Time.deltaTime);
        }
    }
    
    public void Attack(CharacterStats targetStats)
    {
        if (Stats.cooldown.getValue() <= 0f)
        {
            targetStats.TakeDamage(Stats.damage.getValue());
            Stats.cooldown.setValue(1f / Stats.attackSpeed.getValue());
            _audioSource.Play();
        }
    }
    
    public void Attack(CharacterStats targetStats, float damage)
    {
        targetStats.TakeDamage(damage);
    }
    
}
