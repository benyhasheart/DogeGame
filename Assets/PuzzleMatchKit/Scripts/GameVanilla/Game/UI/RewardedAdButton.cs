// Copyright (C) 2017-2020 gamevanilla. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using UnityEngine;
using UnityEngine.Advertisements;

using GameVanilla.Game.Common;
using GameVanilla.Game.Popups;
using GameVanilla.Game.Scenes;

namespace GameVanilla.Game.UI
{
	/// <summary>
	/// The rewarded advertisement button that is present in the level scene.
	/// </summary>
	public class RewardedAdButton : MonoBehaviour, IUnityAdsListener
	{
		private const string PlacementId = "rewardedVideo";

		private void Start()
		{
			gameObject.SetActive(Advertisement.IsReady(PlacementId));

			var gameConfig = PuzzleMatchManager.instance.gameConfig;

			var gameId = "1234567";
#if UNITY_IOS
	            gameId = gameConfig.adsGameIdIos;
#elif UNITY_ANDROID
	            gameId = gameConfig.adsGameIdAndroid;
#endif
			Advertisement.AddListener(this);
			Advertisement.Initialize(gameId, gameConfig.adsTestMode);
		}

		private void OnDestroy()
		{
			Advertisement.RemoveListener(this);
		}

		public void ShowRewardedAd()
		{
			Advertisement.Show(PlacementId);
		}

		public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
		{
			// Define conditional logic for each ad completion status:
			if (showResult == ShowResult.Finished)
			{
				var gameManager = PuzzleMatchManager.instance;
				var rewardCoins = gameManager.gameConfig.rewardedAdCoins;
				gameManager.coinsSystem.BuyCoins(rewardCoins);
				var levelScene = GameObject.Find("LevelScene");
				if (levelScene != null)
				{
					levelScene.GetComponent<LevelScene>().OpenPopup<AlertPopup>("Popups/AlertPopup", popup =>
					{
						popup.SetTitle("Reward");
						popup.SetText(string.Format("You earned {0} coins!", rewardCoins));
					}, false);
				}
			}
			else if (showResult == ShowResult.Skipped)
			{
				// Do not reward the user for skipping the ad.
			}
			else if (showResult == ShowResult.Failed)
			{
				Debug.LogWarning ("The ad did not finish due to an error.");
			}
		}

		public void OnUnityAdsReady(string placementId)
		{
			if (placementId == PlacementId)
				gameObject.SetActive(true);
		}

		public void OnUnityAdsDidError(string message)
		{
			// Log the error.
		}

		public void OnUnityAdsDidStart(string placementId)
		{
			// Optional actions to take when the end-users triggers an ad.
		}
	}
}
