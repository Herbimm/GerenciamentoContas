<?php

echo "<html><head> <link rel='stylesheet' href='../css/subpages.css'><script src='script/jquery-3.6.0.min.js'></script><script src='script/subpages.js'></script> <meta charset='UTF-8'> </head><body>";

$servername = "localhost";
$username = "renan";
$password = "MySQL-SGBD@1989";
$dbname = "CertMat";

$material = $_POST["material"];

// Cria conexão.
$conn = new mysqli($servername, $username, $password, $dbname);

// Checa conexão.
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

// Query.
$sql = "SELECT Nome, Contato FROM Laboratorio WHERE Nome IN (SELECT Laboratorio_Nome FROM Certificacao WHERE Material_Nome = '" . $material . "');";
$result = $conn->query($sql);

if ($material == "") {
    echo "<center> <p> É necessário informar um material no campo abaixo.</p>";
}elseif ($result->num_rows > 0) {
    
    echo "<center>";
    echo "<p> Laboratórios cadastrados que emitem certificação para " . $material . ":</p>";
    echo "<table border=1> <tr> <th> Laboratório </th> <th> Endereço </th> </tr>";

    // saída de cada linha.
    while($row = $result->fetch_assoc()) {
        echo "<tr><td>" . $row["Nome"] . "</td><td>" . $row["Contato"] . "</td></tr>";
    }
    
    echo "</table>";

} else {
    echo "<center><p> 0 resultados encontrados para " . $material . ".</p>";
    echo "<center><p> É possível que nenhum laboratório cadastrado em nosso banco emita certificações para este material.</p></center>";
    echo "<center>Porém, certifique-se que o nome informado está correto.</center>";
}
$conn->close();

echo "<p><form action='consulta.php' method='post'> <input type='text' name='material' title='Ex.: areia, cimento...' placeholder='Informe aqui o Material'> <br><br> <input class='clickable' type='submit' value='Nova Pesquisa'> </form> </center>";
echo "</body> </html>";

?>
