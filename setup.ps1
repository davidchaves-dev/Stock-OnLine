clear
$Unidad = 'C:\'
remove-item -Force -Recurse ($Unidad + 'SOL\gateway\*') -verbose
remove-item -Force -Recurse ($Unidad + 'C:\SOL\billprocess\*') -verbose
remove-item -Force -Recurse ($Unidad + 'C:\SOL\data_header\*') -verbose
remove-item -Force -Recurse ($Unidad + 'C:\SOL\data_items\*') -verbose
remove-item -Force -Recurse ($Unidad + 'C:\SOL\data_stock\*') -verbose

copy-item -Force -Recurse '.\CLASES\MODELS\MODELS\bin\Debug\*' '.\BILLPROCESS\BILLPROCESS\BILLPROCESS\bin\*' 
copy-item -Force -Recurse '.\CLASES\MODELS\MODELS\bin\Debug\*' '.\DATA_BILLHEADER\DATA_BILLHEADER\DATA_BILLHEADER\bin\*'
copy-item -Force -Recurse '.\CLASES\MODELS\MODELS\bin\Debug\*' '.\DATA_ITEMS\DATA_ITEMS\DATA_ITEMS\bin\*'  
copy-item -Force -Recurse '.\CLASES\MODELS\MODELS\bin\Debug\*' '.\DATA_STOCK\DATA_STOCK\DATA_STOCK\bin\*'  
copy-item -Force -Recurse '.\CLASES\MODELS\MODELS\bin\Debug\*' '.\GATEWAY\GATEWAY\GATEWAY\bin\*' 

copy-item -Force -Recurse '.\DATA\DATA\DATA\bin\Debug\*' '.\BILLPROCESS\BILLPROCESS\BILLPROCESS\bin\*' 
copy-item -Force -Recurse '.\DATA\DATA\DATA\bin\Debug\*' '.\DATA_BILLHEADER\DATA_BILLHEADER\DATA_BILLHEADER\bin\*'
copy-item -Force -Recurse '.\DATA\DATA\DATA\bin\Debug\*' '.\DATA_ITEMS\DATA_ITEMS\DATA_ITEMS\bin\*'  
copy-item -Force -Recurse '.\DATA\DATA\DATA\bin\Debug\*' '.\DATA_STOCK\DATA_STOCK\DATA_STOCK\bin\*'  
copy-item -Force -Recurse '.\DATA\DATA\DATA\bin\Debug\*' '.\GATEWAY\GATEWAY\GATEWAY\bin\*' 


copy-item -Recurse -Force '.\GATEWAY\GATEWAY\GATEWAY\*' ($Unidad +'SOL\gateway') -verbose
copy-item -Recurse -Force '.\BILLPROCESS\BILLPROCESS\BILLPROCESS\*' ($Unidad +'C:\SOL\billprocess') -verbose
copy-item -Recurse -Force '.\DATA_BILLHEADER\DATA_BILLHEADER\DATA_BILLHEADER\*' ($Unidad + 'SOL\DATA_BILLHEADER') -verbose
copy-item -Recurse -Force '.\DATA_ITEMS\DATA_ITEMS\DATA_ITEMS\*' ($Unidad + 'SOL\DATA_ITEMS') -verbose
copy-item -Recurse -Force '.\DATA_STOCK\DATA_STOCK\DATA_STOCK\*' ($Unidad + 'SOL\DATA_STOCK') -verbose

