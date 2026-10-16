using UnityEngine;
using System.Collections.Generic;


public class Beast
{
       public string Name { get; private set; }
    public string Type { get; private set; }
    public int Level { get; private set; }
    public int MaxHp { get; private set; }
    public int Hp { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }

    public Beast(string name, string type, int level, int maxHp, int attack, int defense)
    {
        Name = name;
        Type = type;
        Level = level;
        MaxHp = maxHp;
        Hp = maxHp;
        Attack = attack;
        Defense = defense;
    }

        public List<Move> Moves { get; private set; } = new List<Move>();

    public void Learn(Move move)
    {
        if (Moves.Count >= 4)
        {
            Debug.LogWarning($"{Name} already knows four moves and cannot learn {move.Name}.");
            return;
        }
        Moves.Add(move);
    }

    public void TakeDamage(int damage)
    {
        Hp = Hp - damage;
        if (Hp < 0) { Hp = 0; }
    }

    public void Heal(int amount)
    {
        Hp = Hp + amount;
        if (Hp > MaxHp) { Hp = MaxHp; }
    }

    public bool IsFainted()
    {
        return Hp <= 0;
    }

    public string Status()
    {
        return $"{Name,-10} {Hp,2}/{MaxHp,-2} {HpBar()}";
    }

        string HpBar()
    {
        int filled = Hp * 10 / MaxHp;
        string bar = "[";
        for (int i = 0; i < 10; i++)
        {
            if (i < filled) { bar = bar + "█"; }
            else { bar = bar + "░"; }
        }
        return bar + "]";
    } 
}
