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

![image](https://github.com/WindowsMeosu/osu-tourney-setup/assets/104236864/7e27379a-2c86-4a73-8adc-cf1afd390233)
