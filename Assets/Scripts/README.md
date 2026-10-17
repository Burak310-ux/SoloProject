# Udrast's Journey

## How to play
1. Open the Battle scene and press Play.
2. Click inside the Game view so it gets the keyboard.
3. Press 1-4 to pick a move: 1 TACKLE, 2 EMBER, 3 POTION, 4 LEECH BITE.
4. Each turn you use a move, then the opponent answers with a random move.
5. Goal: beat MOSSBUG and then RIPPLOT. If UDRAST faints, it is game over.

## My classes
- Beast: one creature with its stats, HP and moves; protects its own HP with private set.
- Move: base class for every move; has a name and a virtual Apply.
- DamageMove: a Move that deals damage using the formula and the type triangle.
- HealMove: a Move that heals the user, never above max HP.
- DrainMove: a DamageMove that hits, then heals the user by half the damage dealt.
- Battle: runs the game - menu, turns, opponents in order, win and lose.

## Inheritance
Move.Apply is virtual. DamageMove is a Move and HealMove is a Move, so both override Apply with their own behaviour.
DrainMove is a DamageMove, so it overrides Apply again and calls base.Apply to reuse the damage part.
Battle only calls player.Moves[i].Apply(...), and C# runs the right Apply for each object (polymorphism).

## My move
DrainMove (LEECH BITE): saves the target's HP, calls base.Apply to hit, then heals the user by half of the difference.
Example: RIPPLOT took 4 damage, so UDRAST healed 2 HP (4 -> 6).
It is interesting because it reuses DamageMove with base.Apply instead of copying the formula.

## AI help
I used Claude (AI assistant). It guided the Unity/GitHub setup, gave the class code from the Week 5 lecture notes,
walked me step by step through Battle.cs, helped fix errors, and wrote this README text.
For DrainMove I chose the two key lines myself (damage = before - target.Hp; user.Heal(damage / 2);).