package main

import (
	"database/sql"
	"fmt"
	"log"
	"math/rand"
	"os"
	"regexp"
	"strings"
	"time"

	"github.com/bxcodec/faker/v3"
	_ "github.com/denisenkom/go-mssqldb" // paquete necesario para la conexión a SQL Server
)

type Cliente struct {
	Id               string
	Nombre           string
	Apellido         string
	RFC              string
	CuentaBancariaId string
	Activo           bool
}

type Producto struct {
	Id             string
	Nombre         string
	Descripcion    string
	PrecioCompra   float64
	PrecioPublico  float64
	PrecioEspecial float64
	Activo         bool
}

// Función para generar un RFC válido
func generarRFC(nombre, primerApellido, segundoApellido, fechaNacimiento string) string {
	primerApellido = sanitize(primerApellido)
	segundoApellido = sanitize(segundoApellido)
	nombre = sanitize(nombre)

	rfc := string(primerApellido[0])  // Letra inicial del primer apellido
	rfc += getVocal(primerApellido)   // Primera vocal interna del primer apellido
	rfc += string(segundoApellido[0]) // Letra inicial del segundo apellido
	rfc += string(nombre[0])          // Primera letra del nombre

	fecha, _ := time.Parse("2006-01-02", fechaNacimiento)
	rfc += fmt.Sprintf("%02d%02d%02d", fecha.Year()%100, int(fecha.Month()), fecha.Day())

	rfc += "XXX"

	return rfc
}

// Función para sanitizar el nombre eliminando caracteres no alfabéticos
func sanitize(input string) string {
	re := regexp.MustCompile(`[^a-zA-ZñÑ]`)
	return re.ReplaceAllString(strings.ToUpper(input), "")
}

// Función para obtener la primera vocal interna de un apellido
func getVocal(apellido string) string {
	for _, char := range apellido[1:] {
		if isVowel(char) {
			return string(char)
		}
	}
	return "X"
}

// Función para verificar si un carácter es una vocal
func isVowel(char rune) bool {
	return strings.ContainsRune("AEIOU", char)
}

// Función para generar un cliente con datos ficticios
func generarCliente() Cliente {
	nombre := faker.FirstName()
	primerApellido := faker.LastName()
	segundoApellido := faker.LastName()
	fechaNacimiento := time.Now().AddDate(-rand.Intn(80), 0, 0).Format("2006-01-02")

	rfc := generarRFC(nombre, primerApellido, segundoApellido, fechaNacimiento)

	return Cliente{
		Id:               faker.UUIDDigit(),
		Nombre:           nombre,
		Apellido:         fmt.Sprintf("%s %s", primerApellido, segundoApellido),
		RFC:              rfc,
		CuentaBancariaId: faker.UUIDDigit(),
		Activo:           true,
	}
}

func generarProducto() Producto {
	nombre := faker.FirstName()
	descripcion := faker.FirstName()
	precioCompra := 10.0 + rand.Float64()*(100.0-10.0)
	precioPublico := precioCompra + (precioCompra * 0.3)
	precioEspecial := precioPublico - (precioPublico * 0.1)

	return Producto{
		Id:             faker.UUIDDigit(),
		Nombre:         nombre,
		Descripcion:    descripcion,
		PrecioCompra:   precioCompra,
		PrecioPublico:  precioPublico,
		PrecioEspecial: precioEspecial,
		Activo:         true,
	}
}

func main() {
	connString := "sqlserver://sa:wagner@localhost:1433?database=Wagner"

	db, err := sql.Open("mssql", connString)
	if err != nil {
		log.Fatal("Error al abrir la conexión:", err)
	}

	defer db.Close()

	file, err := os.Create("registros.txt")
	if err != nil {
		log.Fatal("Error al crear el archivo:", err)
	}
	defer file.Close()

	// Generar y guardar clientes en la base de datos y en el archivo
	for i := 0; i < 3000000; i++ {
		cliente := generarCliente()

		_, err := file.WriteString(fmt.Sprintf("Cliente - ID: %s, Nombre: %s, Apellido: %s, RFC: %s, CuentaBancariaId: %s, Activo: %t\n",
			cliente.Id, cliente.Nombre, cliente.Apellido, cliente.RFC, cliente.CuentaBancariaId, cliente.Activo))
		if err != nil {
			log.Println("Error al escribir el cliente en el archivo:", err)
		}

		_, err = db.Exec("INSERT INTO Clientes (Id, Nombre, Apellido, RFC, CuentaBancariaId, Activo) VALUES (?, ?, ?, ?, ?, ?)",
			cliente.Id, cliente.Nombre, cliente.Apellido, cliente.RFC, cliente.CuentaBancariaId, cliente.Activo)

		if err != nil {
			log.Println("Error al insertar el cliente en la base de datos:", err)
		}
	}

	for i := 0; i < 100; i++ {
		producto := generarProducto()
		_, err = db.Exec("INSERT INTO Productos (Id, Nombre, Descripcion, PrecioCompra, PrecioPublico, PrecioEspecial, Activo) VALUES (?, ?, ?, ?, ?, ?, ?)",
			producto.Id, producto.Nombre, producto.Descripcion, producto.PrecioCompra, producto.PrecioPublico, producto.PrecioEspecial, producto.Activo)

		if err != nil {
			log.Println("Error al insertar el producto en la base de datos:", err)
		}
	}

	fmt.Println("Registros generados y guardados en el archivo registros.txt.")
}
