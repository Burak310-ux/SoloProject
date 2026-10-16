using UnityEngine;

public class DamageMove : Move
{
    public string Type { get; private set; }
    public int Power { get; private set; }

    public DamageMove(string name, string type, int power) : base(name)
    {
        Type = type;
        Power = power;
    }

    public override void Apply(Beast user, Beast target)
    {
        int damage = CalculateDamage(user, target);
        damage = ApplyType(damage, target.Type);
        target.TakeDamage(damage);
        Debug.Log($"{user.Name} used {Name}! {target.Name} takes {damage}.");
    } 
    
       int CalculateDamage(Beast user, Beast target)
    {
        int damage = ((2 * user.Level / 5 + 2) * Power * user.Attack / target.Defense) / 50 + 2;
        int roll = Random.Range(85, 101);
        return damage * roll / 100;
    }

        int ApplyType(int damage, string defender)
    {
        bool strong = (Type == "Fire" && defender == "Grass")
                   || (Type == "Grass" && defender == "Water")
                   || (Type == "Water" && defender == "Fire");
        bool weak = (Type == "Fire" && defender == "Water")
                 || (Type == "Grass" && defender == "Fire")
                 || (Type == "Water" && defender == "Grass");
        if (strong) { Debug.Log("It's super effective!"); return damage * 2; }
        if (weak) { Debug.Log("It's not very effective..."); return damage / 2; }
        return damage;
    }
}