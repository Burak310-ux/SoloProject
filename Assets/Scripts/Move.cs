using UnityEngine;

// Move: base class for every move; has a name and a virtual Apply.


public class Move
{
    public string Name { get; private set; }

    public Move(string name)
    {
        Name = name;
    }

    public virtual void Apply(Beast user, Beast target)
    {
        Debug.Log($"{user.Name} used {Name}! But nothing happened.");
    }
}