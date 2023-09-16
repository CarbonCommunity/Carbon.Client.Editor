using UnityEngine;

public class TmProEmojiRedirector : MonoBehaviour
{
	public float EmojiScale;
	public bool NonDestructiveChange;
	public bool CanTextHaveLegitimateRichText;
	public bool IsInitialised;

	public class EmojiSub : MonoBehaviour
	{
		public int targetCharIndex;
		public int targetCharIndexWithRichText;
	}

}