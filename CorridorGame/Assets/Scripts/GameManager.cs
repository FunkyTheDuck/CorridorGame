using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;
    GameCanvasScript gameCanvas;
    public GameObject player;
    public bool heardCrying = false;
    public bool heardSiren = false;
    public bool clueSpawned = false;
    int currentClue;
    private List<string> noteClues;
    private void Start()
    {
        #region noteCluesInstanses

        currentClue = 0;
        noteClues = new List<string>()
        {
            "I’ve been trapped in this hotel for about an hour now and started to think there is no way out, so I thought it was a clever idea to write down what is happening. The hallways never seem to end, I believe this place is haunted, I would never believe such a thing if I wasn’t here myself. It seems like this place is changing as you walk, it all looks the same but still, I know if a go back by a few rooms the rooms are not the same. And I've started to hear noises like something is following me or watching over me.",
            "It’s been multiple hours now and I just saw something move in front of me. It didn’t look human at all, it had horns and was super tall. I did try to call out to it, and nothing replayed not even a sound, I don’t want to believe this, but either I'm going crazy, or I saw something like a monster. I’ve noticed that there are these symbols on the walls, I got no idea what they mean, but it’s not normal for a hotel to have something like this on the walls, it must mean something.",
            "I have no idea what amount of time has passed, and I just got confronted by something I could only explain as a demon. It slowly walked towards me, so I ran for minutes and haven’t seen it since. and I just notice that this place is shrinking, there is no doubt about it, I'm not a tall guy and now I’m as tall as a door. I Believe this demon thing as control of this hotel and is playing with me and even others, I don’t think I'm the only one who booked a night at this hotel, it might be feeding on my energy, I feel more and more tired, and not like I normally would feel tired, I've lost energy to raise my hands above my head.",
            "I heard another person scream for help, it wasn’t loud, but sounded like it was right ahead of me. I didn’t find anything while looking and calling for them. I still have no idea of how long I've been trapped in these same corridors, but while I've walked, I've put together the symbols I've collected, and they look like a word or a name. A name could make sense cause if I remember correctly, you can use a demon's name against it. I don’t know what a reverse A means, else it looks like there is a G in the middle and a N at the end. It looks like there are five in total. I have no idea how something like that would work, but if I figure out the name I might have a change, but I can’t walk straight anymore, I've been crawling for minutes and can’t stop thinking about being crunched like this.",
            "I believe I got it, a name. And I started yelling the name out loud, and a door close to me opened, after all these locked doors. I can’t move fast but, at this pace I will make it. I still think that even if I get out, the demon will still be here feeding on other people. If you read this the name of the demo",
        };

        #endregion
        try
        {
            soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        }
        catch
        {

        }
        gameCanvas = GameObject.Find("GameUI").GetComponent<GameCanvasScript>();
        soundManager.PlayASound("AmbientSound",false);
        player = GameObject.Find("Player");
        StartCoroutine(FloorCraking(Random.Range(5,17)));
    }
    IEnumerator FloorCraking(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        soundManager.gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,(player.transform.position.z - -5));
        soundManager.PlayASound("WoodenFloorCracking", true);
        StartCoroutine(FloorCraking(Random.Range(8, 17)));
    }
    public bool GetClueSpawned()
    {
        return clueSpawned;
    }
    public void SetClueSpawned(bool value)
    {
        clueSpawned = value;
    }
    public void CluePickedUp()
    {
        gameCanvas.DisplayNote(noteClues[currentClue]);
        currentClue += 1;
    }

    #region heardBools
    public bool GetheardCrying()
    {
        return heardCrying;
    }
    public bool GetHeardSiren()
    {
        return heardSiren;
    }
    public void SetHeardCrying(bool value)
    {
        heardCrying = value;
    }
    public void SetHeardSiren(bool value)
    {
        heardSiren = value;
    }
    #endregion
}