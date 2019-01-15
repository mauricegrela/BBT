using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceRow : MonoBehaviour
{
    public WordText wordPrefab;
	public WordText wordPrefabDef;

    internal RectTransform rt;

    private Stack<WordText> textStack = new Stack<WordText>();

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        wordPrefab.gameObject.SetActive(false);
    }

    public WordText AddText(string word)
    {
		WordText wordClone;

		wordClone = Instantiate(wordPrefab, wordPrefab.transform.parent);	
		
        
        //Debug.Log(wordClone.text.text);
        //Debug.Log(word);

        wordClone.gameObject.SetActive(true);
        wordClone.text.text = word;




		if (wordClone.text.text.Substring(0, 1) == "#") {
			var strs = wordClone.text.text.Split("#"[0]);
			wordClone.text.text = strs[1];
		}

        textStack.Push(wordClone);
        return wordClone;

    }

    public void PopText()
    {
        Destroy(textStack.Pop().gameObject);
    }
}
