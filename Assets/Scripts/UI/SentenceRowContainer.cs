using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceRowContainer : MonoBehaviour
{
    public int nRows;
    public SentenceRow sentenceRowPrefab;

    internal RectTransform rt;
    private VerticalLayoutGroup layoutGroup;

    private List<SentenceRow> rows = new List<SentenceRow>();
	private List<WordText> texts = new List<WordText>();
    private int rowIndex;

	public string narrator;

	public GameObject Definition;

	public float ReadAlongOn =1;

    private PageManager PageManagerRefScript;





    public Color HighlightedColor = Color.white;


    //Color.TryParseHexString("#d8314d", out HighlightedColor);

	public Color NormalColor = Color.white;


    void Awake()
    {
        /*if(HighlightedColor == Color.white)
        {
            ColorUtility.TryParseHtmlString("#d8314d", out HighlightedColor);    
        }*/

		//ColorUtility.TryParseHtmlString("#ffffff", out NormalColor);
        rt = GetComponent<RectTransform>();
        layoutGroup = GetComponent<VerticalLayoutGroup>();
        sentenceRowPrefab.gameObject.SetActive(false);
        GameObject PageManagerRef;

        PageManagerRef = GameObject.FindGameObjectWithTag("PageManager");
        PageManagerRefScript = PageManagerRef.GetComponent<PageManager>();
    }

    public void Clear()
    {
        StopAllCoroutines();
        foreach (SentenceRow row in rows)
        {
            Destroy(row.gameObject);
        }
        rows.Clear();
        texts.Clear();
        rowIndex = 0;
        CreateRow();
    }

    public void AddText(WordGroupObject wordGroup)
    {
		//Debug.Log ("78THOUSAND");

        string[] words = wordGroup.text.Split(' ');
		narrator = words [0];
        for (int i = 0; i < words.Length; i++)
        {			
			string word = words [i];

				SentenceRow currentRow = rows [rowIndex];
				WordText newText = currentRow.AddText (word);
                newText.text.color = NormalColor;
				//wordClone.GetComponent<Button> ().color.normalColor = Color.cyan;

				//To enforce the layout to rebuild, which makes the horizontal layoutgroup resize
				LayoutRebuilder.ForceRebuildLayoutImmediate (rt);

				float myWidth = rt.rect.width - layoutGroup.padding.horizontal;
				//We add a text, check if the width is fitting. 

				if (currentRow.rt.rect.width + newText.rt.rect.width >= myWidth) {
					CreateRow ();
					currentRow.PopText ();
					rowIndex++;
					//Safety check in case of really long words
					if (newText.rt.rect.width < myWidth) {
						//go a word back
						i -= 1;
					} else {
						Debug.LogWarningFormat ("The word {0} does not fit in the SentenceRowContainer! It will be skipped.", word);
					}

				} else {
					//We set the wordGroup of each textfield so we can highlight them alltogether

					newText.wordGroup = wordGroup;
					texts.Add (newText);

				}
		}
        
    }

    void CreateRow()
    {
		//Debug.Log ("Create the text for this page");
        SentenceRow sentenceRowClone = Instantiate(sentenceRowPrefab, sentenceRowPrefab.transform.parent);
        sentenceRowClone.gameObject.SetActive(true);
        rows.Add(sentenceRowClone);
    }

    public void HighlightWordGroup(WordGroupObject wordGroup)
    {
		
        foreach (WordText text in texts)
        {
			//Debug.Log(text.text);
            if (text.wordGroup == wordGroup && PageManagerRefScript.IsReadingAlong == 1.0f)
            {
				text.text.color = HighlightedColor;
               //Debug.Log(text.text.text);
            }
	            else
	            {
	                text.text.color = NormalColor;
	            }
        }

    }

    public void OnTextButton(WordText clickedText)
    {
		Definition.GetComponent<Canvas> ().enabled = true;
        foreach (WordText text in texts)
        {
            if (text.wordGroup == clickedText.wordGroup)
            {
				text.text.color = HighlightedColor;
                Debug.Log(text.text);
			}
			else
			{
				text.text.color = NormalColor;
			}
        }
    }
}
