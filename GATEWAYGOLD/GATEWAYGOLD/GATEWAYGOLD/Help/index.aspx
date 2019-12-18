<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DOCUMENTPROCESSGOLD.Help.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <title></title>
    <style type="text/css">
   body { background: #2c2c2c !important; } /* Adding !important forces the browser to overwrite the default style applied by Bootstrap */
</style>
</head>
<body>
    <form id="form1" class="bg-dark" runat="server">
        <div class="bg-info">
            Servidor de prueba actual: <i>http://SVRSTKONL01:4100</i>
        </div>
        <div class="text-white ">
             CARGA INICIAL DE STOCK<br />
            <div class="container bg-secondary text-white rounded-left">
                <b> [getExampleStockPage] </b> <br />
                <b>Función:</b>   Genera ejemplo de json requerido para el metodo post<br />
                <b>Metodo:</b> <cite> (GET) </cite> /api/default/getexamplestockpage/[cant] <br />
                <b>Parametros:</b> [Cant] cantidad de articulos que la pagina contiene <br />
                <b>Ejemplo:</b> /api/default/getexamplestockpage/13 #Obtiene una pagina con 13 articulos <br />
            </div>
            <br />
             <div class="container bg-secondary text-white rounded-left">
                 <b> [insertStockPage] </b> <br />
                <b>Función:</b> Inserta una página de actualización de stock inicial<br />
                <b>Metodo:</b> <cite> (POST) </cite> /api/default/insertstockpage <br />
                <b>Ejemplo JSON requerido:</b> <span class="text-info bg-dark"> 
                    {
    "page": 1,
    "maxPage": 100,
    "dateTime": "20190808080808",
    "Listart": [
        {
            "CodArt": "10989",
            "Cant": 23.0,
            "CodSuc": "100"
        },
        {
            "CodArt": "16678",
            "Cant": 38.0,
            "CodSuc": "102"
        },
        {
            "CodArt": "17575",
            "Cant": 51.0,
            "CodSuc": "102"
        },
        {
            "CodArt": "19799",
            "Cant": 75.0,
            "CodSuc": "105"
        },
        {
            "CodArt": "19067",
            "Cant": 9.0,
            "CodSuc": "104"
        },
        {
            "CodArt": "14920",
            "Cant": 46.0,
            "CodSuc": "102"
        },
        {
            "CodArt": "11436",
            "Cant": 96.0,
            "CodSuc": "104"
        },
        {
            "CodArt": "14722",
            "Cant": 40.0,
            "CodSuc": "107"
        },
        {
            "CodArt": "15804",
            "Cant": 85.0,
            "CodSuc": "105"
        },
        {
            "CodArt": "17959",
            "Cant": 74.0,
            "CodSuc": "105"
        }
    ]
}
</span><br />
                 <b>Respuesta (operacion exitosa):</b><span class="text-info bg-dark">{
    "code": "202",
    "message": "Página en proceso..."
}</span>
            </div>
             
        </div>
        
          <div class="text-white ">
             MOVIMIENTOS DE STOCK<br />
            <div class="container bg-secondary text-white rounded-left">
                <b> [getExampleStockMove] </b> <br />
                <b>Función:</b>   Genera ejemplo de json requerido para el metodo post<br />
                <b>Metodo:</b> <cite> (GET) </cite> /api/default/getexamplestockmove/[cant] <br />
                <b>Parametros:</b> [Cant] cantidad de articulos que el bloque contiene <br />
                <b>Ejemplo:</b> /api/default/getexamplestockmove/11 #Obtiene un bloque con 11 articulos <br />
            </div>
            <br />

              <div class="container bg-secondary text-white rounded-left">
                 <b> [insertStockMove] </b> <br />
                <b>Función:</b> Inserta un bloque de movimientos y modifica el stock actual<br />
                <b>Metodo:</b> <cite> (POST) </cite> /api/default/insertstockmove <br />
                <b>Ejemplo JSON requerido:</b> <span class="text-info bg-dark"> 
                    {"DateTime":"20191211152435","Items":[{"CodArt":"1086","Cant":9.0,"TipoMov":"SUB","BranchCod":"101"},{"CodArt":"1061","Cant":2.0,"TipoMov":"ADD","BranchCod":"104"},{"CodArt":"1065","Cant":3.0,"TipoMov":"SUB","BranchCod":"103"},{"CodArt":"1045","Cant":8.0,"TipoMov":"SUB","BranchCod":"104"},{"CodArt":"1065","Cant":7.0,"TipoMov":"ADD","BranchCod":"103"}]}
</span><br />
                 <b>Respuesta (operacion exitosa):</b><span class="text-info bg-dark">{
    "code": "202",
    "message": "Página en proceso..."
}</span>
            </div>


            </div>
        

    </form>
</body>
</html>
