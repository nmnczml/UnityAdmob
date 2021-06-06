# UnityAdmob
Unity Admob Manager

# Install 
- You need to import Google Admob Package described here https://developers.google.com/admob/unity/quick-start <br>
- After installing the package and resolve it, add GameObject to the scene where you will show the ad. <br>
- In the game object add AdManager.cs script. <br>
- Open an AdMob account and create a banner according to your needs.<br>
- Add your ad id on the game object.<br>
- On main scene, on start method, you should initiliaze the ad with 	AdManager.instance.RequestBanner(); or AdManager.instance.RequestInterstitial(); <br>
- To Show Banner you can call AdManager.instance.ShowBannerAds(); or AdManager.instance.ShowInterstitial();<br>
