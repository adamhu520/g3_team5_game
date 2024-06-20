using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupText : MonoBehaviour
{

    public static void Create(Vector3 position, int damageAcount, bool isCriticalHit)
    {
        PopupText popupText = Instantiate(ResourceManager.Instance.popupText, position, Quaternion.identity);
        popupText.Setup(damageAcount, isCriticalHit);
    }

    private TextMeshPro _textMeshPro;
    private Color _textColor;

    // Move up vector and speed
    public Vector3 moveUpVector = new Vector3(x: 0, y: 1, z: 0);
    public float moveUpSpeed = 2.0f;

    public Vector3 moveDownVector = new Vector3(x: -0.7f, y: 1, z: 0);

    public float disappearSpeed = 3.0f;
    private const float DisappearTimeMax = 0.2f; // Increased��ʧʱ�� for visibility
    private float _disappearTimer;

    public Color normalColor;
    public Color criticalHitColor;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();

    }

    public void Setup(int damageAcount, bool isCriticalHit)
    {
        _textMeshPro.SetText(sourceText: damageAcount.ToString());
        if (isCriticalHit)
        {
            _textMeshPro.fontSize = 6;
            _textColor = criticalHitColor;
        }
        else
        {
            _textMeshPro.fontSize = 3;
            _textColor = normalColor;
        }
        _textMeshPro.color = _textColor;
        _disappearTimer = DisappearTimeMax;
    }

    private void Update()
    {
        // Move the text up

        if (_disappearTimer > DisappearTimeMax * 0.5f)
        {
            transform.position += moveUpVector * Time.deltaTime;
            moveUpVector += moveUpVector * (Time.deltaTime * moveUpSpeed);
            transform.localScale += Vector3.one * Time.deltaTime ;
        }

        else
        {
            //move down
            transform.position -= moveDownVector * Time.deltaTime;
            transform.localScale -= Vector3.one * Time.deltaTime ;
        }

        //Disappear
        _disappearTimer -= Time.deltaTime;
        if (_disappearTimer < 0)
        {
            _textColor.a -= disappearSpeed * Time.deltaTime;
            _textMeshPro.color = _textColor;
            if(_textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
