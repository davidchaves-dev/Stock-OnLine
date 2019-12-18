
var lastIdJSonLog = 130500;

function GetJson()
{
	$.ajax({
		url: "http://10.146.126.16:80/api/default/getjsonlog/" + lastIdJSonLog, 
		method:"POST",
		dataType:"json",
		cache:false,
		headers: {
              "accept": "application/json",
              "Access-Control-Allow-Origin":"*"
          },
		success: function(data)
		{
			if (data.length!=0)
			{
				$("#BoxReal").val('');
				var lastid = data[0].id;
				for (a=0;a<data.length;a++)
				{
					
					$("#BoxReal").val( $("#BoxReal").val() + "\n" + data[a].content);
					
				}
				
				lastIdJSonLog = lastid;
				
			}
			setTimeout(GetJson,5000);
			
		},
		error: function()
		{
			setTimeout(GetJson,20000);
		}});
}

var colorExternos = "#618685";
var colorUI = "#581859";
var colorGateways = "#fefbd8";
var colorDatabase = "#50394c";
var fontLabels = {size:10, color:'#ffffff', face:'roboto'};
var fontLabelsExt = {size:8, color:'#ffffff', face:'roboto'};
var fontLabelsUI = {size:20, color:'#ffffff', face:'roboto'};
var GlobalNetWork = null;

var nodes = new vis.DataSet([
        {id: 1, label: 'GOLD', shape:"circle", color:colorExternos,margin:10, font:fontLabelsExt,'physics': false},
        {id: 2, label: 'LARS', shape:"circle", color:colorExternos, margin:10, font:fontLabelsExt,'physics': false},
        {id: 3, label: 'GATEWAY 1', shape:"box", color:colorGateways, margin:20, 'physics': false},
        {id: 4, label: 'GATEWAY 2', shape:"box", color:colorGateways, margin:20, 'physics': false},
        {id: 5, label: 'PROCESO DOCUMENTO', shape:"diamond", font:fontLabels,'physics': false},
        {id: 6, label: 'PROCESO CABECERA', shape:"diamond", font:fontLabels,'physics': false},
        {id: 7, label: 'PROCESO DETALLE', shape:"diamond", font:fontLabels,'physics': false},
        {id: 8, label: 'PROCESO STOCK', shape:"diamond", font:fontLabels,'physics': false},
        {id: 9, label: 'CARGA INICIAL', shape:"diamond", font:fontLabels,'physics': false},
        {id: 10, label: 'MOVIMIENTOS/CORRECCIONES', shape:"diamond", font:fontLabels,'physics': false},
        {id: 11, label: 'DB.Cabecera',color:colorDatabase, shape:"database", font:fontLabels,'physics': false},
        {id: 12, label: 'DB.Detalle',color:colorDatabase, shape:"database", font:fontLabels,'physics': false},
        {id: 13, label: 'DB.Stock',color:colorDatabase, shape:"database", font:fontLabels,'physics': false}
    ]);

    var edges = new vis.DataSet([
        {from: 2, to: 3, 'smooth': {'type': 'cubicBezier'}},
        {from: 3, to: 5, 'smooth': {'type': 'cubicBezier'}},
        {from: 5, to: 6, 'smooth': {'type': 'cubicBezier'}},
        {from: 5, to: 7, 'smooth': {'type': 'cubicBezier'}},
        {from: 5, to: 8, 'smooth': {'type': 'cubicBezier'}},
        {from: 1, to: 4, 'smooth': {'type': 'cubicBezier'}},
        {from: 4, to: 9, 'smooth': {'type': 'cubicBezier'}},
        {from: 4, to: 10, 'smooth': {'type': 'cubicBezier'}},
        {from: 9, to: 8, 'smooth': {'type': 'cubicBezier'}},
        {from: 10, to: 8, 'smooth': {'type': 'cubicBezier'}},
        {from: 6, to: 11, 'smooth': {'type': 'cubicBezier'}},
        {from: 7, to: 12, 'smooth': {'type': 'cubicBezier'}},
        {from: 8, to: 13, 'smooth': {'type': 'cubicBezier'}},
        {from: 9, to: 13, 'smooth': {'type': 'cubicBezier'}},
        {from: 10, to: 13, 'smooth': {'type': 'cubicBezier'}}



    ]);

$(document).ready(function()
{

	setTimeout(GetJson,5000);

    // create an array with edges
    

    // create a network
    var container = document.getElementById('MyNetwork');

    // provide the data in the vis format
    var data = {
        nodes: nodes,
        edges: edges
    };
    var options = {
  autoResize: true,
  height: '100%',
  width: '100%',
  edges:{"smooth":false,hoverWidth:10},
  nodes:{"color":"#55EEEE"},
  interaction:{hover:true}
};

    // initialize your network!
    var network = new vis.Network(container, data, options);
    GlobalNetWork = network;
    network.on('hoverNode', function(hoverNode)
    {
    	console.log(hoverNode);
    	if (hoverNode.node==1000)
    	{

    	}
    	if (hoverNode.node==1002)
    	{

    	}
    });

$('#image').dialog(
	{
		autoOpen:false,
		width: 989,
        height: 538
	});


$('#RealTime').dialog(
	{
		autoOpen:false,
		width: 989,
        height: 538
	});

});


function ToggleD(dialogP)
{
if(!$(dialogP).dialog("isOpen")) {
          $(dialogP).dialog("open");
        } else {
          $(dialogP).dialog("close");
        }
}


function addNodeUI()
{
	nodes.add([{id: 1000, label: 'UI', shape:"box", color:colorUI,margin:10, font:fontLabelsUI, 'physics': false},
		{id: 1001, label: 'Controlador STOCK', shape:"diamond", color:colorUI,margin:10, font:fontLabelsUI, 'physics': false}]);
	nodes.add([{id: 1002, label: 'UI', shape:"box", color:colorUI,margin:10, font:fontLabelsUI, 'physics': false},
		{id: 1003, label: 'Controlador COMPROBANTES', shape:"diamond", color:colorUI,margin:10, font:fontLabelsUI, 'physics': false}]);
	edges.add([
		{from: 13, to: 1001, 'smooth': {'type': 'cubicBezier'}},
		{from: 1000, to: 1001, 'smooth': {'type': 'cubicBezier'}},
		{from:11, to:1003, 'smooth': {'type': 'cubicBezier'}},
		{from:12, to:1003, 'smooth': {'type': 'cubicBezier'}}, 
		{from:1002, to:1003, 'smooth': {'type': 'cubicBezier'}}
		]);
	data.update(1000);

	
}