using UnityEngine;
using TMPro;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private TMP_Text angleText;
 
    private void Update()
    {
        if (transform.rotation.z >= 0.4f)
            _rotationSpeed *= -1;
        if(transform.rotation.z * Mathf.Rad2Deg <= 0)
            _rotationSpeed = Mathf.Abs(_rotationSpeed);
        transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
        angleText.text = $"{(int)(transform.eulerAngles.z)}°";
    }
}
