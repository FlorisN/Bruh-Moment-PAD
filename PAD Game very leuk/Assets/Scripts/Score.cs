using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public Transform player;
    public Text score;

    // Update is called once per frame
    void Update()
    {
        //We need to change the text and it has to be a string.
        //The number (player pos x) will be converted to a string with 'ToString()'.
        //There is a zero so it doesn't display any decimals.
        score.text = player.position.x.ToString("0");
    }
}
