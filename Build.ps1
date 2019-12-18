clear
echo '----------------------------------------------------'
$MsBuildEXE = 'C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe'
$scriptdirectory = '"E:\Webapi\WEBAPI\HL\Proyecto SOL'
$parameter =('/OUT ' + $scriptdirectory + '\' + 'BuildInfo-' + (Get-Date -Format 'yyyyMMddHHmm') + '.txt"')
echo ('MSBUILDPATH = ' + $MsBuildEXE)
echo ('SCRYPTDIRECTORY = ' + $scriptdirectory)
echo ('PARAMETER = $parameter')
echo '----------------------------------------------------'
echo 'Compiling MODELS'
Start-Process -FilePath $MsBuildEXE -ArgumentList ($scriptdirectory + '\CLASES\MODELS\MODELS.SLN"'), '/rebuild Debug', $parameter -Wait
echo 'Compiling NODE'
Start-Process -FilePath $MsBuildEXE -ArgumentList ($scriptdirectory + '\NODO\NODO.SLN"'), '/rebuild Debug', $parameter -Wait
echo 'Compiling DATA'
Start-Process -FilePath $MsBuildEXE -ArgumentList ($scriptdirectory + '\DATA\DATA\DATA.SLN"'), '/rebuild Debug', $parameter -Wait
echo 'Compiling GATEWAY'
Start-Process -FilePath $MsBuildEXE -ArgumentList ($scriptdirectory + '\GATEWAY\GATEWAY\GATEWAY.SLN"'), '/rebuild Debug', $parameter -Wait
echo 'Compiling BILLPROCESS'
Start-Process -FilePath $MsBuildEXE -ArgumentList ($scriptdirectory + '\BILLPROCESS\BILLPROCESS\BILLPROCESS.SLN"'), '/rebuild Debug', $parameter -Wait
echo 'Compiling BILL_HEADER'
Start-Process -FilePath $MsBuildEXE -ArgumentList ($scriptdirectory + '\DATA_BILLHEADER\DATA_BILLHEADER\DATA_BILLHEADER.SLN"'), '/rebuild Debug', $parameter -Wait
echo 'Compiling DATA_ITEMS'
Start-Process -FilePath $MsBuildEXE -ArgumentList ($scriptdirectory + '\DATA_ITEMS\DATA_ITEMS\DATA_ITEMS.SLN"'), '/rebuild Debug', $parameter -Wait
echo 'Compiling DATA_STOCK'
Start-Process -FilePath $MsBuildEXE -ArgumentList ($scriptdirectory + '\DATA_STOCK\DATA_STOCK\DATA_STOCK.SLN"'), '/rebuild Debug', $parameter -Wait
echo 'Finished...'



