using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Codice.CM.Common;
using System;

public class Paddle : MonoBehaviour, IReceiveBuff
{
    [SerializeField] protected float speed;
    [SerializeField] protected float defaultSpeed = 1f;
    [SerializeField] protected float bluePotionStack;
    Coroutine bluePotionCoroutine;

    [SerializeField]
    public float minRelativePosX = 1f;  // assumes paddle size of 1 relative unit

    [SerializeField]
    public float maxRelativePosX = 15f;  // assumes paddle size of 1 relative unit

    [SerializeField]
    public float fixedRelativePosY = .64f;  // paddle does not move on the Y directiob

    // Unity units of the WIDTH of the screen (e.g. 16)
    [SerializeField]
    public float screenWidthUnits = 16;

    // Start is called before the first frame update
    void Start()
    {
        float startPosX = ConvertPixelToRelativePosition(screenWidthUnits / 2, Screen.width);
        transform.position = GetUpdatedPaddlePosition(startPosX);

        defaultSpeed = GameSession.Instance.GameSpeed;
        speed = defaultSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        var relativePosX = ConvertPixelToRelativePosition(pixelPosition: Input.mousePosition.x, Screen.width);
        transform.position = GetUpdatedPaddlePosition(relativePosX);
    }

    public Vector2 GetUpdatedPaddlePosition(float relativePosX)
    {
        // clamps the X position
        float clampedRelativePosX = Mathf.Clamp(relativePosX, minRelativePosX, maxRelativePosX);

        Vector2 newPaddlePosition = new Vector2(clampedRelativePosX, fixedRelativePosY);
        return newPaddlePosition;
    }

    public float ConvertPixelToRelativePosition(float pixelPosition, int screenWidth)
    {
        var relativePosition = pixelPosition / screenWidth * screenWidthUnits;
        return relativePosition;
    }

    public void ApplyRedPotion()
    {
        if (GameSession.Instance.PlayerLives < 5)
        {
            GameSession.Instance.PlayerLives++;
        }
    }

    public void ApplyYellowPotion()
    {
        transform.DOKill();
        transform.DOScaleX(2, 0);
        transform.DOScaleX(1, 0).SetDelay(9);
    }

    public void ApplyBluePotion()
    {
        if (bluePotionStack >= 5) return;
        speed -= defaultSpeed * 0.1f;
        GameSession.Instance.GameSpeed = speed;
        bluePotionStack++;

        if (bluePotionCoroutine != null)
        {
            StopCoroutine(bluePotionCoroutine);
        }
        bluePotionCoroutine = StartCoroutine(ResetBluePotionEffect());
    }

    public void ApplyWhitePotion()
    {
        transform.DOScaleX(1, 0);
        speed = defaultSpeed;
        GameSession.Instance.GameSpeed = speed;
        bluePotionStack = 0;

        if (bluePotionCoroutine != null)
        {
            StopCoroutine(bluePotionCoroutine);
        }
    }

    private IEnumerator ResetBluePotionEffect()
    {
        yield return new WaitForSeconds(10f);

        bluePotionStack--;

        if (bluePotionStack <= 0)
        {
            speed = defaultSpeed;
            GameSession.Instance.GameSpeed = speed;
        }
        else
        {
            speed += defaultSpeed * 0.1f; 
            GameSession.Instance.GameSpeed = speed;
        }
    }
}


