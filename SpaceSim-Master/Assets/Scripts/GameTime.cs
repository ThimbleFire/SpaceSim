using UnityEngine;

public class GameTime : MonoBehaviour
{
    public UnityEngine.UI.Image pausedImage;
    public Sprite[] pausedStatusGraphic;

    public delegate void OnTickHandler();
    public static event OnTickHandler OnTck;

    public static bool Active { get; set; } = false;
    private float Timer { get; set; } = 0.0f;
    private readonly float interval = 0.6f;

    private void Awake() => ClockStart();

    public void Update() {
        if( Active == false )
            return;
        Timer += Time.deltaTime;
        if( Timer >= interval ) {
            Timer -= interval;
            OnTck?.Invoke();
        }
    }
    public static void ClockStart() => Active = true;
    public static void ClockStop() => Active = false;

    public void TogglePause() {
        Active = !Active;

        pausedImage.sprite = Active ? pausedStatusGraphic[0] : pausedStatusGraphic[1];
    }
}
