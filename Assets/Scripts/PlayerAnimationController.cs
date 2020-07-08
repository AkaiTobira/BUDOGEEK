using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pzyjrzałem się rozwiązaniu i błędom
// Niestety nie będziemy w stanie tego wykorzystać z przyczyn niezależnych od nas.
// Component Animation jest teraz "Legacy" co oznacza że nie jest dłużej wspierany
// a to z koleji oznacza że użycie go, staje się problematyczne i nie powinno się tego robić
// Podobno Componenty Legacy mają pozostać jako kompatybilne wstecznie ale kto to wie czy dotrzymają tej obietnicy
// Będzie trzeba wykorzystać rozwiązanie oparte na Animatorze i indeksowaniu kolejnych animacji.


public class PlayerAnimationController : MonoBehaviour
{
    public float animationSpeed = 0f;
    [System.Serializable]
    public class PlayerAnimation
    {
        public string name;
        
        // Masz racje, powinno być AnimationClip zamiast Animation
        public Animation animation;
        public AnimationClip animationClip;
        public PlayerAnimation()
        {

        }
        public PlayerAnimation(string n, Animation a)
        {
            name = n; animation = a;
        }
    }
    
    public IEnumerator delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //Jeśli tutaj po tym returnie dopiszesz jakieś rzeczy 
        //to, to coś odpali się po czasie delay.
    }
    public void play(string name, float startPoint = 0f, bool isLooped = false)
    {
        PlayerAnimation playerAnimation = new PlayerAnimation();
        playerAnimation.animation = gameObject.GetComponent<Animation>();
        if (startPoint != 0f)
        {
            //StartCoroutine używa się w celu zrównoleglenia jakichś zadań
            // np. Jeśli chcesz żeby gra się zresetowała 3 sekundy po tym animacja się skończy
            StartCoroutine(delay(startPoint));
            // To co tutaj zrobiłeś to ... w sumie nic tu się nie dzieje :) 
            // Odpalasz coroutine która kończy sie po czasie startPoint i nie dzieje się nic
        }
        if (isLooped)
        {
            playerAnimation.animation[name].wrapMode = WrapMode.Loop;
        }
        playerAnimation.animation.Play(name);
    }
    public void stop()
    {
        PlayerAnimation playerAnimation = new PlayerAnimation();
        playerAnimation.animation = gameObject.GetComponent<Animation>();
        playerAnimation.animation.Stop();
    }
    public void pause()
    {
        PlayerAnimation playerAnimation = new PlayerAnimation();
        playerAnimation.animation = gameObject.GetComponent<Animation>();
        animationSpeed = playerAnimation.animation[playerAnimation.name].speed;
        playerAnimation.animation[playerAnimation.name].speed = 0;

        // Wygląda dobrze, chociaż co się stanie jeśli nacisnę w tej kolejnośći : Play, Pause, Play, Resume ?
        // Podejrzewam że jeśli animacja pierwszego Play ma inny czas odtwarzania niż druga, animacja poleci z niepasującym speedem
    }
    public void resume()
    {
        PlayerAnimation playerAnimation = new PlayerAnimation();
        playerAnimation.animation = gameObject.GetComponent<Animation>();
        playerAnimation.animation[playerAnimation.name].speed = animationSpeed;
    }


    [SerializeField] public PlayerAnimation[] animations;
    // Węzeł Animation przechowuje liste wszystkich animacji razem z nazwami i wszystkimi potrzebnymi danymi 
    // Z tego wynika że cała tablica nie jest nam potrzebna. Pownieważ można wykorzystać listę animacji z Animation
    // Jeśli chcesz wiedzieć jak można by to wykorzystać gdyby component nie przeszedł do Legacy to przygodtowałem skrypt PlayeranimationController2

    // Start is called before the first frame update
    void Start()
    {
        play("standing", 0f, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
