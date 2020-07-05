using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public float animationSpeed = 0f;
    [System.Serializable]
    public class PlayerAnimation
    {
        public string name;
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
    }
    public void play(string name, float startPoint = 0f, bool isLooped = false)
    {
        PlayerAnimation playerAnimation = new PlayerAnimation();
        playerAnimation.animation = gameObject.GetComponent<Animation>();
        if (startPoint != 0f)
        {
            StartCoroutine(delay(startPoint));
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
    }
    public void resume()
    {
        PlayerAnimation playerAnimation = new PlayerAnimation();
        playerAnimation.animation = gameObject.GetComponent<Animation>();
        playerAnimation.animation[playerAnimation.name].speed = animationSpeed;
    }

    [SerializeField] public PlayerAnimation[] animations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
