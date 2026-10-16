using UnityEngine;
using UnityEngine.InputSystem;
public class Battle : MonoBehaviour
{
        Beast player;
    Beast opponent;
           bool battleOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     Debug.Log("Battle starts."); 
             player = new Beast("UDRAST", "Fire", 5, 20, 11, 10);
        opponent = new Beast("MOSSBUG", "Grass", 5, 18, 9, 8);
                player.Learn(new DamageMove("TACKLE", "Normal", 35));
        player.Learn(new DamageMove("EMBER", "Fire", 40));
        player.Learn(new HealMove("POTION", 10));
        opponent.Learn(new DamageMove("TACKLE", "Normal", 35));
        opponent.Learn(new DamageMove("VINE WHIP", "Grass", 45));
        Debug.Log(player.Status());
        Debug.Log(opponent.Status()); 
                PrintMenu(); 
    }

        void PrintMenu()
    {
        string menu = $"<b>What will {player.Name} do?</b>\n";
        for (int i = 0; i < player.Moves.Count; i++)
        {
            menu = menu + $" {i + 1}) {player.Moves[i].Name}\n";
        }
        Debug.Log(menu);
    }

        int ReadChoice()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return 0;
        if (kb.digit1Key.wasPressedThisFrame) return 1;
        if (kb.digit2Key.wasPressedThisFrame) return 2;
        if (kb.digit3Key.wasPressedThisFrame) return 3;
        if (kb.digit4Key.wasPressedThisFrame) return 4;
        if (kb.digit5Key.wasPressedThisFrame) return 5;
        if (kb.digit6Key.wasPressedThisFrame) return 6;
        if (kb.digit7Key.wasPressedThisFrame) return 7;
        if (kb.digit8Key.wasPressedThisFrame) return 8;
        if (kb.digit9Key.wasPressedThisFrame) return 9;
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
              int choice = ReadChoice();
        if (choice == 0) { return; }
                if (battleOver) { return; }
        PlayTurn(choice - 1);  
    }

        void PlayTurn(int moveIndex)
    {
        if (moveIndex >= player.Moves.Count)
        {
            Debug.LogWarning($"{player.Name} does not know a move {moveIndex + 1}.");
            return;
        }

        player.Moves[moveIndex].Apply(player, opponent);

        if (!opponent.IsFainted())
        {
            int pick = Random.Range(0, opponent.Moves.Count);
            opponent.Moves[pick].Apply(opponent, player);
        }

        Debug.Log(player.Status() + "\n" + opponent.Status());
                if (opponent.IsFainted())
        {
            Debug.Log($"<color=green>{opponent.Name} fainted! You win!</color>");
            battleOver = true;
        }
        else if (player.IsFainted())
        {
            Debug.Log($"<color=red>{player.Name} fainted! Game over.</color>");
            battleOver = true;
        }
        else
        {
            PrintMenu();
        }
    }
}
