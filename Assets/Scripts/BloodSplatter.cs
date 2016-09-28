using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[Serializable]
public class BloodSplatter
{
    [SerializeField] private Image bloodTexture;

    private bool displayBlood = false;

    private Color alpha = new Color(1, 1, 1, 0);

    public float bloodTimer = 5;

    private float alphaTimer = 0;

    private float alphaFade;         

    public void UpdateCondition(float healthCondition)
    {
        if (bloodTexture != null)
        {
            if (healthCondition < 1)
            {
                alphaFade = 1 - healthCondition;

                alpha.a = alphaFade + (Mathf.Sin(alphaTimer * 5) * .15f);

                alphaTimer += Time.deltaTime;

                if (alphaTimer == Mathf.PI)
                    alphaTimer = 0;

                //Debug.Log(alpha.a);

                bloodTexture.color = alpha;
            }
            else
            {
                alpha.a = 0;
                bloodTexture.color = alpha;
            }
        }
    }

    IEnumerator StopBloodDisplay()
    {
        yield return new WaitForSeconds(bloodTimer);

        displayBlood = false;

        alpha.a = 0;

        bloodTexture.color = alpha;
    }
}
