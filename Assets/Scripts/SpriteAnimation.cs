using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour {

    [SerializeField]
    private Sprite[] animSlides;
    [SerializeField]
    private int currentSlide;
    [SerializeField]
    private float frame;
    // Use this for initialization
    void Start()
    {
        currentSlide = 0;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = animSlides[currentSlide];
        currentSlide += 1;
        StartCoroutine(anima());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
//        if (currentSlide <= animSlides.Length)
//        {
//            this.gameObject.GetComponent<SpriteRenderer>().sprite = animSlides[currentSlide];
//
//        }
//        currentSlide += 1;
//        if (currentSlide >= animSlides.Length)
//        {
//            currentSlide = 0;
//        }
    }

    public IEnumerator anima()
    {
        while (isActiveAndEnabled)
        {
            if (currentSlide <= animSlides.Length)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = animSlides[currentSlide];

                yield return new WaitForSeconds(frame);

            }
            currentSlide += 1;
            if (currentSlide >= animSlides.Length)
            {
                currentSlide = 0;
            }
        }
    }



}
