using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DynamicShadow : Shadow
{
    public bool isDynamic;
    public float maxOffset;
    [SerializeField] private CameraFollow cameraFollow;

    private void LateUpdate ()
    {
        if(isDynamic)
        {
            shadowSpriteRenderer.sprite = spriteRenderer.sprite;
            shadowSpriteRenderer.flipX = spriteRenderer.flipX;
            
            float offset = 0f;
            if(cameraFollow != null && cameraFollow.maxOffset != 0)
            {
                // Cleaned up the tracking logic to strictly follow the normalized camera shift
                offset = (cameraFollow.offset / cameraFollow.maxOffset) * maxOffset;
            }
            
            // Keep the shadow locked strictly underneath the parent's current real-time world position
            shadowGameObject.transform.position = transform.position + new Vector3(shadowOffset.x - offset, shadowOffset.y, 0f);
        }
    }
}