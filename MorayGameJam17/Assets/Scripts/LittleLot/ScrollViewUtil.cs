using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Framework of Common Use Classes and functions for Unity.
/// @StewMcc 09/04/2017
/// </summary>
namespace LittleLot {
	
	/// <summary>
	/// Simple Utility class for Unity Scroll Views.
	/// </summary>
	public class ScrollViewUtil : MonoBehaviour {

		/// <summary>
		/// Forces the scroll view content to focus on the target RectTransform.
		/// </summary>
		/// <param name="target"> Where to move scroll too. </param>
		public static void CenterContentVerticallyOnRect(RectTransform target, ScrollRect scrollRect, ref RectTransform content) {
			
			Vector2 newPoint = new Vector2(content.anchoredPosition.x,
					scrollRect.transform.InverseTransformPoint(content.position).y
					- scrollRect.transform.InverseTransformPoint(target.position).y);

			Vector3[] scrollRectCorners = new Vector3[4];
			Vector3[] targetCorners = new Vector3[4];
			// get the bottom of the scroll rectangle
			scrollRect.GetComponent<RectTransform>().GetWorldCorners(scrollRectCorners);
			target.GetWorldCorners(targetCorners);
			// check if the new point is to high, or past the bottom of the rectangle.
			if ((targetCorners[1].y > scrollRectCorners[1].y) ||
				(scrollRectCorners[3].y > targetCorners[3].y)) {
				content.anchoredPosition = newPoint;
			}

		}

		/// <summary>
		/// Used on Top anchored scroll views, content rectTransform to resize it to the
		/// provided height
		/// </summary>
		/// <param name="rectTransform"> RectTransform of the scroll views content. </param>
		/// <param name="newHeight"> New Height of the rect. </param>
		public static void ResizeAndClampToTop(RectTransform rectTransform,float newHeight) {
			rectTransform.sizeDelta = new Vector2(
				rectTransform.sizeDelta.x,
				newHeight);

			rectTransform.anchoredPosition = new Vector2(
				rectTransform.anchoredPosition.x, 0);
		}
	}
}
