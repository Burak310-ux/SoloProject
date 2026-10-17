using UnityEngine;

// DrainMove: hits like a DamageMove, then heals the user by half the damage dealt.
public class DrainMove : DamageMove
{
    public DrainMove(string name, string type, int power) : base(name, type, power)
    {
    }

    public override void Apply(Beast user, Beast target)
    {
        int before = target.Hp;
        base.Apply(user, target);
        int damage = before - target.Hp;
        user.Heal(damage / 2);
        Debug.Log($"{user.Name} drained {damage / 2} HP!");
    }
}
