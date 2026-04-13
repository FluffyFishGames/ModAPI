## Create Dummy Debug Install

#### Powershell

- copy \bin\Debug\create_dummy_Debug_games.ps1

<pre>
PS Modapi\bin\Debug> Set-ExecutionPolicy -Scope Process Bypass
PS Modapi\bin\Debug> .\create_dummy_Debug_games.ps1
Created: TheForest
Created: Subnautica
Created: Raft
Created: EscapeThePacific
Created: GH
Created: Steam dummy

=== Setup complete ===

ModAPI Settings tab configuration:
  Steam Path       : Modapi\bin\Debug\dummy_steam
  TheForest           : Modapi\bin\Debug\dummy_games\TheForest
  Subnautica          : Modapi\bin\Debug\dummy_games\Subnautica
  Raft                : Modapi\bin\Debug\dummy_games\Raft
  EscapeThePacific    : Modapi\bin\Debug\dummy_games\EscapeThePacific
  GH                  : Modapi\bin\Debug\dummy_games\GH

gamefiles\original\ also populated for ModLib.
</pre>
