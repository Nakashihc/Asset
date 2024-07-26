using System.Collections;
using UnityEngine;
using TMPro;

public class UpiahManager : MonoBehaviour
{
    public static UpiahManager instance;

    [Header("Text Upiah")]
    public TextMeshProUGUI upiahText;

    [Header("Jumlah Upiah")]
    public int totalUpiah = 0;

    [Header("Waktu saat dalam Ruangan")]
    public int delayTime;
    public int delaylvl1;
    public int delaylvl2;
    public int delaylvl3;

    [Header("Upiah Bertambah")]
    public int upiahnambah;
    public int bangunanlvl1;
    public int bangunanlvl2;
    public int bangunanlvl3;

    [Header("Animasi Upiah")]
    public float animationDuration = 0.5f;
    public Color increaseColor = Color.green;
    public Color decreaseColor = Color.red;
    private Color originalColor;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            originalColor = upiahText.color;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpiahText();
    }

    public void UpiahTambah(int amount)
    {
        int oldTotal = totalUpiah;
        totalUpiah += amount;
        StartCoroutine(AnimateText(oldTotal, totalUpiah, amount > 0 ? increaseColor : decreaseColor));
    }

    public void UpiahKurang(int berkurang)
    {
        int oldTotal = totalUpiah;
        totalUpiah -= berkurang;
        StartCoroutine(AnimateText(oldTotal, totalUpiah, berkurang > 0 ? decreaseColor : increaseColor));
    }

    private void UpiahText()
    {
        upiahText.text = "Upiah : " + totalUpiah.ToString();
    }

    private IEnumerator AnimateText(int startValue, int endValue, Color targetColor)
    {
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            int currentValue = (int)Mathf.Lerp(startValue, endValue, elapsedTime / animationDuration);
            upiahText.text = "Upiah : " + currentValue.ToString();
            upiahText.color = Color.Lerp(originalColor, targetColor, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        upiahText.text = "Upiah : " + endValue.ToString();
        upiahText.color = originalColor;
    }

    public IEnumerator AddUpiahWithDelaylvl1()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaylvl1);
            UpiahTambah(bangunanlvl1);
        }
    }

    public IEnumerator AddUpiahWithDelaylvl2()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaylvl2);
            UpiahTambah(bangunanlvl2);
        }
    }

    public IEnumerator AddUpiahWithDelaylvl3()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaylvl3);
            UpiahTambah(bangunanlvl3);
        }
    }
}
