using UnityEngine;

// HealMove: a Move that heals the user, never above max HP.
public class HealMove : Move
{
    public int Amount { get; private set; }

    public HealMove(string name, int amount) : base(name)
    {
        Amount = amount;
    }

    public override void Apply(Beast user, Beast target)
    {
        int before = user.Hp;
        user.Heal(Amount);
        Debug.Log($"{user.Name} used {Name}! {user.Name} recovered {user.Hp - before} HP.");
    }
}
