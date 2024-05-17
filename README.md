# osu-tourney-setup

osu!tourney setups made easier.

.NET releases are built on ARM64 dotnet v.6.0.415\
Setup:

- .NET releases (anything before v.02a) requires at least .NET 6.0
- Go to osu!'s root directory (`%localappdata/osu!/` or AppData/Local/osu!/) and create a directory titled `mappool`. Add beatmaps from the mappool into the directory
- Create a directory at %localappdata% (AppData/Local) titled `osu!tourney` and create a subdirectory titled "Songs".
- Copy the osu! executable into the root of the `osu!tourney` directory
- Run `osu-tourney-setup.exe`, osu! will run automatically afterwards
- Sign into osu! (checking both boxes) then exit. Create a file titled `tournament.cfg`in the root of the `osu!tourney` directory. osu!tournament manager should be active upon running osu! again

NOTE: `osu.db` will sometimes corrupt itself when too many beatmaps are imported (or deleted), thus failing to import anymore beatmaps. Should this happen, check the `Songs` directory for a subdirectory titled `Failed`. You should keep note that you may not be able to recover every beatmap or beatmap necessities (audio, storyboard and/or hitsounds) from this directory alone (IIRC i'm pretty sure only zipped beatmaps, .osz and .osb are placed here. Do correct me if i'm wrong but i'm 100% sure failed imported beatmaps from their own directory will not be placed here).
![image](https://github.com/WindowsMeosu/osu-tourney-setup/assets/104236864/7e27379a-2c86-4a73-8adc-cf1afd390233)
