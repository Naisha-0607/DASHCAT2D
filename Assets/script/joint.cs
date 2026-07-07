using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAnchor : MonoBehaviour
{
    [SerializeField] private Sprite spriteUnsticked;
    [SerializeField] private Sprite spriteSticked;

    public float animTime;
    public AnimationCurve animationCurve;

    private SpriteRenderer spriteRenderer;
    private GameObject dashLine;
    private bool sticked = false;

    void Awake()
{
    spriteRenderer = GetComponent<SpriteRenderer>();
    dashLine = transform.GetChild(1).gameObject;
}

    public void SetSticked ()
    {
        spriteRenderer.sprite = spriteSticked;
        sticked = true;
        Unselected(); // Clear the ring immediately once successfully hooked
    }

    public void SetUnsticked ()
    {
        spriteRenderer.sprite = spriteUnsticked;
        sticked = false;
        Unselected ();
    }

    public void Selected()
    {
        StopAllCoroutines();
        dashLine.transform.localScale = Vector3.zero;

        if(!sticked)
        {
            StartCoroutine(SelectingJoint());
        }
    }

    public void Unselected ()
    {
        StopAllCoroutines();
        dashLine.transform.localScale = Vector3.zero;
    }

    IEnumerator SelectingJoint()
    {
        float time = 0f;
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = new Vector3(1.2f, 1.2f, 1f);

        while(time < animTime)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / animTime);

            dashLine.transform.localScale = Vector3.Lerp(startScale, endScale, animationCurve.Evaluate(t));
            yield return null;
        }

        dashLine.transform.localScale = endScale;
    }
}