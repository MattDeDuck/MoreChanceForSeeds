# More Chance For Seeds
A mod that adds the ability for ingredients to have a chance to drop seeds when added to the cauldron or bought from merchants!


## Installation (automated)

- Download and install Thunderstore Mod Manager.
  - Click Install with Mod Manager button on top of the page.
  - Run the game via the mod manager.


## Installation (manual)

- Download the latest BepInEx `5.x 64 bit` release from [here](https://github.com/BepInEx/BepInEx/releases)
  - Note: You need the `BepInEx_64` version for use with Potion Craft
- You can read the installation for BepInEx [here](https://docs.bepinex.dev/articles/user_guide/installation/index.html)
- Once installed run once to generate the config files and folders
- Download the latest version of the mod from the [releases page](https://github.com/MattDeDuck/MoreChanceForSeeds/releases)
- Unzip the folder
- Copy the folder into `Potion Craft/BepInEx/plugins/`
- Run the game once to generate the config file

  
## Setting the values in the config

You can enable/disable the ability to get seeds when adding ingredients in the cauldron or by merchants, as well as the percentage the chance is trying to aim below.

- Head to `BepInEx/config/` and open up `mattdeduck.PotionMoreChanceForSeeds.cfg` in a text editor or IDE of your choice
- `CauldronSeeds`
  - Set this to `true` to enable or `false` to disable
- `MerchantSeeds`
  - Set this to `true` to enable or `false` to disable
- `SeedChance`
  - This is the float number that the random number has to be below for the chance of seeds. Set it to between `0` and `1`
  - The default value is `0.33`


## Image

![Cauldron Seed](https://github.com/MattDeDuck/MoreChanceForSeeds/blob/master/images/screen1.png?raw=true)
