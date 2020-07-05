using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController2 : MonoBehaviour
{
    [SerializeField] Animation m_animation = null;

    string activeAnimationName = "";
    float  activeAnimationTime = 0.0f;

    void Awake()
    {
        m_animation = GetComponent<Animation>();
    }

    private void SetAnimationStart(float startPoint){
        if( startPoint < m_animation[activeAnimationName].length){
            m_animation[activeAnimationName].time = startPoint;
        } else {
            m_animation[activeAnimationName].time = m_animation[activeAnimationName].length;
        }
    }

    public void Play(string name, float startPoint = 0f, bool isLooped = false){
        activeAnimationName = name;
        activeAnimationTime = startPoint;
        m_animation.Play(activeAnimationName);
        SetAnimationStart(startPoint);
        m_animation.wrapMode = WrapMode.Loop;
    }

    public void Stop(){
        m_animation.Stop();
    }
    public void Pause(){
        activeAnimationTime = m_animation[activeAnimationName].time;
        m_animation.Stop();
    }

    public void Resume(){
        Play(activeAnimationName, activeAnimationTime);
    }

}
