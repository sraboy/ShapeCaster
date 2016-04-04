# intro

This is a simple (and terrible) game I wrote for my daughter, as a submission for [Ludum Dare 34](http://ludumdare.com/). The competition theme (actually two themes this round): "two buttons" and "growing". The entire game was written in a 14 hour marathon with only 3 days of experience in Unity so it's neither well-designed nor bug-free (try jumping while jumping and then jump again!). Also, the buttons do not move or scale for screen size.

I used Unity 5.2.3f1, Visual Studio Community 2015, Paint .NET and Notepad++. Most of the game assets were obtained from others (sources below) though several were also edited.

![screenshot](https://github.com/sraboy/ShapeCaster/blob/master/screenshot-1.png)
![screenshot](https://github.com/sraboy/ShapeCaster/blob/master/screenshot-2.png)

# how to play

See the "zips" directory for builds for multiple targets. I haven't tested all of them but the x86 Windows & Linux builds should work. The WebGL build will require Firefox these days, due to security changes in other browsers.

Press "Fire" to zap chickens into a tasty meal. Eat the meals by colliding with them and your wizard grows in size. You can jump to avoid chickens but they are unlikely to leave you alone. If they reach you, you'll be damaged and that will cause you to shrink. Get too small and you'll lose the game! "Don't fire until you see the whites of their eyes" since every shot saps your energy and will also cause you to shrink.

# credits

- Original wizard sprite from: http://opengameart.org/content/wizard-5
- Original chicken sprite from: http://opengameart.org/content/lpc-style-farm-animals
- Chicken dinner image from: http://all-free-download.com/free-vector/download/farmeral_food_icon_clip_art_9549.html

- Zap sound from: https://www.freesound.org/people/JoelAudio/sounds/136542/
- Victory sound from: https://www.freesound.org/people/sonsdebarcelona/sounds/221937/
- Failure sound from: https://www.freesound.org/people/GabrielAraujo/sounds/242503/ (http://creativecommons.org/licenses/by/3.0/)
- Chicken sound from: https://www.freesound.org/people/Rudmer_Rotteveel/sounds/316920/

# licenses

While the code isn't properly marked at this time, this game is released under the MIT License. The background texture (grass/sky image) is Public Domain. All other assets remain under their respective licenses and/or the license applied to derivative works for the ones I've edited; follow the links to the sites above to see the license/copyright information.

# contribution / code use

I don't intend to continue working on this unless I just get really bored or want to re-visit Unity. Feel free to just use it as an example for your own learning; I (well, my daughter mostly) would be very appreciative of any fixes or features.
