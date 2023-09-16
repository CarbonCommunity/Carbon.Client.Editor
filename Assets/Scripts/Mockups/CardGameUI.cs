using UnityEngine;

public class CardGameUI : MonoBehaviour
{
	public int lastInputCount;
	public bool dismountInProgress;
	public float dismountNormalisedProgress;
	public bool isClosing;

	public class PlayingCardImage : MonoBehaviour
	{
	}

	public class InfoTextUI : MonoBehaviour
	{
	}

	public class ICardGameSubUI : MonoBehaviour
	{
		public int DynamicBetAmount;
	}

	public class UIState : MonoBehaviour
	{
	}

	public class KeycodeWithAction : MonoBehaviour
	{
	}

	public class CardType : MonoBehaviour
	{
	}

}