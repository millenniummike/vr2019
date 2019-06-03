/** TODO

Split bets are too high on table
Show highlighted bet slot as number is hard to see with a bet on the table slot
Finish remaining split bets
Add some more props
Fix 0 slot texture

*/



using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public struct Bet
{
    public string Player;
    public int Amount;
    public int BettingBox;

}
public class StateManager : Singleton<StateManager>
{
    protected StateManager() {} // guarantee this will be always a singleton only - can't use the constructor!
    public int casinoBank = 0;
    public int playerBet = 0;
    public int playerBalance = 100;
    public List<int> playerBetAmounts;
    public List<Bet> Bets;
    public List<Bet> BetsHistory;
    public List<GameObject> Chips;
    public List<int> winningNumbers;
    public List<int> payouts;
    public GameObject coin;
    public GameObject RecentWinner;
    public bool ballLive = false;
    public int playerDefaultBetAmount;
    public Material blackMaterial;
    public Material redMaterial;
    public GameObject ballPrefab;
    public GameObject ball;
    public int countDown;
    public bool countDownStarted = false;
    public AudioClip ballRolling;
    public AudioClip ballInSlot;
    public AudioClip audioPayOut;
    public GameObject roomLights;
    public PlayableDirector wheelCameraAnimator;
    public List<GameObject> ads;

    public bool throwBallNow = false;

    public JSONObject gameJSON;

    public void loadAds(){
        int counter = 12;
        foreach (GameObject ad in ads)
        {
            ad.GetComponent<JSONImageLoader>().LoadTexture("" + gameJSON["games"][counter]["imageUrl"]);
            counter++;
        }
    }
}

