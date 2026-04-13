# ModAPI Debug Dummy Game Creator
# bin\Debug\ 폴더에서 실행하세요.
# Run this script from the bin\Debug\ folder.

$base     = "$PSScriptRoot\dummy_games"
$steam    = "$PSScriptRoot\dummy_steam"
$original = "$PSScriptRoot\gamefiles\original"

$games = @(
    @{ id="TheForest";        exe="TheForest.exe";         data="TheForest_Data";         dlls=@("Assembly-CSharp.dll","Assembly-CSharp-firstpass.dll","mscorlib.dll","UnityEngine.dll") },
    @{ id="Subnautica";       exe="Subnautica.exe";         data="Subnautica_Data";         dlls=@("Assembly-CSharp.dll","mscorlib.dll","UnityEngine.dll") },
    @{ id="Raft";             exe="Raft.exe";               data="Raft_Data";               dlls=@("Assembly-CSharp.dll","mscorlib.dll","UnityEngine.dll") },
    @{ id="EscapeThePacific"; exe="EscapeThePacific.exe";   data="EscapeThePacific_Data";   dlls=@("Assembly-CSharp.dll","mscorlib.dll","UnityEngine.dll") },
    @{ id="GH";               exe="GH.exe";                 data="GH_Data";                 dlls=@("Assembly-CSharp.dll","mscorlib.dll","UnityEngine.dll") }
)

foreach ($g in $games) {
    $managedRel = "$($g.data)\Managed"

    # 1) dummy_games\ — 게임 설치 경로 더미
    $gameDir = "$base\$($g.id)"
    $managed = "$gameDir\$managedRel"
    New-Item -ItemType Directory -Force -Path $managed | Out-Null
    $null = New-Item -ItemType File -Force -Path "$gameDir\$($g.exe)"
    foreach ($dll in $g.dlls) {
        $null = New-Item -ItemType File -Force -Path "$managed\$dll"
    }

    # 2) gamefiles\original\ — ModLib 백업 경로 더미
    $origManaged = "$original\$($g.id)\$managedRel"
    New-Item -ItemType Directory -Force -Path $origManaged | Out-Null
    foreach ($dll in $g.dlls) {
        $null = New-Item -ItemType File -Force -Path "$origManaged\$dll"
    }

    Write-Host "Created: $($g.id)" -ForegroundColor Green
}

# Steam 더미
New-Item -ItemType Directory -Force -Path $steam | Out-Null
$null = New-Item -ItemType File -Force -Path "$steam\Steam.exe"
Write-Host "Created: Steam dummy" -ForegroundColor Green

Write-Host ""
Write-Host "=== Setup complete ===" -ForegroundColor Cyan
Write-Host ""
Write-Host "ModAPI Settings tab configuration:" -ForegroundColor Yellow
Write-Host "  Steam Path       : $steam"
foreach ($g in $games) {
    Write-Host "  $($g.id.PadRight(20)): $base\$($g.id)"
}
Write-Host ""
Write-Host "gamefiles\original\ also populated for ModLib." -ForegroundColor DarkGray
